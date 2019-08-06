using System;

namespace BlogApi.Exceptions
{
    public class PostNotFoundException: Exception
    {
        public string SearchBy { get; set; }
        public string SearchValue { get; set; }

        public PostNotFoundException(string searchBy, string searchValue)
        {
            SearchBy = searchBy;
            SearchValue = searchValue;
        }
    }
}