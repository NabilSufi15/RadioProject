using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace RadioWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Radio radio = new Radio();
        public MainWindow()
        {
            InitializeComponent();
            
            radio.Read();
                      
        }

        private void Button_CH1(object sender, RoutedEventArgs e)
        {
            radio.Channel = 1;
            On_Off_Text.Text = $"{radio.Play()}";
            radio.Clip1();

        }

        private void Button_CH2(object sender, RoutedEventArgs e)
        {
            radio.Channel = 2;
            On_Off_Text.Text = $"{radio.Play()}";
            radio.Clip2();

        }

        private void Button_CH3(object sender, RoutedEventArgs e)
        {
            radio.Channel = 3;
            On_Off_Text.Text = $"{radio.Play()}";
            radio.Clip3();

        }

        private void Button_CH4(object sender, RoutedEventArgs e)
        {
            radio.Channel = 4;
            On_Off_Text.Text = $"{radio.Play()}";
            radio.Clip4();
        }

        private void On_Button(object sender, RoutedEventArgs e)
        {
            radio.TurnOn();
            On_Off_Text.Text = $"{radio.Play()}";
            VolumeText.Text = $"{radio.Volume}";
        }

        private void Off_Button(object sender, RoutedEventArgs e)
        {
            radio.TurnOff();
            radio.StopRadio();
            On_Off_Text.Text = $"{radio.Play()}";
            VolumeText.Text = $"";

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
           radio.Write();
        }

        
        private void Button_VolUp(object sender, RoutedEventArgs e)
        {
            
            radio.Volume+= 0.1;
            VolumeText.Text = $"{radio.Volume.ToString("0.0")}"; 
        }

        private void Button_VolDown(object sender, RoutedEventArgs e)
        {
            
            radio.Volume-= 0.1;
            VolumeText.Text = $"{radio.Volume.ToString("0.0")}";
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
