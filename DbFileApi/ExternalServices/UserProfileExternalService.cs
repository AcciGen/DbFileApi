namespace DbFileApi.API.ExternalServices
{
    public class UserProfileExternalService
    {
        private readonly IWebHostEnvironment _env;

        public UserProfileExternalService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> AddPictureAndGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Guid.NewGuid() + file.FileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return path;

        }
    }
}
