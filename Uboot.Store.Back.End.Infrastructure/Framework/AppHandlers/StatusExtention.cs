namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public static class StatusExtention
{
    public static int ToHttpStatusCode(this Status status)
    {
        if (status == Status.Success)
        {
            return 200;
        }
        else if (status == Status.NotFound)
        {
            return 404;
        }
        else if (status == Status.BadRequest)
        {
            return 400;
        }
        else if (status == Status.Unauthorized)
        {
            return 41;
        }
        else
        {
            throw new Exception("Status Not Defined");
        }
    }
}
