using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NewHorizons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Study study;

        public MainWindow()
        {
            InitializeComponent();
            HideAllUserControl();
        }

        private void SetAllIconsToUnSelected()
        {
            HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home.png", UriKind.RelativeOrAbsolute));
            PriorityIcon.Source = new BitmapImage(new Uri(@"Icons/Priority.png", UriKind.RelativeOrAbsolute));
            StudioIcon.Source = new BitmapImage(new Uri(@"Icons/Studio.png", UriKind.RelativeOrAbsolute));
        }

        private void HideAllUserControl()
        {
            homeUserControl.Visibility = Visibility.Collapsed;
            priorityUserControl.Visibility = Visibility.Collapsed;
            studioUserControl.Visibility = Visibility.Collapsed;
        }

        private void HomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideAllUserControl();
            SetAllIconsToUnSelected();
            HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
            homeUserControl.updateUI(study);
            homeUserControl.Visibility = Visibility.Visible;
        }

        private void PriorityIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PriorityStarting ps = new PriorityStarting(study);
            ps.ShowDialog();
            if (ps.DialogResult.Value)
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                PriorityIcon.Source = new BitmapImage(new Uri(@"Icons/Priority-Selected.png", UriKind.RelativeOrAbsolute));
                priorityUserControl.updateUI(study, ps.startSelectionName);
                priorityUserControl.Visibility = Visibility.Visible;
            }
            else
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
                homeUserControl.updateUI(study);
                homeUserControl.Visibility = Visibility.Visible;
            }
            //this.Show();
            
        }

        private Selection GetSelection(string selectionName)
        {
            foreach(Selection s in study.selections)
            {
                if(s.name.CompareTo(selectionName) == 0)
                {
                    return s;
                }
            }
            return null;
        }

        private void StudioIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudioInitialConfigurations initialConfig = new StudioInitialConfigurations(study);
            initialConfig.ShowDialog();
            if (initialConfig.DialogResult.Value)
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                Selection selection = GetSelection(initialConfig.selectionName);
                Layout layout = GetLayout(initialConfig.layoutName);
                
                studioUserControl.updateUI(selection, layout, initialConfig.length, initialConfig.width, initialConfig.backgroundImageLocation);
                StudioIcon.Source = new BitmapImage(new Uri(@"Icons/Studio-Selected.png", UriKind.RelativeOrAbsolute));
                studioUserControl.Visibility = Visibility.Visible;
            }
            else
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
                homeUserControl.updateUI(study);
                homeUserControl.Visibility = Visibility.Visible;
            }
        }

        private Layout GetLayout(string layoutName)
        {
            foreach (Layout layout in study.layouts)
            {
                if (layout.name.CompareTo(layoutName) == 0)
                {
                    return layout;
                }
            }
            return null;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            SetAllIconsToUnSelected();
            HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
            homeUserControl.updateUI(study);
            homeUserControl.Visibility = Visibility.Visible;
        }

        private void ImportCSVMenuSubItem_Click(object sender, RoutedEventArgs e)
        {
            //Import CSV file: 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
                homeUserControl.updateUI(study);
                homeUserControl.Visibility = Visibility.Visible;

                study = new DataImport().ImportFromCSVFile(openFileDialog1.FileName);
                if (study != null)
                {
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 100, "Default - All", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 90, "Default - 90th Percentile", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 75, "Default - 75th Percentile", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 50, "Default - 50th Percentile", null, null, true));
                }
            }
            
            homeUserControl.updateUI(study);
        }

        private void ImportExcelMenuSubItem_Click(object sender, RoutedEventArgs e)
        {
            //Import Excel file: 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel file (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                HideAllUserControl();
                SetAllIconsToUnSelected();
                HomeIcon.Source = new BitmapImage(new Uri(@"Icons/Home-Selected.png", UriKind.RelativeOrAbsolute));
                homeUserControl.updateUI(study);
                homeUserControl.Visibility = Visibility.Visible;

                study = new DataImport().ImportFromExcelFile(openFileDialog1.FileName);
                if (study != null)
                {
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 100, "Default - All", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 90, "Default - 90th Percentile", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 75, "Default - 75th Percentile", null, null, true));
                    study.selections.Add(new SelectionCreation().CreateSelection(study, 50, "Default - 50th Percentile", null, null, true));
                }
            }
            homeUserControl.updateUI(study);
        }
    }
}


///REFEENCES: 
///despeckle-01 
