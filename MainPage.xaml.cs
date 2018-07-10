using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GU
{
    public sealed partial class MainPage : Page
    {
 
        public ObservableCollection<ImageModel> image = new ObservableCollection<ImageModel>();

        public MainPage()
        {
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            this.InitializeComponent();
            image = ImageModel.GetImage();
            this.DataContext = image;
        }

        public void image_Click(object sender, ItemClickEventArgs e)
        {
            //  var GetImageIndex = (sender as Image).DataContext as ImageModel;
            var index = (ImageModel)e.ClickedItem;
            var container = new ListViewItem();

            // get UI Element Name
            ListView obj = sender as ListView;
            string ListviewName = obj.Name;
      
              if (ListviewName.Equals("myListView1"))
              {
                  container = myListView1.ContainerFromItem(e.ClickedItem) as ListViewItem;
              }
              else if (ListviewName.Equals("myListView2"))
              {
                  container = myListView2.ContainerFromItem(e.ClickedItem) as ListViewItem;
              }
              else if (ListviewName.Equals("myListView3"))
              {
                  container = myListView3.ContainerFromItem(e.ClickedItem) as ListViewItem;
              }

              if (container != null)
              {
                  var root = (FrameworkElement)container.ContentTemplateRoot;
                  var image = (UIElement)root.FindName("myImage");
                  ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("MainPage", image);
              }
              
            Frame.Navigate(typeof(Asset1), index);
        }
    }
}
