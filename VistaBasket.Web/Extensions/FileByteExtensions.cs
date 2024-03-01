namespace VistaBasket.Web.Extensions
{
    public static class FileByteExtensions
    {
        public static string GetImageSource(this byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                var base64Image = Convert.ToBase64String(bytes);
                return $"data:image/jpeg;base64,{base64Image}";
            }

            // Provide a default image source or handle the absence of an image
            return "default-image-url.jpg";
        }
    }
}
