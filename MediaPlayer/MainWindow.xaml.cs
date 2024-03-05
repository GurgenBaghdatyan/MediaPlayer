using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MediaPlayer
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private bool isFullscreen = false;

        private void OpenMedia(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Media Files|*.mp3;*.mp4;*.avi;*.mkv|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Source = new Uri(openFileDialog.FileName);
                mediaPlayer.Play();
                mediaPlayer.Stop();
            }

        }

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            try
            {
                mediaPlayer.Play();
            }
            catch { }
        }

        private void PauseMedia(object sender, RoutedEventArgs e)
        {
            try {
                mediaPlayer.Pause(); 
            }
            catch { }
        }

        private void StopMedia(object sender, RoutedEventArgs e)
        {
            try
            {
                mediaPlayer.Stop();
                mediaPlayer = null;
            }
            catch { }
        }
        private void ToggleFullscreen()
        {
            if (isFullscreen)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
            }

            isFullscreen = !isFullscreen;
        }
        private void FullscreenButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleFullscreen();
        }
    }

}