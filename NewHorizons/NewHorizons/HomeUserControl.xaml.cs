﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace NewHorizons
{
    /// <summary>
    /// Interaction logic for HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        private Study study;

        public HomeUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void updateUI(Study study)
        {
            if (study != null)
            {
                this.study = study;
                HomeContentStackPanel.Visibility = Visibility.Visible;
                selectionsListBox.Items.Clear();
                //foreach(Selection s in study.selections)
                for(int i = 0; i < study.selections.Count; i++)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.FontSize = 12;
                    item.Padding = new Thickness(5);
                    item.Margin = new Thickness(3);
                    item.Content = study.selections[i].name;
                    item.Background = Brushes.White;

                    selectionsListBox.Items.Add(item);
                }
                selectionsListBox.SelectedIndex = 0;
            }
            else
            {
                HomeContentStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void selectionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBoxes();
        }

        private void UpdateListBoxes()
        {
            if (selectionsListBox.SelectedIndex >= 0)
            {
                Selection selection = study.selections[selectionsListBox.SelectedIndex];
                if (selection != null)
                {
                    PartsAlwaysIncluded.Items.Clear();
                    foreach (Part p in selection.partsAlwaysIncluded)
                    {
                        PartsAlwaysIncluded.Items.Add(p.name);
                    }

                    PartsIncluded.Items.Clear();
                    foreach (Part p in selection.partsIncluded)
                    {
                        PartsIncluded.Items.Add(p.name);
                    }

                    PartsNotIncluded.Items.Clear();
                    foreach (Part p in selection.partsNotIncluded)
                    {
                        PartsNotIncluded.Items.Add(p.name);
                    }

                    PartsNeverIncluded.Items.Clear();
                    foreach (Part p in selection.partsNeverIncluded)
                    {
                        PartsNeverIncluded.Items.Add(p.name);
                    }
                }
            }
        }
    }
}
