using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uboot.Store.Back.End.Infrastructure.Framework.Commons;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Extensions
{
    public static class DateTimeExtention
    {
        public static DateOnly? ToDate(this string jalaliDate) => DateTimeCommon.ConvertToDate(jalaliDate);

        public static DateTime? ToDateTime(this string jalaliDateTime) => DateTimeCommon.ConvertToDateTime(jalaliDateTime);


        public static string ToJalaliDate(this DateOnly date) => DateTimeCommon.ConvertToJalaliDate(date);

        public static string ToJalaliDateFixed(this DateOnly date) => DateTimeCommon.ConvertToJalaliDateFixed(date);

        public static string ToJalaliDateTime(this DateTime dateTime) => DateTimeCommon.ConvertToJalaliDateTime(dateTime);

        public static string ToJalaliDateTimeFixed(this DateTime dateTime) => DateTimeCommon.ConvertToJalaliDateTimeFixed(dateTime);


        public static DateTime ToDateTime(this DateOnly date) => date.ToDateTime(new TimeOnly());

        public static DateTime? ToDateTime(this DateOnly? date) => date?.ToDateTime(new TimeOnly());

        public static DateOnly ToDateOnly(this DateTime dateTime) => DateOnly.FromDateTime(dateTime);

        public static DateOnly ToDateOnly(this string dateTimeString) => DateOnly.FromDateTime(DateTime.Parse(dateTimeString));

        public static DateOnly? ToDateOnly(this DateTime? dateTime) => dateTime == null ? null : DateOnly.FromDateTime(dateTime.Value);

        public static TimeOnly ToTimeOnly(this DateTime dateTime) => TimeOnly.FromDateTime(dateTime);

        public static TimeOnly? ToTimeOnly(this DateTime? dateTime) => dateTime == null ? null : TimeOnly.FromDateTime(dateTime.Value);

        public static TimeOnly ToTimeOnly(this TimeSpan time) => TimeOnly.FromTimeSpan(time);

        public static TimeOnly? ToTimeOnly(this TimeSpan? time) => time == null ? null : TimeOnly.FromTimeSpan(time.Value);

        public static TimeSpan? ToTimeSpan(this TimeOnly? time) => time?.ToTimeSpan();

        public static bool GreaterThanToday(this DateOnly date) => date > DateTime.Now.ToDateOnly();

        public static bool GreaterThanToday(this DateTime dateTime) => dateTime.ToDateOnly() > DateTime.Now.ToDateOnly();

        public static bool EqualOrGreaterThanToday(this DateOnly date) => date >= DateTime.Now.ToDateOnly();

        public static bool EqualOrGreaterThanToday(this DateTime dateTime) => dateTime.ToDateOnly() >= DateTime.Now.ToDateOnly();

        public static bool GreaterThan(this DateOnly date1, DateOnly date2) => date1 > date2;

        public static bool GreaterThan(this DateOnly date, DateTime dateTime) => date > dateTime.ToDateOnly();

        public static bool GreaterThan(this DateTime dateTime1, DateTime dateTime2) => dateTime1 > dateTime2;

        public static bool GreaterThan(this DateTime dateTime, DateOnly date) => dateTime.ToDateOnly() > date;

        public static bool EqualOrGreaterThan(this DateOnly date1, DateOnly date2) => date1 >= date2;

        public static bool EqualOrGreaterThan(this DateOnly date, DateTime dateTime) => date >= dateTime.ToDateOnly();

        public static bool EqualOrGreaterThan(this DateTime dateTime1, DateTime dateTime2) => dateTime1 >= dateTime2;

        public static bool EqualOrGreaterThan(this DateTime dateTime, DateOnly date) => dateTime.ToDateOnly() >= date;

        public static bool IsValid(this DateTime dateTime) => dateTime != new DateTime(1900, 1, 1) && dateTime != DateTime.MinValue;

        public static bool IsValid(this DateOnly date) => date != new DateOnly(1900, 1, 1) && date != DateOnly.MinValue;
    }

}
