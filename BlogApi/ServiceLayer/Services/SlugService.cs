using System;
using System.Text.RegularExpressions;

namespace BlogApi.ServiceLayer
{
    public interface ISlugService
    {
        string GenerateSlugForPostTitle(string postTitle);
    }

    public class SlugService : ISlugService
    {
        public string GenerateSlugForPostTitle(string postTitle)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = DateTime.UtcNow.ToUniversalTime() - origin;
            var minutesSinceEpoch = Math.Floor(diff.TotalMinutes);

            var str = postTitle.ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");
            str = $"-{minutesSinceEpoch.ToString()}";
            return str; 
        }
    }
}