using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiSwagger;

public static class SwaggerConfigSetup
{
    private static SwaggerSetting _swaggerSetting;

    public static void AddSwaggerConfiguration(this IServiceCollection services,
                                               SwaggerSetting swaggerSetting)
    {
        if (swaggerSetting == null)
            throw new ArgumentNullException("SwaggerSetting must be config in appsetting.");

        _swaggerSetting = swaggerSetting;

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            foreach (var swaggerDoc in _swaggerSetting.SwaggerDocs)
            {
                options.SwaggerDoc(swaggerDoc.Name, new OpenApiInfo
                {
                    Version = swaggerDoc.Version,
                    Title = swaggerDoc.Title,
                    Description = swaggerDoc.Description,
                });
            }

            // Enables support for nullable object properties
            options.UseAllOfToExtendReferenceSchemas();

            options.UseInlineDefinitionsForEnums();

            options.EnableAnnotations();

            options.CustomSchemaIds(type => type.ToString());

            options.EnableAnnotations();

            if (_swaggerSetting.SwaggerSecurity != null && _swaggerSetting.SwaggerSecurity.IsValid())
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{_swaggerSetting.SwaggerSecurity.OidcBaseUrl}/connect/authorize"),
                            TokenUrl = new Uri($"{_swaggerSetting.SwaggerSecurity.OidcBaseUrl}/connect/token"),
                            Scopes = new Dictionary<string, string> {
                            { _swaggerSetting.SwaggerSecurity.OidcScopeName , _swaggerSetting.SwaggerSecurity.OidcScopeValue }
                        }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            }

            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(options =>
        {
            foreach (var swaggerDoc in _swaggerSetting.SwaggerDocs.OrderBy(x => x.Order).ToList())
            {
                options.SwaggerEndpoint($"{swaggerDoc.Name}/swagger.json", $"{swaggerDoc.Version} Version");
            }

            options.DefaultModelsExpandDepth(-1);

            options.DocExpansion(DocExpansion.None);

            if (_swaggerSetting.SwaggerSecurity != null && _swaggerSetting.SwaggerSecurity.IsValid())
            {
                options.OAuthClientId(_swaggerSetting.SwaggerSecurity.OidcClientId);
                options.OAuthAppName(_swaggerSetting.SwaggerSecurity.OidcAppName);
                options.OAuthUsePkce();
            }
        });

        app.UseSwagger(options =>
        {
            options.PreSerializeFilters.Add((swagger, req) =>
            {
                if (_swaggerSetting.IsDevelopmentEnvironment)
                {
                    swagger.Servers = new List<OpenApiServer>
                {
                    new OpenApiServer() { Url = _swaggerSetting.LocalBaseUrl },
                    new OpenApiServer() { Url = _swaggerSetting.ProductionBaseUrl }
                };
                }
                else if (!string.IsNullOrEmpty(_swaggerSetting.LocalTestBaseUrl))
                {
                    swagger.Servers = new List<OpenApiServer>
                {
                    new OpenApiServer() { Url = _swaggerSetting.LocalTestBaseUrl },
                    new OpenApiServer() { Url = _swaggerSetting.ProductionBaseUrl }
               };
                }
                else
                {
                    swagger.Servers = new List<OpenApiServer>
                {
                    new OpenApiServer() { Url = _swaggerSetting.ProductionBaseUrl }
                };
                }
            });
        });
    }

    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType != null
                && (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
                    || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any());

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        }
                    ] = new[] { _swaggerSetting.SwaggerSecurity.OidcSecurityScheme }
                }
            };
            }
        }
    }
}
