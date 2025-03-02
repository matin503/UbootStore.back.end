namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public readonly struct Status : IEquatable<Status>
{
    private const short SuccessKey = 100;
    private const short BadRequestKey = 200;
    private const short NotFoundKey = 201;
    private const short UnauthorizedKey = 300;
    private const short InternalErrorKey = 500;

    public static readonly Status Success = new(SuccessKey);
    public static readonly Status BadRequest = new(BadRequestKey);
    public static readonly Status NotFound = new(NotFoundKey);
    public static readonly Status Unauthorized = new(UnauthorizedKey);
    public static readonly Status InternalError = new(InternalErrorKey);

    private readonly short key;

    private Status(short key)
    {
        this.key = key;
    }

    public static bool operator ==(Status left, Status right)
    {
        return left.key == right.key;
    }

    public static bool operator !=(Status left, Status right)
    {
        return !(left == right);
    }

    public bool Equals(Status other)
    {
        return this == other;
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }

        bool referenceEquals = ReferenceEquals(this, obj);
        if (referenceEquals)
        {
            return true;
        }

        if (obj is Status status)
        {
            return Equals(status);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(key);
    }
}
