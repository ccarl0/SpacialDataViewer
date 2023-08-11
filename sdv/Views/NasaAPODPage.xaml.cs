using Android.Content;
using Android.Provider;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Google;
using Plugin.Permissions;
using sdv.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using static Android.Manifest;

namespace sdv.Views;

public partial class NasaAPODPage : ContentPage
{
	IFileSaver fileSaver;
	string name;
    string url;
    private CancellationToken cancellationToken;

    public NasaAPODPage(NasaAPODRoot nasaAPODRoot)
	{
		InitializeComponent();
        BindingContext = nasaAPODRoot;

		Title.Text = nasaAPODRoot.Title;
        name = nasaAPODRoot.Title;

        Date.Text = nasaAPODRoot.Date;

		Image.Source = nasaAPODRoot.Hdurl;
        url = nasaAPODRoot.Hdurl;

		Descr.Text = nasaAPODRoot.Explanation;
		Cr.Text = nasaAPODRoot.Copyright;
    }

    private async void DoubleTapAsync(object sender, TappedEventArgs e)
    {
        //string downloadUrl = url;
        string sanitizedFileName = SanitizeFileName(name);

        string folderPath = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, "SDV");

        // Create the "sdv" folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        // Get the file name from the URL
        string imagePath = Path.Combine(folderPath, sanitizedFileName);

        // Download and save the image if it doesn't exist
        if (!File.Exists(imagePath))
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(new Uri(url));
                    File.WriteAllBytes(imagePath, imageBytes);
                }
                await Toast.Make($"Done!").Show(cancellationToken);

            }
            catch (Exception)
            {
                await Toast.Make($"The file was not saved successfully!").Show(cancellationToken);
                throw;
            }
        }

        else
        {
            await DisplayAlert("Already Downloaded", "", "Ok");
        }
    }


    public static string CleanFileName(string fileName)
    {
        // Define a regular expression to match forbidden characters
        string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        string pattern = string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars())));

        // Replace forbidden characters with an underscore
        string cleanedFileName = Regex.Replace(fileName, pattern, "_", RegexOptions.Compiled);

        return cleanedFileName;
    }

    string SanitizeFileName(string fileName)
    {
        // Replace forbidden characters with underscores
        foreach (char c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }

        // Remove additional characters that might cause issues
        fileName = Regex.Replace(fileName, @"[/:?\\*|""<>\.]", "_");

        return $"{fileName}.jpgl";
    }
}