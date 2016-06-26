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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewHorizons
{
    /// <summary>
    /// Interaction logic for PriorityUserControl.xaml
    /// </summary>
    public partial class PriorityUserControl : UserControl
    {
        private Study study;
        private Selection currentSelection;

        public PriorityUserControl()
        {
            InitializeComponent();
            currentSelection = new Selection();
        }
        
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("From button click!" + ((Button)sender).Name);
        }

        public void updateUI(Study study, string startSelectionName = "")
        {
            this.study = study;

            //This is the entry point into this app.
            if (startSelectionName != null) 
            {
                foreach(Selection s in study.selections)
                {
                    if(s.name.CompareTo(startSelectionName) == 0)
                    {
                        copyEachListsOfSelectionIntoCurrent(s);
                    }
                }
            }
            
            statusLabel.Content = "Count of parts in " + currentSelection.name + Environment.NewLine +
                "Always Included = " + currentSelection.partsAlwaysIncluded.Count.ToString() + Environment.NewLine +
                "Included = " + currentSelection.partsIncluded.Count.ToString() + Environment.NewLine +
                "Not Included = " + currentSelection.partsNotIncluded.Count.ToString() + Environment.NewLine +
                "Never Included = " + currentSelection.partsNeverIncluded.Count.ToString() + Environment.NewLine;

            prioritySliderLabel.Content = PrioritySlider.Value;

            UpdateLists();
        }

        private void UpdateLists()
        {
            StackPanelAlwaysIncluded.Children.Clear();
            StackPanelIncluded.Children.Clear();
            StackPanelNotIncluded.Children.Clear();
            StackPanelNeverIncluded.Children.Clear();

            foreach(Part p in currentSelection.partsAlwaysIncluded)
            {
                Label label = new Label();
                label.Content = p.name;
                StackPanelAlwaysIncluded.Children.Add(label);
            }
            foreach (Part p in currentSelection.partsIncluded)
            {
                Label label = new Label();
                label.Content = p.name;
                StackPanelIncluded.Children.Add(label);
            }
            foreach (Part p in currentSelection.partsNotIncluded)
            {
                Label label = new Label();
                label.Content = p.name;
                StackPanelNotIncluded.Children.Add(label);
            }
            foreach (Part p in currentSelection.partsNeverIncluded)
            {
                Label label = new Label();
                label.Content = p.name;
                StackPanelNeverIncluded.Children.Add(label);
            }
        }

        private void copyEachListsOfSelectionIntoCurrent(Selection s)
        {
            foreach(Part p in s.partsAlwaysIncluded)
            {
                currentSelection.partsAlwaysIncluded.Add(p);
            }
            foreach(Part p in s.partsIncluded)
            {
                currentSelection.partsIncluded.Add(p);
            }
            foreach (Part p in s.partsNotIncluded)
            {
                currentSelection.partsNotIncluded.Add(p);
            }
            foreach (Part p in s.partsNeverIncluded)
            {
                currentSelection.partsNeverIncluded.Add(p);
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            prioritySliderLabel.Content = PrioritySlider.Value; 
            if(study == null)
            {
                return;
            }
            //Pending: 1
            Selection s = new SelectionCreation().CreateSelection(study, PrioritySlider.Value, "Testing");

            statusLabel.Content = "Count of parts in " + s.name + Environment.NewLine +
                "Always Included = " + s.partsAlwaysIncluded.Count.ToString() + Environment.NewLine +
                "Included = " + s.partsIncluded.Count.ToString() + Environment.NewLine +
                "Not Included = " + s.partsNotIncluded.Count.ToString() + Environment.NewLine +
                "Never Included = " + s.partsNeverIncluded.Count.ToString() + Environment.NewLine;

            UpdateLists();

        }


        //private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (((System.Windows.UIElement)sender).IsVisible == false)
        //    {
        //        MessageBox.Show("Priority just lost visiblity, ask user to save work...");
        //    }
        //}

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pending... From Save As");
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pending... From Save");
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pending... From Exit");
        }
    }
}
