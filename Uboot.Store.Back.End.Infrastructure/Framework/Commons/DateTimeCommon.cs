using System.Globalization;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Commons;

public static class DateTimeCommon
{
    public static DateOnly? ConvertToDate(string jalaliDate)
    {
        if (string.IsNullOrEmpty(jalaliDate) || string.IsNullOrWhiteSpace(jalaliDate))
            return null;

        if (DateOnly.TryParse(jalaliDate, out DateOnly date))
            return date;

        return null;
    }

    public static DateTime? ConvertToDateTime(string jalaliDateTime)
    {
        if (string.IsNullOrEmpty(jalaliDateTime) || string.IsNullOrWhiteSpace(jalaliDateTime))
            return null;

        if (DateTime.TryParse(jalaliDateTime, out DateTime dateTime))
            return dateTime;

        return null;
    }

    public static string ConvertToJalaliDate(DateOnly date)
    {
        var dateTime = date.ToDateTime(default);

        var calendar = new PersianCalendar();
        return string.Format("{0}/{1}/{2}", calendar.GetYear(dateTime),
                                            calendar.GetMonth(dateTime),
                                            calendar.GetDayOfMonth(dateTime));
    }

    public static string ConvertToJalaliDateFixed(DateOnly date)
    {
        var dateTime = date.ToDateTime(default);

        var calendar = new PersianCalendar();
        return string.Format("{0}/{1}/{2}", calendar.GetYear(dateTime),
                                            calendar.GetMonth(dateTime).ToString("00"),
                                            calendar.GetDayOfMonth(dateTime).ToString("00"));
    }

    public static string ConvertToJalaliDateTime(DateTime dateTime)
    {
        var calendar = new PersianCalendar();
        return string.Format("{0}/{1}/{2} {3}:{4}", calendar.GetYear(dateTime),
                                            calendar.GetMonth(dateTime),
                                            calendar.GetDayOfMonth(dateTime),
                                            dateTime.Hour,
                                            dateTime.Minute);
    }

    public static string ConvertToJalaliDateTimeFixed(DateTime dateTime)
    {
        var calendar = new PersianCalendar();
        return string.Format("{0}/{1}/{2} {3}:{4}", calendar.GetYear(dateTime),
                                            calendar.GetMonth(dateTime).ToString("00"),
                                            calendar.GetDayOfMonth(dateTime).ToString("00"),
                                            dateTime.Hour.ToString("00"),
                                            dateTime.Minute.ToString("00"));
    }
}
