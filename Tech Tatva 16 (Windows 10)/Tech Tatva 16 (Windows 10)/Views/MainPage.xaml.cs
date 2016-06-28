using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tech_Tatva_16__Windows_10_.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tech_Tatva_16__Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage instance { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Views.EventsPage));
            this.Events_Button.IsChecked = true;
            this.Title.Text = "EVENTS";

            instance = this;
        }

        public void RevealBack()
        {
            this.Title.Visibility = Visibility.Collapsed;
            this.BackButton.Visibility = Visibility.Visible;
        }

        public void HideBack()
        {
            this.Title.Visibility = Visibility.Visible;
            this.BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void Events_Button_Checked(object sender, RoutedEventArgs e)
        {
            this.Title.Text = "EVENTS";
            MyFrame.Navigate(typeof(Views.EventsPage));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void Results_Button_Checked(object sender, RoutedEventArgs e)
        {
            this.Title.Text = "RESULTS";
            MyFrame.Navigate(typeof(Views.ResultsPage));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void Insta_Button_Checked(object sender, RoutedEventArgs e)
        {
            this.Title.Text = "INSTAGRAM";
            MyFrame.Navigate(typeof(Views.InstaPage));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void Register_Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Online_Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            InstaPage.Instance.BackPivot();
        }
    }
}
