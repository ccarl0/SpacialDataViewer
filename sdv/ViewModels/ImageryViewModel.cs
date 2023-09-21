using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sdv.Models;
using sdv.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace sdv.ViewModels
{
    public partial class ImageryViewModel : ObservableObject
    {

        [ObservableProperty]
        List<UpcomingLaunchesRoot> upcomingLaunchesSpaceX; 
        
        [ObservableProperty]
        List<NasaAPODRoot> nasaAPODs;

        [ObservableProperty]
        public bool isRefreshing;

        [RelayCommand]
        async Task UpdateImageryAsync()
        {
            var client = new HttpClient();


            try
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;

                // Calculate the date one month back
                DateTime oneMonthBack = currentDate.AddDays(-5);

                // Properly formatted
                string oneMonthBackDate = oneMonthBack.ToString("yyyy-MM-dd");

                // Send GET request to the API
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.nasa.gov/planetary/apod?start_date={oneMonthBackDate}&thumbs=True&api_key=jBR6BFhvvViOOlasSXpap8dKbpYs2nyWNY4Otum9");

                //var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.nasa.gov/planetary/apod?start_date=2023-08-01&api_key=0y29OS3mvF4FSFyBT04irdh5TLbAKCnlcLchKINJ");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();

                List<NasaAPODRoot> nasaAPODs = JsonSerializer.Deserialize<List<NasaAPODRoot>>(res);


                NasaAPODs = nasaAPODs;
                NasaAPODs.Reverse();


            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error - NASA - APOD", e.Message, "Ok");
            }
            finally
            {
                client.Dispose();
                IsRefreshing = false;
            }
        }
        [RelayCommand]
        async Task ApodInfoPage(NasaAPODRoot APODRoot)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NasaAPODPage(APODRoot));
        }
    }

    
}
