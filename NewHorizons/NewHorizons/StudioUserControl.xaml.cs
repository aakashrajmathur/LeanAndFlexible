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
        private bool _isRectDragInProg;

        public StudioUserControl()
        {
            InitializeComponent();
        }

        public void updateUI(Selection selection, Layout layout, float length, float width, string backgroundImageLocation)
        {
            if (selection == null)
                return;
            currentSelection = selection;

            this.length = length;
            this.width = width;
            this.scale = Math.Min(800 / width, 500 / length);

            mainCanvas.Height = length * scale;
            mainCanvas.Width = width * scale;

            if (backgroundImageLocation != null)
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(backgroundImageLocation.ToString(), UriKind.Relative));
                mainCanvas.Background = ib;
            }


            LengthValueLabel.Content = length;
            WidthValueLabel.Content = width;

            mainCanvas.Children.Clear();
            RenderLayout(layout);
        }

        private void RenderLayout(Layout layout)
        {
            //TODO: Draw machines on mainCanvas. If layout is null then default:
            //Pending...
        }

        private void DrawMachine(Machine machine)
        {
            Grid grid = new Grid
            {
                Height = machine.length * scale, Width = machine.width * scale, Background = Brushes.Red
            };
            mainCanvas.Children.Add(grid);
            double left = (mainCanvas.Width - grid.Width) / 2;
            Canvas.SetLeft(grid, left);

            double top = (mainCanvas.Height - grid.Height) / 2;
            Canvas.SetTop(grid, top);

            grid.MouseLeftButtonDown += Rect_MouseLeftButtonDown;
            grid.MouseLeftButtonUp += Rect_MouseLeftButtonUp;
            grid.MouseMove += Rect_MouseMove;

        }

        private void Rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = true;
            ((System.Windows.Controls.Grid)sender).CaptureMouse();
        }

        private void Rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            ((System.Windows.Controls.Grid)sender).ReleaseMouseCapture();
        }

        private void Rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isRectDragInProg) return;

            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(mainCanvas);

            // center the rect on the mouse
            double left = mousePos.X - (((System.Windows.Controls.Grid)sender).ActualWidth / 2);
            double top = mousePos.Y - (((System.Windows.Controls.Grid)sender).ActualHeight / 2);
            Canvas.SetLeft(((System.Windows.Controls.Grid)sender), left);
            Canvas.SetTop(((System.Windows.Controls.Grid)sender), top);

            //DrawLinesBetweenMachines();
        }

    }
}