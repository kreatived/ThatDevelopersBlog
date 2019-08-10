using System;

namespace BlogApi.Exceptions
{
    public class UnauthorizedOperationException: Exception
    {
        public string UserId { get; set; }
        public string AttemptedOperation { get; set; }

        public UnauthorizedOperationException(string userId, string attemptedOperation)
        {
            UserId = userId;
            AttemptedOperation = attemptedOperation;
        }
    }
}