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

using CosmosStudentPlanner.MasterDataModel;

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

        private void CreateEventButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MasterDataContext())
            {
                var eventTitle = new Event { EventTitle = EventTitle.Text };
                db.Events.Add(eventTitle);
                db.SaveChanges();

                var eventDescription = new Event { EventDescription = EventDescription.Text };
                db.Events.Add(eventDescription);
                db.SaveChanges();

                var eventDatePicker = new Event { EventDatePicker = EventDatePicker.Date };
                db.Events.Add(eventDatePicker);
                db.SaveChanges();

                var eventTimePicker = new Event { EventTimePicker = EventTimePicker.Time };
                db.Events.Add(eventTimePicker);
                db.SaveChanges();

                var eventInkNote_FilePath = new Event { EventInkNote_FilePath = EventInkNote.InkPresenter };
                db.Events.Add(eventInkNote_FilePath);
                db.SaveChanges();

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

        private void BackInvoked (KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private void EventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
