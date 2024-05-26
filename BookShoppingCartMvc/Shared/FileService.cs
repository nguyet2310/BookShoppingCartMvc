namespace BookShoppingCartMvc.Shared
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFile(IFormFile file, string[] allowedExtensions)
        {
            // Lấy đường dẫn đến thư mục gốc của ứng dụng web
            var wwwPath = _environment.WebRootPath;
            // Tạo đường dẫn tới thư mục "images"
            var path = Path.Combine(wwwPath, "images");
            // Kiểm tra xem thư mục "images" có tồn tại không, nếu không thì tạo mới
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // Lấy phần mở rộng của tệp
            var extension = Path.GetExtension(file.FileName);
            // Kiểm tra xem phần mở rộng có trong danh sách các phần mở rộng được phép không
            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} files allowed");
            }
            // Tạo tên tệp mới bằng cách sử dụng GUID và phần mở rộng
            string fileName = $"{Guid.NewGuid()}{extension}";
            // Tạo đường dẫn đầy đủ tới tệp
            string fileNameWithPath = Path.Combine(path, fileName);
            // Tạo stream để lưu tệp
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            // Sao chép nội dung của tệp vào stream
            await file.CopyToAsync(stream);
            return fileName;
        }

        public void DeleteFile(string fileName)
        {
            // Lấy đường dẫn đến thư mục gốc của ứng dụng web
            var wwwPath = _environment.WebRootPath;
            // Tạo đường dẫn đầy đủ tới tệp cần xóa
            var fileNameWithPath = Path.Combine(wwwPath, "images\\", fileName);
            // Kiểm tra xem tệp có tồn tại không, nếu không thì ném ngoại lệ
            if (!File.Exists(fileNameWithPath))
                throw new FileNotFoundException(fileName);

            File.Delete(fileNameWithPath);

        }
    }
}
