namespace BookShoppingCartMvc.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int quantity);
        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart();
        Task<ShoppingCart> GetCart(string userId);
        //string GetUserId();
        Task<int> GetCartItemCount(string userId = "");
        Task<bool> DoCheckout(CheckoutModel model);

    }
}
