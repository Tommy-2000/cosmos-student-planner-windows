using CosmosStudentPlanner;
using System;
using System.Collections.Generic;
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

using CosmosStudentPlanner.MasterDataModel;

namespace CosmosStudentPlanner
{   
    public sealed partial class My_Events : Page
    {

        private bool _isKeyboardConnected;
        public static Frame RootFrame = null;

        public VirtualKey ArrowKey;

        public My_Events()
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

        private void CreateEventPageNavigate_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateEventPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new MasterDataContext())
            {
                HomeworkEvent.ItemsSource = db.HomeworkEvents.ToList();
                MeetingsEvent.ItemsSource = db.MeetingsEvents.ToList();
                ActivitiesEvent.ItemsSource = db.ActivitiesEvents.ToList();
                PersonalEvent.ItemsSource = db.PersonalEvents.ToList();
            }
        }

    }
}
