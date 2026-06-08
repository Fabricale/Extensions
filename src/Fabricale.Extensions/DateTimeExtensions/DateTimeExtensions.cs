// *****************************************************************************
// Copyright (c) Fabricale(TM)
// Licensed under the Apache License, Version 2.0
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// Provides Extensions Methods for the <see cref="DateTime"/> class
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Adds business days to the date (saturdays and sundays are ignored)
    /// </summary>
    /// <param name="dateTime">Reference to the DateTime</param>
    /// <param name="days">The number of days to add</param>
    /// <returns>A new datetime with the number of days added</returns>
    /// <remarks>Holidays are not taken into consideration</remarks>
    public static DateTime AddBusinessDays(this DateTime dateTime, int days)
    {
        if (days == 0) return dateTime;

        var direction = (days > 0 ? 1 : -1);
        var currentDate = dateTime;

        while (days != 0)
        {
            currentDate = currentDate.AddDays(direction);

            if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                days -= direction;
            }
        }

        return currentDate;
    }

    // ================================================================================
    // Julian Date
    // ================================================================================

    // --------------------------------------------------------------------------------
    // A Julian Date (JD) is a continuous count of days and fractions of a day elapsed
    // since a starting point called the Julian Day Number 0, which corresponds to:
    //
    // January 1, 4713 BCE at 12:00 noon(UTC) in the proleptic Julian calendar.
    //
    // - The integer part represents the total number of days
    // - The fractional part represents the time of day
    //
    // General Format: JD xxxxxxx.xxxxx
    //
    // Days start at noon (12:00 UTC), not midnight
    // --------------------------------------------------------------------------------

    /// <summary>
    /// Converts a 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static double ToJulian(this DateTime dateTime, JulianDateFormats format = JulianDateFormats.Standard)
    {
        switch (format)
        {
            case JulianDateFormats.AS400:

                return ((dateTime.Year - 1900) * 1000) + dateTime.DayOfYear;

            default:

                // Ensure UTC (JD is based on UTC)
                dateTime = dateTime.ToUniversalTime();

                int year = dateTime.Year;
                int month = dateTime.Month;

                // Day with fractional time
                double day = dateTime.Day + (dateTime.Hour / 24.0)
                                          + (dateTime.Minute / 1440.0)
                                          + (dateTime.Second / 86400.0)
                                          + (dateTime.Millisecond / 86400000.0);

                // Adjust month and year
                if (month <= 2)
                {
                    year -= 1;
                    month += 12;
                }

                int A = year / 100;
                int B = 2 - A + (A / 4);

                double jd = Math.Floor(365.25 * (year + 4716))
                          + Math.Floor(30.6001 * (month + 1))
                          + day + B - 1524.5;

                if (format == JulianDateFormats.Modified)
                    jd -= 2400000.5;
                else if (format == JulianDateFormats.Reduced)
                    jd -= 2400000;

                return jd;
        }
    }
}

/// <summary>
/// The valid formats for a Julian Date
/// </summary>
public enum JulianDateFormats: byte
{
    /// <summary>
    /// The Standard Julian Date
    /// </summary>
    Standard = 0,
    /// <summary>
    /// The Modified Julian Date
    /// </summary>
    /// <remarks>The Modified Julian Date is a shorter version often used in engineering. The day starts at midnight instead of noon.</remarks>
    Modified = 1,
    /// <summary>
    /// The Reduced Julian Date
    /// </summary>
    Reduced = 2,
    /// <summary>
    /// A specific format used in AS400 Databases
    /// </summary>
    /// <remarks>This format has the century, year, and number of the day in year. Time is not expressed on it.</remarks>
    AS400 = 255
}
