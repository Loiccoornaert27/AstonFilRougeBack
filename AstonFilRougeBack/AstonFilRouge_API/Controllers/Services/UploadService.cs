namespace AstonFilRouge_API.Controllers.Services
{
    public class UploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadPicture(IFormFile picture, string folderName)
        {
            Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, folderName));

            string alteredName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

            string path = Path.Combine(_webHostEnvironment.WebRootPath, folderName, alteredName);
            Stream stream = File.Create(path);
            picture.CopyTo(stream);
            stream.Close();

            return folderName + "/" + alteredName;
        }
    }
}
