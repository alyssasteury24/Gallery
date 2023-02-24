using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace PhotoGallery
{
    public partial class DetailPage : ContentPage
    {
        List<ImageSource> imageList = new List<ImageSource>();
        List<bool> favoriteList = new List<bool>();
        bool isFavorite = false;
        public DetailPage(string source)
        {
            InitializeComponent();
            bigImage.Source = source;

            imageList.AddRange(new List<ImageSource>
            {
                "pic2.jpg",
                "pic3.jpg",
                "pic4.jpg",
                "pic5.jpg",
                "pic6.jpg",
                "pic7.jpg",
                "pic8.jpg",
                "pic9.jpg",
                "pic10.jpg",
                "pic11.jpg",
                "pic21.jpg",
                "pic14.jpg",

            });
            for (int i = 0; i < imageList.Count; i++)
            {
                favoriteList.Add(false);
            }

        }

        private void OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            // Get the next image source and set it as the source of the Image element
            string nextImageSource = GetNextImageSource();
            if (nextImageSource != null)
            {
                string fileName = nextImageSource.Replace("File: ", "");
                bigImage.Source = fileName;

                int position = -1;
                for (int i = 0; i < imageList.Count; i++)
                {
                    string list = imageList[i].ToString();
                    if (list.Equals(nextImageSource))
                    {
                        position = i;
                        break;
                    }
                    else
                    {
                        bigImage.Source = fileName;
                    }

                }

                if (position >= 0)
                {
                    isFavorite = favoriteList[position];

                    if (isFavorite)
                    {
                        favoriteButton.Source = "favoriteButton2.png";
                    }
                    else
                    {
                        favoriteButton.Source = "unfavoriteIcon.png";
                    }
                }
            }
        }

        private void OnSwipedRight(object sender, SwipedEventArgs e)
        {
            // Get the previous image source and set it as the source of the Image element
            string previousImageSource = GetPreviousImageSource();
            if (previousImageSource != null)
            {
                string fileName = previousImageSource.Replace("File: ", "");
                bigImage.Source = fileName;
                int position = -1;

                for (int i = 0; i < imageList.Count; i++)
                {
                    string list = imageList[i].ToString();
                    if (list.Equals(previousImageSource))
                    {
                        position = i;
                        break;
                    }
                    else
                    {
                        bigImage.Source = fileName;
                    }
                }

                if (position >= 0)
                {

                    isFavorite = favoriteList[position];

                    if (isFavorite)
                    {
                        favoriteButton.Source = "favoriteButton2.png";
                    }
                    else
                    {
                        favoriteButton.Source = "unfavoriteIcon.png";
                    }
                }
            }
        }

        private string GetNextImageSource()
        {
            int position = -1;
            string nextImageSource = "";
            string file = bigImage.Source.ToString();

            // Get index of current image
            for (int i = 0; i < imageList.Count - 1; i++)
            {
                string list = imageList[i].ToString();
                if (list.Equals(file))
                {
                    position = i;
                    break;
                }
            }

            // Get index of next image
            if (position >= 0 && position < imageList.Count + 1)
            {
                int nextPosition = position + 1;
                // Get the source of the next image
                nextImageSource = imageList[nextPosition].ToString();
            }
            else
            {
                nextImageSource = file;
            }


            return nextImageSource;
        }

        private string GetPreviousImageSource()
        {
            int position = -1;
            string previousImageSource = "";
            string file = bigImage.Source.ToString();

            // Get index of current image
            for (int i = 0; i < imageList.Count; i++)
            {
                string list = imageList[i].ToString();
                if (list.Equals(file))
                {
                    position = i;
                    break;
                }
            }

            // Get index of previous image
            if (position > 0 && position < imageList.Count)
            {
                int previousPosition = position - 1;
                // Get the source of the previous image
                previousImageSource = imageList[previousPosition].ToString();
            }
            else
            {
                previousImageSource = file;
            }


            return previousImageSource;
        }


        private void OnFavoriteButtonClicked(object sender, EventArgs e)
        {
            int position = -1;
            string file = bigImage.Source.ToString();

            // Get index of current image
            for (int i = 0; i < imageList.Count; i++)
            {
                string list = imageList[i].ToString();
                if (list.Equals(file))
                {
                    position = i;
                    break;
                }
            }
            //Switch between favorite buttons
            if (position >= 0)
            {
                favoriteList[position] = !favoriteList[position];
                isFavorite = favoriteList[position];

                if (isFavorite)
                {
                    favoriteButton.Source = "favoriteButton2.png";
                }
                else
                {
                    favoriteButton.Source = "unfavoriteIcon.png";
                }
            }
        }

    }

}


