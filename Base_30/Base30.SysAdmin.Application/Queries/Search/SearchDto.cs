namespace Base30.SysAdmin.Application.Queries.Search
{
    public class SearchDto
    {
        public Guid Id { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
