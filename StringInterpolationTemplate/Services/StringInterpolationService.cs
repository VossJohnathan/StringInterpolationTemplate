using System;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        Console.WriteLine(answer);

        return answer;
    }

    //2 - 2019.01.22
    public string Number02()
    {
        var today = _date.Now;
        return $"{today:yyyy.MM.dd}";
    }

    //3 - Day 22 of January, 2019
    public string Number03()
    {
        var today = _date.Now;
        return $"Day {today:dd} of {today:MMMM, yyyy}";
    }

    //4 - Year: 2019, Month: 01, Day: 22
    public string Number04()
    {
        var today = _date.Now;
        return $"Year: {today:yyyy}, Month: {today:mm}, Day: {today:dd}";
    }

    //5 -            Tuesday (10 spaces total, right aligned)
    public string Number05()
    {
        var today = _date.Now;
        return $"{today,10:dddd}";
    }

    //6 -     11:01 PM             Tuesday (10 spaces total for each including the day-of-week, both right-aligned)
    public string Number06()
    {
        var today = _date.Now;
        return $"{today,10:t}{today,10:dddd}";
    }

    //7 - h:11, m:01, s:27
    public string Number07()
    {
        var today = _date.Now;
        return $"h:{today.Hour}, m:{today.Minute}, s:{today.Second}";
    }

    //8 - 2019.01.22.11.01.27
    public string Number08()
    {
        var today = _date.Now;
        return $"{today:yyyy.MM.dd.}{today.Hour}.{today.Minute}.{today.Second}";
    }

    // NUMBER TIME
    // If you have PI (3.1415) - use var pi = Math.PI;

    //1 - Output as currency
    public string Number09()
    {
        var pi = Math.PI;
        return $"{pi:C2}";
    }

    //2 - Output as right-aligned (10 spaces), number with 3 decimal places
    public string Number10()
    {
        var pi = Math.PI;
        return $"{pi,10:N3}";
    }

    public string Number11()
    {
        var today = _date.Now;

        return $"{today.Year.ToString("X")}";
    }

    //2.2019.01.22
}
