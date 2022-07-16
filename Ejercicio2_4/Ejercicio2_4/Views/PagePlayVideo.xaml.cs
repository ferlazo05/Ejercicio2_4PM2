using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2_4.Models;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePlayVideo : ContentPage
    {
        public PagePlayVideo(Videos videos)
        {
            InitializeComponent();
            setDatos(videos);
        }

        private void setDatos(Videos video)
        {
            lbldescripcion.Text = video.Descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = video.Uri
            };
            videoPlayer2.Source = uriVideoSurce;
        }
        private async void btnregresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}