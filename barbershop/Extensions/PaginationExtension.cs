using barbershop.model;
using Microsoft.EntityFrameworkCore;


namespace barbershop.Extensions
{
    public static class PaginationExtension
    {
        /// <summary>
        /// Paginates a queryable collection based on the provided query parameters.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="list">The collection to paginate.</param>
        /// <param name="qParams">The pagination parameters.</param>
        /// <returns>A <see cref="PaginationDto{T}"/> containing paginated data and metadata.</returns>
        public static PaginationDto<T> GetPaged<T>(this IQueryable<T> list, QueryParams? qParams = null)
        {
            qParams ??= new QueryParams();

            // Ensure page and pageSize are valid
            int page = Math.Max(1, qParams.page);
            int pageSize = Math.Max(1, qParams.pageSize);

            // Calculate total count and total pages
            int total = list.Count();
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);

            // Ensure page doesn't exceed total pages
            page = Math.Min(page, totalPages == 0 ? 1 : totalPages);

            // Fetch the paginated data
            IQueryable<T> data = list.Skip((page - 1) * pageSize).Take(pageSize);

            return new PaginationDto<T>
            {
                currentPage = page,
                pageSize = pageSize,
                total = total,
                totalPages = totalPages,
                data = data
            };
        }

        public static PaginationAsList<T> GetPagedToList<T>(this IQueryable<T> list, QueryParams? qParams = null)
        {
            PaginationDto<T> result = list.GetPaged(qParams);
            return new PaginationAsList<T>
            {
                currentPage = result.currentPage,
                pageSize = result.pageSize,
                data = result.data.ToList(),
                total = result.total,
                totalPages = result.totalPages,
            };
        }

        public static async Task<PaginationDto<T>> GetPagedAsync<T>(this IQueryable<T> query, QueryParams qParams) where T : class
        {
            PaginationDto<T> result = new()
            {
                currentPage = qParams.page,
                pageSize = qParams.pageSize,
                total = await query.CountAsync()
            };

            double pageCount = (double)result.total / qParams.pageSize;
            result.totalPages = (int)Math.Ceiling(pageCount);

            int skip = (qParams.page - 1) * qParams.pageSize;
            IQueryable<T> data = query.Skip(skip).Take(qParams.pageSize);

            result.data = data;

            return result;
        }

        public static async Task<PaginationAsList<T>> GetPagedToListAsync<T>(this IQueryable<T> query, QueryParams qParams) where T : class
        {
            PaginationDto<T> result = await query.GetPagedAsync(qParams);
            return new PaginationAsList<T>
            {
                currentPage = result.currentPage,
                pageSize = result.pageSize,
                data = result.data.ToList(),
                total = result.total,
                totalPages = result.totalPages,
            };
        }
    }
}
