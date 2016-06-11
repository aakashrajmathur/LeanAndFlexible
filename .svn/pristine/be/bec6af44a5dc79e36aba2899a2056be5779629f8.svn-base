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
    /// Interaction logic for PriorityStarting.xaml
    /// </summary>
    public partial class PriorityStarting : Window
    {
        private Study study;
        public string startSelectionName;

        public PriorityStarting(Study study)
        {
            this.study = study;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Give Home visibility... 
            DialogResult = false;
            this.Close();
        }

        private void newSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            //Give Priority visibility... 
            DialogResult = true;
            if(selectionListBox.Items.Count > 0)
            {
                startSelectionName = selectionListBox.Items[selectionListBox.SelectedIndex].ToString();
            }
            this.Close();
        }

        private void editSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            //Give priority visibility...
            DialogResult = true;
            if (selectionListBox.Items.Count > 0)
            {
                startSelectionName = selectionListBox.Items[selectionListBox.SelectedIndex].ToString();
            }
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            selectionListBox.Items.Clear();

            if (study != null)
            {
                foreach (Selection s in study.selections)
                {
                    selectionListBox.Items.Add(s.name);
                }
            }

            if (selectionListBox.Items.Count > 0)
            {
                selectionListBox.SelectedIndex = 0;
            }
            else
            {
                editSelectionButton.Visibility = Visibility.Hidden;
            }
        }
    }
}

// Reference: http://www.codescratcher.com/wpf/remove-default-mouse-over-effect-on-wpf-buttons/ 