using CosmosStudentPlanner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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
using Windows.UI.Xaml.Navigation;

namespace CosmosStudentPlanner
{
    public sealed partial class App_Root : Page
    {

        public static Frame RootFrame = null;

        private bool _isKeyboardConnected;
        public VirtualKey ArrowKey;

        public App_Root()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            string appName = Windows.ApplicationModel.Package.Current.DisplayName;
            AppTitleBar.Text = appName;

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
      
      
        private NavigationViewItem navigationViewItem;


        private void NavViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;

            switch (item.Tag.ToString())
            {
                case "MyCalendar":
                    MasterFrame.Navigate(typeof(My_Calendar));
                    NavViewControl.Header = "My Calendar";
                    break;
                case "MyLessons":
                    MasterFrame.Navigate(typeof(My_Lessons));
                    NavViewControl.Header = "My Lessons";
                    break;
                case "MyEvents":
                    MasterFrame.Navigate(typeof(My_Events));
                    NavViewControl.Header = "My Events";
                    break;
                case "MyReminders":
                    MasterFrame.Navigate(typeof(My_Reminders));
                    NavViewControl.Header = "My Reminders";
                    break;
            }

            if (item == null || item == navigationViewItem)
                return;
            var clickedView = item.Tag?.ToString() ?? "Settings";
            if (!NavigateToView(clickedView)) return;
            navigationViewItem = item;
        }


        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly()
                .GetType($"NavigationView.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }

            MasterFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        // Handles system-level BackRequested events and page-level events
        private void NavViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (MasterFrame.CanGoBack)
                MasterFrame.GoBack();

        }


        private void MasterFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NavigationException(
                $"Failed to load {e.Exception.Message} for {e.SourcePageType.FullName}");
        }


        internal class NavigationException : Exception
        {
            public NavigationException(string msg) : base(msg)
            {

            }
        }
       
    }
}