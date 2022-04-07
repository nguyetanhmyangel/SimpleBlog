namespace SimpleBlog.Application.Requests.Catalog
{
    public class GetAllPagedArticleRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}