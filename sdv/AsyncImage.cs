using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sdv
{
    public class AsyncImage : Image
    {
        public static readonly BindableProperty ImageUrlProperty =
            BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(AsyncImage), default(string), propertyChanged: OnImageUrlChanged);

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        private static async void OnImageUrlChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AsyncImage asyncImage && newValue is string newUrl)
            {
                asyncImage.Source = await GetImageSourceAsync(newUrl);
            }
        }

        private static async Task<ImageSource> GetImageSourceAsync(string imageUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                    return ImageSource.FromStream(() => new System.IO.MemoryStream(imageBytes));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here (e.g., log or display an error message)
                Console.WriteLine("Image loading error: " + ex.Message);
                return null; // You can return a placeholder image or null for error cases
            }
        }
    }
}
