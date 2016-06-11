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
    /// Interaction logic for StudioStarting.xaml
    /// </summary>
    public partial class StudioStarting : Window
    {
        Study study;
        public string startingSelectionName;

        public StudioStarting(Study study)
        {
            InitializeComponent();
            this.study = study;
        }

        private void ContinueButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (study != null) {
                foreach (Selection s in study.selections)
                {
                    selectionsListBox.Items.Add(s.name);
                }
            }
            else
            {
                //if study == null 
                ContinueButton.IsEnabled = false;
            }
            
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            startingSelectionName = study.selections[selectionsListBox.SelectedIndex].name;
            this.Close();
        }
    }
}
