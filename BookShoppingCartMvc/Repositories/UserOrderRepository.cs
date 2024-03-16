using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookShoppingCartMvc.Repositories
{
    public class UserOrderRepository : IUserOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public UserOrderRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _db=db;
            _httpContextAccessor=httpContextAccessor;
            _userManager=userManager;
        }

        public async Task<IEnumerable<Order>> UserOrders()
        {
            var userId = GetUserId();
            if(string.IsNullOrEmpty(userId))
            {
                throw new Exception("User is not logged-in");
            }
            var orders = await _db.Orders
                            .Include(x=>x.OrderDetail)
                            .ThenInclude(x=>x.Book)
                            .ThenInclude(x=>x.Genre)
                            .Include(x=>x.OrderStatus)
                            .Where(a=>a.UserId==userId)
                            .ToListAsync();
            return orders;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
    }
}
