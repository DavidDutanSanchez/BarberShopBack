namespace barbershop.model
{
    public class PaginationBaseDto
    {
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int total { get; set; }

    }
    public class PaginationDto<T> : PaginationBaseDto
    {
        public IQueryable<T>? data { get; set; }
    }
    public class PaginationAsList<T> : PaginationBaseDto
    {
        public List<T>? data { get; set; }
    }
}
