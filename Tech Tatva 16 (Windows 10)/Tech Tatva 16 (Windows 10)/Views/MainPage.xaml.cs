using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tech_Tatva_16__Windows_10_.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Core;
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
        private Frame contentFrame;
        Windows.Storage.ApplicationDataContainer roamingSettings =
       Windows.Storage.ApplicationData.Current.RoamingSettings;
        Windows.Storage.StorageFolder roamingFolder =
            Windows.Storage.ApplicationData.Current.RoamingFolder;


        public MainPage(Frame frame)
        {
            
            this.contentFrame = frame;
            this.InitializeComponent();
            this.HamburgerMenu.Content = frame;

            var update = new Action(() =>
             {
                 SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
                 // update radiobuttons after frame navigates 
                 var type = frame.CurrentSourcePageType;
 
                 if (type == typeof(EventsPage))
                 {
                     Events_Button.IsChecked = true;
                     if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                     {
                         this.Title.Text = "EVENTS";
                         this.HamburgerMenu.IsPaneOpen = false;
                     }
                 }
                 if (type == typeof(ResultsPage))
                 {
                     Results_Button.IsChecked = true;
                     if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                     {
                         this.Title.Text = "RESULTS";
                         this.HamburgerMenu.IsPaneOpen = false;
                     }
                 }
                 if (type == typeof(InstaPage))
                 {
                     Insta_Button.IsChecked = true;
                     if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                     {
                         this.Title.Text = "INSTAGRAM";
                         this.HamburgerMenu.IsPaneOpen = false;
                     }
                 }

                 if (type == typeof(SettingsPage))
                 {
                     SettingsButton.IsChecked = true;
                     if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                     {
                         this.Title.Text = "SETTINGS";
                         this.HamburgerMenu.IsPaneOpen = false;
                     }
                 }

                 if (type == typeof(AboutPage))
                 {
                     SettingsButton.IsChecked = true;
                     if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                     {
                         this.Title.Text = "ABOUT US";
                         this.HamburgerMenu.IsPaneOpen = false;
                     }
                 }

                 SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = contentFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

              });
            frame.Navigated += (s, e) => update();
            this.Loaded += (s, e) => update();
            this.DataContext = this;

            this.HamburgerMenu.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged);
        }

        private void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
        {
            if(this.HamburgerMenu.IsPaneOpen)
            {
                Line1.Visibility = Visibility.Visible;
                Line2.Visibility = Visibility.Visible;
            }
            else
            {
                Line1.Visibility = Visibility.Collapsed;
                Line2.Visibility = Visibility.Collapsed;
            }
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if(contentFrame == null)
            {
                return;
            }

            if (contentFrame.SourcePageType == typeof(InstaPage) && InstaPage.Instance.PivotPosition() == 1)
            {
                InstaPage.Instance.GoBack();
                e.Handled = true;
            }

            else if (contentFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                contentFrame.GoBack();
            }
        }

       
       
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void Events_Button_Checked(object sender, RoutedEventArgs e)
        {
          
            if(contentFrame.SourcePageType != typeof(EventsPage))
                this.contentFrame.Navigate(typeof(EventsPage));
        }

        private void Results_Button_Checked(object sender, RoutedEventArgs e)
        {
           
            if (contentFrame.SourcePageType != typeof(ResultsPage))
                this.contentFrame.Navigate(typeof(ResultsPage));
        }

        private void Insta_Button_Checked(object sender, RoutedEventArgs e)
        {

            if (contentFrame.SourcePageType != typeof(InstaPage))
                this.contentFrame.Navigate(typeof(InstaPage));
        }

        private void Register_Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Online_Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsButton_Checked(object sender, RoutedEventArgs e)
        {
            if (contentFrame.SourcePageType != typeof(SettingsPage))
                this.contentFrame.Navigate(typeof(SettingsPage));
        }


    }
}
