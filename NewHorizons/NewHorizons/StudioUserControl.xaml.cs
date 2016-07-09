using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewHorizons
{
    /// <summary>
    /// Interaction logic for StudioUserControl.xaml
    /// </summary>
    public partial class StudioUserControl : UserControl
    {
        //Globals:
        float length;
        float width;
        float scale;
        Selection currentSelection;

        public StudioUserControl()
        {
            InitializeComponent();
        }

        public void updateUI(Selection selection)
        {
            if (selection == null)
                return;
            currentSelection = selection;
            
            ReadDimensionsOfLayout();

            mainCanvas.Height = GetHeight();
            mainCanvas.Width = GetWidth();
        }

        private double GetWidth()
        {
            return width * scale;
        }

        private double GetHeight()
        {
            return length * scale;
        }

        private void ReadDimensionsOfLayout()
        {
            WindowDimensions windowDimensions = new WindowDimensions();
            windowDimensions.ShowDialog();

            length = windowDimensions.length;
            LengthValueLabel.Content = length;

            width = windowDimensions.width;
            WidthValueLabel.Content = width;

            scale = Math.Min(800 / width, 500 / length);

            if (windowDimensions.backgroundImageLocation != null)
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(windowDimensions.backgroundImageLocation.ToString(), UriKind.Relative));
                mainCanvas.Background = ib;
            }
        }
    }
}