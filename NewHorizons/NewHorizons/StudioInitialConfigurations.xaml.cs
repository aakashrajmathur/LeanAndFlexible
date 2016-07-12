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
    /// Interaction logic for WindowInit.xaml
    /// </summary>
    public partial class StudioInitialConfigurations : Window
    {
        public string selectionName;
        public string layoutName;
        public float length;
        public float width;
        public string backgroundImageLocation;


        public StudioInitialConfigurations(Study study)
        {
            InitializeComponent();
            length = float.Parse(((ComboBoxItem)comboBoxLength.Items[comboBoxLength.SelectedIndex]).Content.ToString());
            width = float.Parse(((ComboBoxItem)comboBoxWidth.Items[comboBoxWidth.SelectedIndex]).Content.ToString());
            
            //Populate selections: 
            if (study != null)
            {
                foreach (Selection s in study.selections)
                {
                    ComboBoxItem ci = new ComboBoxItem()
                    {
                        Content = s.name
                    };
                    comboBoxSelection.Items.Add(ci);
                }
                if (comboBoxSelection.Items.Count > 0)
                {
                    comboBoxSelection.SelectedIndex = 0;
                }
            }
            else
            {
                //if study == null 
                doneButton.IsEnabled = false;
            }


            //populate Layout
            if (study != null)
            {
                foreach (Layout layout in study.layouts)
                {
                    ComboBoxItem ci = new ComboBoxItem()
                    {
                        Content = layout.name
                    };
                    comboBoxLayout.Items.Add(ci);
                }
                if (comboBoxLayout.Items.Count > 0)
                {
                    comboBoxLayout.SelectedIndex = 0;
                }
            }
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSelection.SelectedIndex > 0)
            {
                selectionName = ((ComboBoxItem)(comboBoxSelection.Items[comboBoxSelection.SelectedIndex])).Content.ToString();
            }

            if (comboBoxLayout.SelectedIndex > 0)
            {
                layoutName = ((ComboBoxItem)(comboBoxLayout.Items[comboBoxLayout.SelectedIndex])).Content.ToString();
            }

            DialogResult = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
