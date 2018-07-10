using Syncfusion.UI.Xaml.Controls.Layout;
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
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

namespace GU
{
    public sealed partial class ItemDetailScreen : Page
    {
        public ImageModel index = new ImageModel();
        ObservableCollection<ImageModel> image = new ObservableCollection<ImageModel>();
        ObservableCollection<ItemDetailImageModel> ItemImage = new ObservableCollection<ItemDetailImageModel>();
        ObservableCollection<UserReview> Userreview = new ObservableCollection<UserReview>();
        ObservableCollection<DescriptionModel> DescriptionModels = new ObservableCollection<DescriptionModel>();
        ObservableCollection<FavoriteImageModel> FavoriteImage = new ObservableCollection<FavoriteImageModel>();
        public static int Count = 0;
        public ItemDetailScreen()
        {
            this.InitializeComponent();
            image = ImageModel.GetImage();
            Userreview = UserReview.getUserReview();
            DescriptionModels = DescriptionModel.GetDescriptionModels();
            ItemImage = ItemDetailImageModel.getImage();

            DataContext = image;
            DataContext = Userreview;
            DataContext = DescriptionModels;
            DataContext = ItemImage;
            DataContext = FavoriteImage;

            myCarousel1.SelectedIndex = 1;
        }

        // Store Temporialy Previous Carousel Index
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            index = (ImageModel)e.Parameter;
        }

        // ButtonImage Click Navigate To Stylish Page
        void Go_AssetPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Asset1),index);
        }


        // Slider Event Change Carousel Index
        public void Slider_Valuechange(object sender, RangeBaseValueChangedEventArgs e)
        {
            myCarousel1.SelectedIndex = (int)e.NewValue - 1;
        }

        // Carousel Select Change
        private async void CarouselChange(object sender, SelectionChangedEventArgs e)
        {
            mySlider.Minimum = 1;
            mySlider.Maximum = myCarousel1.Items.Count;
            var index = myCarousel1.SelectedIndex + 1;
            LabelItemCount.Text = index + " / " + mySlider.Maximum;

            mySlider.Value = myCarousel1.SelectedIndex + 1;

            await Task.Delay(TimeSpan.FromSeconds(0.1));
            var container = myCarousel1.ContainerFromIndex(myCarousel1.SelectedIndex) as SfCarouselItem;
            var root = (FrameworkElement)container.ContentTemplateRoot;
            var LikeImage = (UIElement)root.FindName("MyImage") as Image;
            Debug.WriteLine(LikeImage.Tag);
            if (LikeImage.Tag.Equals("0"))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeUnlike_Button.BaseUri, "Assets/unlike.png");
                LikeUnlike_Button.Source = bitmap;

            }
            else if(LikeImage.Tag.Equals("1"))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeUnlike_Button.BaseUri, "Assets/like.png");
                LikeUnlike_Button.Source = bitmap;
          
            }

        }

        // Item Image Like and Unlike
        private void Like_Unlike_Tap(object sender, TappedRoutedEventArgs e)
        {
            var container = myCarousel1.ContainerFromIndex(myCarousel1.SelectedIndex) as SfCarouselItem;
            var root = (FrameworkElement)container.ContentTemplateRoot;
            var LikeImage = (UIElement)root.FindName("MyImage") as Image;
            if (LikeImage.Tag.Equals("0"))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeImage.BaseUri, "Assets/like.png");
                LikeUnlike_Button.Source = bitmap;
                LikeImage.Tag = "1";

                //Add Image To Favorite
                int image = myCarousel1.SelectedIndex + 1;
                Count = FavoriteImage.Count + 1;
                FavoriteImage.Add(new FavoriteImageModel { favoriteImage = "Assets/ItemImage/p" + image + ".jpg", Imageid = image });
            }
            else if(LikeImage.Tag.Equals("1"))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(LikeImage.BaseUri, "Assets/unlike.png");
                LikeUnlike_Button.Source = bitmap;
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
            foreach (var i in myCarousel1.Items)
            {
                var container = myCarousel1.ContainerFromItem(i) as SfCarouselItem;
                var root = (FrameworkElement)container.ContentTemplateRoot;
                var image = (UIElement)root.FindName("MyImage") as Image;
                image.Tag = "0";
            }

            LikeUnlike_Button.Tag = 0;
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(LikeUnlike_Button.BaseUri, "Assets/unlike.png");
            LikeUnlike_Button.Source = bitmap;
            Count = 0;

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
          
        }

        // Open QRCode POP UP
        private async void QR_Code(object sender, RoutedEventArgs e)
        {
            PopupView.IsOpen = false;
            PopupView.IsHitTestVisible = false;

            await Task.Delay(TimeSpan.FromSeconds(0.5));
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
            foreach (var i in myCarousel1.Items)
            {
                var container = myCarousel1.ContainerFromItem(i) as SfCarouselItem;
                var root = (FrameworkElement)container.ContentTemplateRoot;
                var image = (UIElement)root.FindName("MyImage") as Image;
                image.Tag = "0";
            }

            LikeUnlike_Button.Tag = 0;
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(LikeUnlike_Button.BaseUri, "Assets/unlike.png");
            LikeUnlike_Button.Source = bitmap;
            Count = 0;
        }



        // TabControl Left Side Image Change
        private void TabControl_Change(object sender, SelectionChangedEventArgs e)
        {
            if (ItemDetail_TabControl.SelectedIndex == 1)
            {
                CustomerReviewAverage.Opacity = 0;
                DescriptionSize.Opacity = 100;
            }
            else
            {
                CustomerReviewAverage.Opacity = 100;
                DescriptionSize.Opacity = 0;
            }
        }

        private void Home_Button(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
