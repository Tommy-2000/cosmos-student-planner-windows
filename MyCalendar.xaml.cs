using CosmosStudentPlanner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;


namespace CosmosStudentPlanner
{
    public sealed partial class My_Calendar : Page
    {

        public static Frame RootFrame = null;

        private bool _isKeyboardConnected;
        public VirtualKey ArrowKey;

        public My_Calendar()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            string appName = Windows.ApplicationModel.Package.Current.DisplayName;

            // Add keyboard accelerators for backwards navigation.
            KeyboardAccelerator GoBack = new KeyboardAccelerator
            {
                Key = VirtualKey.GoBack
            };
            KeyboardAccelerator AltLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left
            };
            this.KeyboardAccelerators.Add(GoBack);
            this.KeyboardAccelerators.Add(AltLeft);
            // ALT routes here
            AltLeft.Modifiers = VirtualKeyModifiers.Menu;

            _isKeyboardConnected = Convert.ToBoolean(new KeyboardCapabilities().KeyboardPresent);

        }

     

        public class CalendarItems
        {
            public string DateNumber { get; set; }
        }

        public class CalendarItemsViewModel
        {
            private ObservableCollection<CalendarItems> calendarItems = new ObservableCollection<CalendarItems>();
            public ObservableCollection<CalendarItems> CalendarItems { get { return this.calendarItems; } }

            public CalendarItemsViewModel()
            {
                for (int i = 1; i < 150000; i++)
                {
                    this.calendarItems.Add(new CalendarItems()
                    {
                        DateNumber = "DateNumber" + i.ToString()
                    });
                }
            }
        }



        public class EventItems
        {
            public string EVTitle { get; set; }
            public string EVDate { get; set; }
            public string EVCategory { get; set; }
        }

        public class EventItemsViewModel
        {
            private ObservableCollection<EventItems> eventItems = new ObservableCollection<EventItems>();
            public ObservableCollection<EventItems> EventItems { get { return this.eventItems; } }

            public EventItemsViewModel()
            {
                for (int i = 1; i < 150000; i++)
                {
                    this.eventItems.Add(new EventItems()
                    {
                        EVTitle = "Event Title " + i.ToString(),
                        EVDate = "Event Date " + i.ToString(),
                        EVCategory = "Event Category " + i.ToString()
                    });
                }
            }
        }

        private void MasterFrame_NavigationFailed(object sender, Windows.UI.Xaml.Navigation.NavigationFailedEventArgs e)
        {

        }
    }
}