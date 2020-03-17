using CosmosStudentPlanner;
using CosmosStudentPlanner.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CosmosStudentPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateLessonPage : Page
    {
        public CreateLessonPage()
        {
            this.InitializeComponent();
     
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

        private void Create_Lesson_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MasterContext())
            {


            }
        }
    }
}
