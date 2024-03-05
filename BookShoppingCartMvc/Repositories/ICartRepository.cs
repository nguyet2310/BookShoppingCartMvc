namespace BookShoppingCartMvc.Repositories
{
    public interface ICartRepository
    {
        Task<bool> AddItem(int bookId, int quantity);
        Task<bool> RemoveItem(int bookId, int quantity);
        Task<IEnumerable<ShoppingCart>> GetUserCart();
        //Task<ShoppingCart> GetCart(string userId);
        //string GetUserId();
    }
}
