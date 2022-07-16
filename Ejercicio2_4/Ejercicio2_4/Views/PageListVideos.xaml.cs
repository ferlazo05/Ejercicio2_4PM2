using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio2_4.Models;

namespace Ejercicio2_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListVideos : ContentPage
    {
        Videos video;
        public PageListVideos()
        {
            InitializeComponent();
        }

        private async void listVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            video = (Videos)e.Item;

            await Navigation.PushAsync(new PagePlayVideo(this.video));

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listVideos.ItemsSource = await App.BaseDatosObject.GetVideoList();
        }
    }
}