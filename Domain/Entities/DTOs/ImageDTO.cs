namespace DbFileApi.Domain.Entities.DTOs
{
    public class ImageDTO
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
