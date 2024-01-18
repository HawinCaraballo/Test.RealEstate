namespace Test.RealState.API.Model
{
    public class UploadImage
    {
        public required IFormFile FileImage { get; set; }
        public required int IdProperty { get; set; }
    }
}
