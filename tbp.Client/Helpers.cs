using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace tbp.Client
{
    public class Helpers
    {
        
        public static Task<bool> UpOneLevel() => JSRuntime.Current.InvokeAsync<bool>("upOneLevel");

        static readonly SortedList<double, Func<TimeSpan, string>> Offsets = 
            new SortedList<double, Func<TimeSpan, string>>
            {
                { 0.75, _ => "less than a minute"},
                { 1.5, _ => "about a minute"},
                { 45, x => $"{x.TotalMinutes:F0} minutes"},
                { 90, x => "about an hour"},
                { 1440, x => $"about {x.TotalHours:F0} hours"},
                { 2880, x => "a day"},
                { 43200, x => $"{x.TotalDays:F0} days"},
                { 86400, x => "about a month"},
                { 525600, x => $"{x.TotalDays / 30:F0} months"},
                { 1051200, x => "about a year"},
                { double.MaxValue, x => $"{x.TotalDays / 365:F0} years"}
            };

        public static string ToRelativeDate(DateTime input)
        {
            var x = DateTime.Now - input;
            var suffix = x.TotalMinutes > 0 ? " ago" : " from now";
            x = new TimeSpan(Math.Abs(x.Ticks));
            return Offsets.First(n => x.TotalMinutes < n.Key).Value(x) + suffix;
        }
    }
}
