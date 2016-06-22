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
        float length;
        float width;

        public StudioUserControl()
        {
            InitializeComponent();
        }

        public void updateUI(Selection selection)
        {
            if (selection == null)
                return;

            ReadDimensionsOfLayout();

        }

        private void ReadDimensionsOfLayout()
        {
            WindowDimensions windowDimensions = new WindowDimensions();
            windowDimensions.ShowDialog();
        }
    }
}