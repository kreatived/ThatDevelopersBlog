namespace BlogApi.DataLayer
{
    public class BlogDatabaseSettings: IBlogDatabaseSettings
    {
        public string PostsCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}