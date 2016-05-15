using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostAdd : Page
    {

        CoreApplicationView view;
        String ImagePath;
        Double Long;
        Double Lati;
        String pictureName;

        private IMobileServiceTable<AllAdds> onlineTable = App.MobileService.GetTable<AllAdds>();

        public PostAdd()
        {
            this.InitializeComponent();
            view = CoreApplication.GetCurrentView();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InputScope scope = new InputScope();
            InputScope scope2 = new InputScope();
            InputScopeName name = new InputScopeName();
            InputScopeName name2 = new InputScopeName();
            name.NameValue = InputScopeNameValue.Number;
            name2.NameValue = InputScopeNameValue.Number;
            scope.Names.Add(name);
            scope2.Names.Add(name2);
            txtSellingPrice.InputScope = scope;
            txtContactNumber.InputScope = scope2;
        }

        private async void uploadPicture_Button(object sender, RoutedEventArgs e)
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;

        }



        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            string accountName = "gogreen";
            string accountKey = "Komo4vGSQPfw4uvFdaGi1ry9RGFRO/ltBpiabDyfdnd6G9/c04hPrYXe/WCZkziDij7qvctBHKSPLHdWQMdl6w==";

            if (args != null)
            {

                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

                try
                {
                    StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                    CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                    CloudBlobClient client = account.CreateCloudBlobClient();
                    CloudBlobContainer sampleContainer = client.GetContainerReference("images");
                    await sampleContainer.CreateIfNotExistsAsync();

                    CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(storageFile.Name);

                    pictureName = "https://gogreen.blob.core.windows.net/images/"+storageFile.Name;

                    ProgressRing1.IsActive = true;

                    await blob.UploadFromFileAsync(storageFile);

                    ProgressRing1.IsActive = false;

                    ImageSource imgSource = new BitmapImage(blob.Uri);

                    selectedImage.Source = imgSource;
                }
                catch (Exception ex)
                {
                    MessageDialog dialog = new MessageDialog(ex.ToString());
                    await dialog.ShowAsync();
                }


                // var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                //selectedImage.Source = bitmapImage;


            }


            //throw new NotImplementedException();
        }

        private async void genLocBut_Click(object sender, RoutedEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 40;

            mapProgressRing.IsActive = true;

            var position = await locator.GetGeopositionAsync();

            await GetMap.TrySetViewAsync(position.Coordinate.Point, 15D);

            //AddPushpin(position, "");

            Windows.UI.Xaml.Shapes.Ellipse fence =
            new Windows.UI.Xaml.Shapes.Ellipse();
            fence.Width = 30;
            fence.Height = 30;
            fence.Fill = new SolidColorBrush(Colors.DodgerBlue);
            fence.Stroke = new SolidColorBrush(Colors.DarkOrange);
            fence.StrokeThickness = 2;
            MapControl.SetLocation(fence, position.Coordinate.Point);
            MapControl.SetNormalizedAnchorPoint(fence, new Point(0.5, 0.5));
            GetMap.Children.Add(fence);

            mapProgressRing.IsActive = false;


            this.Long = GetMap.Center.Position.Longitude;
            this.Lati = GetMap.Center.Position.Latitude;

            //var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
            //myPosition.Latitude = 6.721901;
            //myPosition.Longitude = 79.923386;

            //var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
            //if(await GetMap.TrySetViewAsync(myPoint, 18D))
            //{

            //}

        }

        private async Task InsertDatabaseItems(AllAdds adds)
        {
            await onlineTable.InsertAsync(adds);
            //items.Add(databaseItems);

        }

        private async void postAddBut_Click(object sender, RoutedEventArgs e)
        {
            String contentCombo = (((ComboBoxItem)categoryCombo.SelectedItem).Content.ToString());

            AllAdds adds = new AllAdds
            {
                Category = contentCombo,
                Title = txtAddTitle.Text,
                Description = txtItemDescription.Text,
                Price = txtSellingPrice.Text,
                Number = txtContactNumber.Text,
                Longitude = Long.ToString(),
                Latitude = Lati.ToString(),
                Dlongitude = Long,
                Dlatitude = Lati,
                PictureName = pictureName,
                AccID = Account.accID
            };
           

            await InsertDatabaseItems(adds);
            await new MessageDialog("Your Ad is Posted").ShowAsync();
            Frame.Navigate(typeof(MainPage));


            //if (!String.IsNullOrEmpty(adds.SasQueryString))
            //{
            //    StorageCredentials cred = new StorageCredentials(adds.SasQueryString);
            //}

        }



    }
}
