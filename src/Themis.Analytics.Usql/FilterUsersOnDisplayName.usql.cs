using System;

namespace StackExchange.Analytics.USql
{
    public static class DataCleansing
    {
        public static string CleanseString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            input = input.Trim();
            input = input.ToLowerInvariant();

            return input;
        }
    }
}
