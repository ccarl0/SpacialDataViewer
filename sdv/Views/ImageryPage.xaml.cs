using System.Text.Json;

namespace sdv.Views;

public partial class ImageryPage : ContentPage
{
	public ImageryPage()
	{
		InitializeComponent();

        ExecuteNasaApiRequest();
        ExecuteSpaceXApiRequest();

    }

    private async void ExecuteNasaApiRequest()
    {
        // Create HttpClient instance
        HttpClient httpClient = new HttpClient();

        // API endpoint URL
        string apiUrl = "https://api.nasa.gov/planetary/apod?api_key=NjqG1ooQrf8QHmVmbJ9fjL6DnUilYtaxpczAN895";

        try
        {
            // Send GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                // Display success alert
                await DisplayAlert("Success", "Nasa Request was successful!", "OK");
            }
            else
            {
                Console.WriteLine($"Failed with status code: {response.StatusCode}");

                // Display error alert with the status code
                await DisplayAlert("Error", $"Nasa Failed with status code: {response.StatusCode}", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nasa An error occurred: {ex.Message}");

            // Display error alert with the inner exception's message
            await DisplayAlert("Nasa Error", $"Nasa An error occurred: {ex.InnerException?.Message}", "OK");
        }
        finally
        {
            // Dispose of the HttpClient instance to release resources
            httpClient.Dispose();
        }
    }

    private async void ExecuteSpaceXApiRequest()
    {
        // Create HttpClient instance
        HttpClient httpClient = new HttpClient();

        // API endpoint URL
        string apiUrl = "https://api.spacexdata.com/v4/launches/latest";

        try
        {
            // Send GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                // Deserialize the response JSON
                var responseObject = JsonSerializer.Deserialize<dynamic>(responseBody);

                // Extract the image URL from the response
                string imageUrl = responseObject.links.patch.large;

                // Set the image source of the Esa_Image widget
                Spacex_Image.Source = ImageSource.FromUri(new Uri(imageUrl));

                // Display success alert
                await DisplayAlert("Success", "Request was successful!", "OK");
            }
            else
            {
                Console.WriteLine($"Failed with status code: {response.StatusCode}");

                // Display error alert with the status code
                await DisplayAlert("Error", $"Failed with status code: {response.StatusCode}", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Display error alert with the inner exception's message
            await DisplayAlert("Error", $"An error occurred: {ex.InnerException?.Message}", "OK");
        }
        finally
        {
            // Dispose of the HttpClient instance to release resources
            httpClient.Dispose();
        }
    }
}