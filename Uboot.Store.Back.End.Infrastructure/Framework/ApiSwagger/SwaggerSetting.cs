namespace Uboot.Store.Back.End.Infrastructure.Framework.ApiSwagger;

public class SwaggerSetting
{
    public SwaggerDocSetting[] SwaggerDocs { get; set; }
    public SwaggerSecuritySetting SwaggerSecurity { get; set; }
    public string LocalBaseUrl { get; set; }
    public string LocalTestBaseUrl { get; set; }
    public string ProductionBaseUrl { get; set; }
    public bool IsDevelopmentEnvironment { get; set; }
}

public class SwaggerDocSetting
{
    public int Order { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class SwaggerSecuritySetting
{
    public string OidcAppName { get; set; }
    public string OidcBaseUrl { get; set; }
    public string OidcScopeName { get; set; }
    public string OidcScopeValue { get; set; }
    public string OidcClientId { get; set; }
    public string OidcSecurityScheme { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(OidcAppName)
            && !string.IsNullOrEmpty(OidcBaseUrl)
            && !string.IsNullOrEmpty(OidcScopeName)
            && !string.IsNullOrEmpty(OidcScopeValue)
            && !string.IsNullOrEmpty(OidcClientId)
            && !string.IsNullOrEmpty(OidcSecurityScheme);
    }
}
