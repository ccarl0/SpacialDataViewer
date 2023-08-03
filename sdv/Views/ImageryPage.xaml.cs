using sdv.Models;
using System.Text.Json;
using static sdv.Models.PL;

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
        var client = new HttpClient();

        try
        {
            // Send GET request to the API
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spacexdata.com/v4/launches/upcoming");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                List<PL.DeserializedPL> pastLaunches = JsonSerializer.Deserialize<List<DeserializedPL>>(res);
                await DisplayAlert("SpaceX Success", $"{pastLaunches[0].Links.MissionPatch}Request was successful!", "OK");
            }
            else
            {
                Console.WriteLine($"SpaceX Failed with status code: {response.StatusCode}");

                // Display error alert with the status code
                await DisplayAlert("SpaceX Error", $"Failed with status code: {response.StatusCode}", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SpaceX An error occurred: {ex.Message}");

            // Display error alert with the inner exception's message
            await DisplayAlert("SpaceX Error", $"An error occurred: {ex.InnerException?.Message}", "OK");
        }
        finally
        {
            // Dispose of the HttpClient instance to release resources
            client.Dispose();
        }
    }
}