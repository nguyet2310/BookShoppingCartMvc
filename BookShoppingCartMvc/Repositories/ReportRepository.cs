using BookShoppingCartMvc.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingCartMvc.Repositories
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;
        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TopNSoldBookModel>> GetTopNSellingBooksByDate(DateTime startDate, DateTime endDate)
        {
            //var startDateParam = new SqlParameter("@startDate", startDate);
            //var endDateParam = new SqlParameter("@endDate", endDate);
            //var topFiveSoldBooks = await _context.Database.SqlQueryRaw<TopNSoldBookModel>
            //    ("exec Usp_GetTopNSellingBooksByDate @startDate,@endDate", startDateParam, endDateParam)
            //    .ToListAsync();
            //return topFiveSoldBooks;

            var query = @"
        WITH UnitSold AS
        (
            SELECT od.BookId, SUM(od.Quantity) AS TotalUnitSold
            FROM [order] o
            JOIN OrderDetail od ON o.Id = od.OrderId
            WHERE o.IsPaid = 1 AND o.IsDeleted = 0 AND o.CreateDate BETWEEN @startDate AND @endDate
            GROUP BY od.BookId
        )
        SELECT TOP 5 b.BookName, b.AuthorName, us.TotalUnitSold
        FROM UnitSold us
        JOIN [Book] b ON us.BookId = b.Id
        ORDER BY us.TotalUnitSold DESC";

            var parameters = new[]
            {
        new SqlParameter("@startDate", startDate),
        new SqlParameter("@endDate", endDate)
    };

            var topFiveSoldBooks = await _context.Set<TopNSoldBookModel>()
                .FromSqlRaw(query, parameters)
                .ToListAsync();

            return topFiveSoldBooks;
        }
    }
}
