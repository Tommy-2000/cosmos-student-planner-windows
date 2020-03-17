using CosmosStudentPlanner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Input.Inking;
using Windows.UI.Input.Inking.Analysis;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using CosmosStudentPlanner.Model;
using Microsoft.Graphics.Canvas;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.Graphics.Display;
using Windows.UI;
using static CosmosStudentPlanner.Model.MasterContext;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CosmosStudentPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateEventPage : Page
    {
        public CreateEventPage()
        {
            this.InitializeComponent();
            Loaded += CreateEventPage_Loaded;

            Windows.UI.ViewManagement.UISettings settings =
                new Windows.UI.ViewManagement.UISettings();
            HorizontalAlignment alignment =
                (settings.HandPreference ==
                Windows.UI.ViewManagement.HandPreference.RightHanded) ?
                HorizontalAlignment.Left : HorizontalAlignment.Right;
            EventInkToolbar.HorizontalAlignment = alignment;

            EventInkNote.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Touch |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        }

        private void CreateEventPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new MasterContext())
            {

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigateBack_Button.IsEnabled = this.Frame.CanGoBack;
        }



        private void NavigateBack_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private void EventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void DeviceOnDeviceLost(CanvasDevice sender, object args)
        {
            Debug.WriteLine("DeviceOnDeviceLost");
        }



        private void Create_Event_Click(object sender, RoutedEventArgs e)
        {

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)EventInkNote.ActualWidth, (int)EventInkNote.ActualHeight, 96);

            using (var ds = renderTarget.CreateDrawingSession())
            {
                ds.Clear(Colors.White);
                ds.DrawInk(EventInkNote.InkPresenter.StrokeContainer.GetStrokes());
            }

            using (var db = new MasterContext())
            {
                
            }


        }
    }
}

            
    


