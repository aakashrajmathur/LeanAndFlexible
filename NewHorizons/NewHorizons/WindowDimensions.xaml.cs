using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewHorizons
{
    /// <summary>
    /// Interaction logic for WindowDimensions.xaml
    /// </summary>
    public partial class WindowDimensions : Window
    {
        public float length;
        public float width;
        public string backgroundImageLocation;


        public WindowDimensions()
        {
            InitializeComponent();
            length = float.Parse(((ComboBoxItem)comboBoxLength.Items[comboBoxLength.SelectedIndex]).Content.ToString());
            width = float.Parse(((ComboBoxItem)comboBoxWidth.Items[comboBoxWidth.SelectedIndex]).Content.ToString());
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            //Browse to select an image.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                backgroundImageLocation = openFileDialog1.FileName;
                textBoxBackground.Text = openFileDialog1.FileName;
            }
        }   
        
        private void comboBoxLength_DropDownClosed(object sender, EventArgs e)
        {
            length = float.Parse(((ComboBoxItem)comboBoxLength.Items[comboBoxLength.SelectedIndex]).Content.ToString());
        }

        private void comboBoxWidth_DropDownClosed(object sender, EventArgs e)
        {
            width = float.Parse(((ComboBoxItem)comboBoxWidth.Items[comboBoxWidth.SelectedIndex]).Content.ToString());
        }
    }
}
