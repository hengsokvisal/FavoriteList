using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Controls.Layout;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GU
{
    public sealed partial class Asset1 : Page
    {
        //public ImageModel index = new ImageModel();
        public ObservableCollection<ImageModel> image = new ObservableCollection<ImageModel>();
        public ObservableCollection<FavoriteImageModel> FavoriteImage = new ObservableCollection<FavoriteImageModel>();
        public static int Count=0;
        public Asset1()
        {
            InitializeComponent();
            image = ImageModel.GetImage();
            DataContext = image;
            DataContext = FavoriteImage;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var index = (ImageModel)e.Parameter;
            if(index != null)
            {
                myCarousel.SelectedIndex = index.id - 1;
                ConnectedAnimation myConn = ConnectedAnimationService.GetForCurrentView().GetAnimation("MainPage");
                if (myConn != null)
                {
                    myConn.TryStart(myCarousel);
                }
            }
            else
            {
                myCarousel.SelectedIndex = 0;
            }
           

        }

        void LeftBtnClick(object sender, RoutedEventArgs e)
        {
            if (myCarousel.SelectedIndex != 0)
            {
                myCarousel.SelectedIndex -= 1;
            }
        }

        void HomeBtnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        void RightBtnClick(object sender, RoutedEventArgs e)
        {
            if (myCarousel.SelectedIndex != myCarousel.Items.Count-1)
            {
                myCarousel.SelectedIndex += 1;
            }
        }

        // Navigate To ItemDetail Screen
        void Item_DetailClick(object sender , RoutedEventArgs e)
        {
            Count = 0;
            var info = new ImageModel();
            info.id = myCarousel.SelectedIndex + 1;
            Frame.Navigate(typeof(ItemDetailScreen),info);
        }

        // Show Like Button 
        private async void Show_LikeButton(object sender, SelectionChangedEventArgs e)
        {
           /* await Task.Delay(TimeSpan.FromSeconds(0.2));
            var index = myCarousel.SelectedIndex;
            var container = myCarousel.ContainerFromIndex(index) as SfCarouselItem;
            var root = (FrameworkElement)container.ContentTemplateRoot;
            var LikeImage = (UIElement)root.FindName("LikeImage") as Image;
            LikeImage.Opacity = 1;*/
        }

        // Styling Image Like and Unlike 
        private void Like_Click(object sender, TappedRoutedEventArgs e)
        {
            var Flag = (sender as Image).Tag;
            var container = myCarousel.ContainerFromIndex(myCarousel.SelectedIndex) as SfCarouselItem;
            var root = (FrameworkElement)container.ContentTemplateRoot;
            var LikeImage = (UIElement)root.FindName("LikeImage") as Image;

            if (Flag.Equals("0"))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeImage.BaseUri, "Assets/like.png");
                LikeImage.Source = bitmap;
                LikeImage.Tag = "1";
                Count = FavoriteImage.Count + 1;

                //Add Image To Favorite
                int image = myCarousel.SelectedIndex + 1;
                FavoriteImage.Add(new FavoriteImageModel { favoriteImage = "Assets/" + image + ".jpg" ,Imageid = image});
            }
            else
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeImage.BaseUri, "Assets/unlike.png");
                LikeImage.Source = bitmap;
                LikeImage.Tag = "0";
                Count = FavoriteImage.Count - 1;
                FavoriteImage.RemoveAt(Count);
            }
            CountLabel.Text = Count + "";
            FavoriteCountLabel.Text = Count + "";
        }

        // Open Favorite List Screen
        private async void Open_FavoriteList(object sender, RoutedEventArgs e)
        {
            CountLabel.Text = Count + "";

            BlurBorder.IsHitTestVisible = true;
            OpacityBorder.IsHitTestVisible = true;
            //Blur Animation
            Blur.Value = 10;
            Blur.Duration = 1000;
            OpacityBorder.Background = new SolidColorBrush(Colors.Black);
            OpacityBorder.Opacity = 0.2;

            await Task.Delay(TimeSpan.FromSeconds(0.5));
            PopupView.IsOpen = true;
            PopupView.IsHitTestVisible = true;
        }


        // Remove All Button
        private void PopupImage_Clear(object sender, RoutedEventArgs e)
        {
            FavoriteImage.Clear();
            CountLabel.Text = 0 + "";
            FavoriteCountLabel.Text = 0 + "";
            foreach (var i in myCarousel.Items)
            {
                var container = myCarousel.ContainerFromItem(i) as SfCarouselItem;
                var root = (FrameworkElement)container.ContentTemplateRoot;
                var image = (UIElement)root.FindName("LikeImage") as Image;
                image.Tag = "0";
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(image.BaseUri, "Assets/unlike.png");
                image.Source = bitmap;
            }
        }

        // Close Favorite Screen
        private void Popup_Close(object sender, RoutedEventArgs e)
        {
            PopupView.IsOpen = false;
            PopupView.IsHitTestVisible = false;
            BlurBorder.IsHitTestVisible = false;
            OpacityBorder.IsHitTestVisible = false;
            OpacityBorder.Background = new SolidColorBrush(Colors.Transparent);
            Blur.Value = 0;
            Blur.Duration = 200;
        }

        // Remove Unlike
        private void Unlike_Click(object sender, TappedRoutedEventArgs e)
        {
            var getTag = (Image)sender;
            var Index = (int)getTag.Tag;
            // Loop through Carousel item and Favorite Image To Remove Unlike Photo.
            foreach (var item in myCarousel.Items)
            {
                var Carouselimage = (ImageModel)item;
                for (int i = 0; i < FavoriteImage.Count; i++)
                {
                    if(Index == FavoriteImage[i].Imageid)
                    {
                        Debug.WriteLine("Carousel"+Carouselimage.id);
                        Debug.WriteLine("Favorite"+FavoriteImage[i].Imageid);

                        if (Carouselimage.id == FavoriteImage[i].Imageid)
                        {

                            Debug.WriteLine(Carouselimage.id);
                            Debug.WriteLine(FavoriteImage[i].Imageid);
                            var container = myCarousel.ContainerFromItem(item) as SfCarouselItem;
                            var root = (FrameworkElement)container.ContentTemplateRoot;
                            var image = (UIElement)root.FindName("LikeImage") as Image;
                            image.Tag = "0";
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.UriSource = new Uri(image.BaseUri, "Assets/unlike.png");
                            image.Source = bitmap;
                        }
                    }
                }
            }
            for (int i = 0; i < FavoriteImage.Count; i++)
            {
                if (Index == FavoriteImage[i].Imageid)
                {
                    FavoriteImage.RemoveAt(i);
                    Count -= 1;
                    CountLabel.Text = Count + "";
                    FavoriteCountLabel.Text = Count + "";
                }
            }
        }

        // Open QRCode POP UP
        private async void QR_Code(object sender, RoutedEventArgs e)
        {
            PopupView.IsOpen = false;
            PopupView.IsHitTestVisible = false;

            await Task.Delay(TimeSpan.FromSeconds(0.5));

            /*
            //Progress Bar
            ProgresBar.IsOpen = true;
            Loading.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.001));
                Loading.Value += 1;
            }
            ProgresBar.IsOpen = false;
            ProgresBar.IsHitTestVisible = false;
           */

            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var pixelData = writer.Write(@"http://google.com");
            
            Debug.WriteLine(pixelData.PixelWidth);
            Debug.WriteLine(pixelData.PixelHeight);
            var bitmap = pixelData;
            QRCode.Source = bitmap;
            PopupQRCode.IsOpen = true;
            PopupQRCode.IsHitTestVisible = true;
        }

        // QRCode Keep Content Button
        private void KeepContent_Click(object sender, RoutedEventArgs e)
        {
            PopupQRCode.IsOpen = false;
            PopupQRCode.IsHitTestVisible = false;
            BlurBorder.IsHitTestVisible = false;
            OpacityBorder.IsHitTestVisible = false;
            OpacityBorder.Background = new SolidColorBrush(Colors.Transparent);
            Blur.Value = 0;
            Blur.Duration = 200;
        }

        // QRCode Clear All Button
        private void Clearall_Click(object sender, RoutedEventArgs e)
        {
            PopupQRCode.IsOpen = false;
            PopupQRCode.IsHitTestVisible = false;
            BlurBorder.IsHitTestVisible = false;
            OpacityBorder.IsHitTestVisible = false;
            OpacityBorder.Background = new SolidColorBrush(Colors.Transparent);
            Blur.Value = 0;
            Blur.Duration = 200;

            FavoriteImage.Clear();
            CountLabel.Text = 0 + "";
            FavoriteCountLabel.Text = 0 + "";
            foreach (var i in myCarousel.Items)
            {
                var container = myCarousel.ContainerFromItem(i) as SfCarouselItem;
                var root = (FrameworkElement)container.ContentTemplateRoot;
                var image = (UIElement)root.FindName("LikeImage") as Image;
                image.Tag = "0";
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(image.BaseUri, "Assets/unlike.png");
                image.Source = bitmap;
            }
        }
        
       
    }
}
