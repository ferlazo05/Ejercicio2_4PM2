using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using System.IO;
using Ejercicio2_4.Views;
using Ejercicio2_4.Models;

namespace Ejercicio2_4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string PhotoPath;

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return;
            }
            CaptureVideo();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdescripcion.Text))
            {
                await DisplayAlert("Alerta", "Por favor ingresar una descripcion.", "OK");
                txtdescripcion.Focus();
                return;
            }
            else
            {
                var videos = new Videos
                {
                    Uri = PhotoPath,
                    Descripcion = txtdescripcion.Text
                };

                var resultado = await App.BaseDatosObject.SaveVideoRecord(videos);

                if (resultado == 1)
                {
                    await DisplayAlert("", "Video guardado.", "OK");
                    txtdescripcion.Text = "";
                    videoPlayer.Source = null;
                }
                else
                {
                    await DisplayAlert("Error", "Video no guardado", "OK");
                }
            }
        }

        public async void CaptureVideo()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                //Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };
                videoPlayer.Source = uriVideoSurce;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }
        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageListVideos());
        }
    }
}