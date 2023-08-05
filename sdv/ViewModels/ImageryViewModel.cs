using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using sdv.Models;
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
        public bool isRefreshing;

        [RelayCommand]
        async Task UpdateImageryAsync()
        {
            var client = new HttpClient();


            try
            {
                // Send GET request to the API
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spacexdata.com/v4/launches/upcoming");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();

                List<UpcomingLaunchesRoot> upcomingLaunches = JsonSerializer.Deserialize<List<UpcomingLaunchesRoot>>(res);


                foreach (var item in upcomingLaunches)
                {
                    if (item.Links.Patch.Large == "null" || item.Links.Patch.Large == null)
                    {
                        item.Links.Patch.Large = "https://commons.wikimedia.org/w/index.php?title=File:SpaceX-Logo-Xonly.svg&lang=en#/media/File:SpaceX-Logo-Xonly.svg";
                    }
                }

                UpcomingLaunchesSpaceX = upcomingLaunches;


            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error - SpaceX", e.Message, "Ok");
            }
            finally
            {
                client.Dispose();
                IsRefreshing = false;
            }
        }
    }

    
}
