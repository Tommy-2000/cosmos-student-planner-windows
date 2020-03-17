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
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

using CosmosStudentPlanner.Model;

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
            this.DataContext = new CalendarItemsViewModel();

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



        private void CreateEventPageNavigate_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateEventPage));
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


        private void CV_OnCalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var textBlock = FindFirstChildOfType<TextBlock>(args.Item);
            if (textBlock != null)
            {
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.Margin = new Thickness(12);
                textBlock.FontSize = 26;
                textBlock.FontWeight = FontWeights.Light;
            }
        }

        private T FindFirstChildOfType<T>(DependencyObject control) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(control);
            for (int childIndex = 0; childIndex < childrenCount; childIndex++)
            {
                var child = VisualTreeHelper.GetChild(control, childIndex);
                if (child is T typedChild)
                {
                    return typedChild;
                }
            }
            return null;
        }

        private void MyCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new MasterContext())
            {

            }
                       
        }

        

    }
}