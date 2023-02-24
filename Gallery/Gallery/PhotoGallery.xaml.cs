using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoGallery
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnImageClicked(object sender, EventArgs e)
        {
            ImageButton tappedImage = sender as ImageButton;
            string source = tappedImage.Source.ToString();
            string fileName = source.Replace("File: ", "");


            await Navigation.PushAsync(new DetailPage(fileName));
        }


    }

}

