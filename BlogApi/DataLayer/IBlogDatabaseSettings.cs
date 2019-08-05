namespace BlogApi.DataLayer
{
    public interface IBlogDatabaseSettings
    {
        string PostsCollectionName { get; set; }
        string CommentsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}