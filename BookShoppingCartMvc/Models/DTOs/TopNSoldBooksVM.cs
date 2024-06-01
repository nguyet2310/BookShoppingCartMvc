namespace BookShoppingCartMvc.Models.DTOs
{
    public class TopNSoldBooksVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<TopNSoldBookModel>? TopNSoldBooks { get; set; }

        public TopNSoldBooksVM(DateTime startDate, DateTime endDate, IEnumerable<TopNSoldBookModel>? topNSoldBooks)
        {
            StartDate = startDate;
            EndDate = endDate;
            TopNSoldBooks = topNSoldBooks;
        }
    }
}
