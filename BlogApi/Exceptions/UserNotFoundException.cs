using System;

namespace BlogApi.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public string SubId { get; set; }

        public UserNotFoundException(string subId)
        {
            SubId = subId;
        }
    }
}