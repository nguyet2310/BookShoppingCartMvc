namespace BookShoppingCartMvc.Shared
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file, string[] allowedExtension);
        void DeleteFile(string fileName);
    }
}
