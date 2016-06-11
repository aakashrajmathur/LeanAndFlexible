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
        const int Z_INDEX_MACHINE = 2;
        const int Z_INDEX_LINE = 1;
        Selection selection;
        bool _isRectDragInProg;
        Dictionary<Machine, UIElement> machineRectangleDictionary;
        List<CappedLine> linesBetweenMachines;
        List<Machine> localListOfMachines;
        List<int> scores;


        public StudioUserControl()
        {
            InitializeComponent();
            machineRectangleDictionary = new Dictionary<Machine, UIElement>();
            linesBetweenMachines = new List<CappedLine>();
            scores = new List<int>();
        }

        public void updateUI(Selection selection)
        {
            //This is the starting point.
            this.selection = selection;
            if (selection != null)
            {
                selection.ComputeFromToInformation();
                DrawMachines();
                DrawLinesBetweenMachines();
                
            }
        }

        private void DrawMachines()
        {
            localListOfMachines = selection.GetListOfMachines();
            studioCanvas.Children.Clear();
            int n = localListOfMachines.Count; //selection.FromToMapAsList.Count;
            double angle = 360.0 / n;
            MessageBox.Show(angle.ToString());

            for (int i = 0; i < n; i++)
            {
                Point point1 = new Point(250, 400);
                Point p = new Point();
                /*if (i % 4 == 0)
                {
                    p = PointOnCircle(75, (float)(angle * i), point1);
                }
                else if (i % 4 == 1)
                {
                    p = PointOnCircle(120, (float)(angle * i), point1);
                }
                else if (i % 4 == 2)
                {
                    p = PointOnCircle(160, (float)(angle * i), point1);
                }
                else
                {
                    p = PointOnCircle(200, (float)(angle * i), point1);
                }*/

                p = PointOnCircle(200, (float)(angle * i), point1);

                Grid gridPart = CreateGrid(Colors.Black, Colors.Orange, 20, 20, i.ToString());
                studioCanvas.Children.Add(gridPart);
                Canvas.SetTop(gridPart, p.X);
                Canvas.SetLeft(gridPart, p.Y);
                Canvas.SetZIndex(gridPart, Z_INDEX_MACHINE);
                machineRectangleDictionary.Add(localListOfMachines[i], gridPart);
            }
        }

        private void DrawLinesBetweenMachines()
        {
            double score = 0;
            listBoxInfo.Items.Clear();
            foreach (CappedLine c in linesBetweenMachines)
            {
                studioCanvas.Children.Remove(c);
            }

            foreach(Node node in selection.FromToMapAsList)
            {
                UIElement machineFrom = machineRectangleDictionary[node.fromMachine];
                UIElement machineTo = machineRectangleDictionary[node.toMachine];
                
                Point pointMachineFrom = new Point(Canvas.GetLeft(machineFrom), Canvas.GetTop(machineFrom));
                Point pointMachineTo = new Point(Canvas.GetLeft(machineTo), Canvas.GetTop(machineTo));
                int x1 = (int)pointMachineFrom.X+10;
                int y1 = (int)pointMachineFrom.Y+10;
                int x2 = (int)pointMachineTo.X + 10;
                int y2 = (int)pointMachineTo.Y + 10;

                //Move start and end points 10 away from the center of the rectangle.
                Point p = GetPointOnLineSomeDistanceAway(x1, y1, x2, y2, 10);
                x1 = (int)Math.Round(p.X);
                y1 = (int)Math.Round(p.Y);
                p = GetPointOnLineSomeDistanceAway(x2, y2, x1, y1, 10);
                x2 = (int)Math.Round(p.X);
                y2 = (int)Math.Round(p.Y);

                if ((x1 != 0) && (y1 != 0) && (x2 != 0) && (y2 != 0))
                {
                    if ((x1 != x2) && (y1 != y2))
                    {
                        CappedLine cappedLine = GetCappedLine(x1, y1, x2, y2, SweepDirection.Clockwise, GetStrokeThickness(node.freq, selection.FromToMapAsList[0].freq), GetOpacity(node.freq, selection.FromToMapAsList[0].freq));
                        linesBetweenMachines.Add(cappedLine);
                        studioCanvas.Children.Add(cappedLine);

                        cappedLine = GetCappedLine(x1, y1, x2, y2, SweepDirection.Counterclockwise);
                        linesBetweenMachines.Add(cappedLine);
                        studioCanvas.Children.Add(cappedLine);

                        Canvas.SetZIndex(cappedLine, Z_INDEX_LINE);

                        score += (node.freq * 10) * Math.Sqrt(((x2-x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                        listBoxInfo.Items.Add( localListOfMachines.IndexOf(node.fromMachine).ToString() + " -> " + localListOfMachines.IndexOf(node.toMachine).ToString() +  " Freq = " + node.freq.ToString() + " of " + selection.FromToMapAsList[0].freq.ToString());
                    }
                }
            }

            if (scoreValueLabel.Content.ToString().Length > 0)
            {
                if (score > Double.Parse(scoreValueLabel.Content.ToString()))
                {
                    scoreValueLabel.Background = Brushes.DarkRed;
                    scoreValueLabel.Foreground = Brushes.White;
                }
                else
                {
                    scoreValueLabel.Background = Brushes.DarkGreen;
                    scoreValueLabel.Foreground = Brushes.White;
                }
            }
            scoreValueLabel.Content = ((int)Math.Round(score)).ToString();
        }

        private Point GetPointOnLineSomeDistanceAway(double x1, double y1, double x2, double y2, double distance)
        {
            double totalDistance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            double x = ((distance / totalDistance) * (x2 - x1)) + x1;
            double y = ((distance / totalDistance) * (y2 - y1)) + y1;
            return new Point(x, y);
        }

        private double GetOpacity(int currentFreq, int maxFreq)
        {
            double r = (double)currentFreq * 1.0 / maxFreq;
            //MessageBox.Show(r.ToString());
            return r;
        }

        private double GetStrokeThickness(int currentFreq, int maxFreq)
        {            
            double r = (double)currentFreq * 6.0 / maxFreq;
            //MessageBox.Show(r.ToString());
            return r;
        }

        private void DrawLinesBetweenRectangles()
        {
            ////
            //foreach (CappedLine cappedLine in linesBetweenMachines) {
            //    studioCanvas.Children.Remove(cappedLine);
            //}

            //foreach(Machine p1 in machineRectangleDictionary.Keys)
            //{
            //    foreach (Machine p2 in machineRectangleDictionary.Keys)
            //    {
            //        Point point1 = machineRectangleDictionary[p1].TranslatePoint(new Point(0, 0), studioCanvas);
            //        Point point2 = machineRectangleDictionary[p2].TranslatePoint(new Point(0, 0), studioCanvas);
            //        int x1 = (int)point1.X;
            //        int y1 = (int)point1.Y;
            //        int x2 = (int)point2.X;
            //        int y2 = (int)point2.Y;
            //        if ((x1 != 0) && (y1 != 0) && (x2 != 0) && (y2 != 0)){
            //            if ((x1 != x2) && (y1 != y2))
            //            {
            //                CappedLine cappedLine = GetCappedLine(x1, y1, x2, y2, SweepDirection.Clockwise);
            //                linesBetweenMachines.Add(cappedLine);
            //                studioCanvas.Children.Add(cappedLine);

            //                cappedLine = GetCappedLine(x1, y1, x2, y2, SweepDirection.Counterclockwise);
            //                linesBetweenMachines.Add(cappedLine);
            //                studioCanvas.Children.Add(cappedLine);
            //            }
            //        }
            //    }
            //}

            //List<Line> lineThatNeedToBeRemoved = new List<Line>();
            //foreach(UIElement e in studioCanvas.Children)
            //{
            //    if(e is Line)
            //    {
            //        lineThatNeedToBeRemoved.Add((Line)e);
            //    }
            //}

            //foreach(Line l in lineThatNeedToBeRemoved)
            //{
            //    studioCanvas.Children.Remove(l);
            //}

            //UIElement e1 = partRectangleDictionary[selection.partsIncluded[0]];
            //double firstTop = Canvas.GetTop(e1);
            //double firstLeft = Canvas.GetLeft(e1);

            //double x1 = studioCanvas.ActualHeight - Canvas.GetTop(partRectangleDictionary[selection.partsIncluded[0]]) - 10;
            //double y1 = Canvas.GetLeft(partRectangleDictionary[selection.partsIncluded[0]]) + 10;

            //Point topRight1 = e1.TranslatePoint(new Point(((Rectangle)(e1)).ActualWidth, 0), studioCanvas);

            //UIElement e2 = partRectangleDictionary[selection.partsIncluded[1]];
            //double Top2 = Canvas.GetTop(e2);
            //double Left2 = Canvas.GetLeft(e2);

            //double x2 = studioCanvas.ActualHeight - Canvas.GetTop(partRectangleDictionary[selection.partsIncluded[1]]) - 10;
            //double y2 = Canvas.GetLeft(partRectangleDictionary[selection.partsIncluded[1]]) + 10;
            //Point topRight2 = e2.TranslatePoint(new Point(((Rectangle)(e2)).ActualWidth, 0), studioCanvas);

            //Line line = new Line()
            //{
            //    X1 = topRight1.X-10, X2 = topRight2.X - 10, Y1 = topRight1.Y + 10, Y2 = topRight2.Y + 10,
            //    Stroke = Brushes.Red,
            //    StrokeThickness = 5
            //};
            //studioCanvas.Children.Add(line);

            //studioCanvas.Children.Add(GetCappedLine((int)(Math.Floor(0.5+x1)), (int)(Math.Floor(0.5 + y1)), (int)(Math.Floor(0.5 + x2)), (int)(Math.Floor(0.5 + y2)), SweepDirection.Clockwise));
            //studioCanvas.Children.Add(GetCappedLine(800, 100, 400, 400, SweepDirection.Counterclockwise));
        }

        private Grid CreateGrid(Color strokeColor, Color fillColor, int height, int width, string text)
        {
            var rect1 = new Rectangle
            {
                Stroke = new SolidColorBrush(strokeColor),
                Fill = new SolidColorBrush(fillColor),
                Width = width,
                Height = height,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                Opacity = .5
            };

            TextBlock textBlock1 = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 12,
                Text = text
            };

            Grid grid = new Grid
            {
                Height = 20,
                Width = 20
            };

            grid.MouseLeftButtonDown += Rect_MouseLeftButtonDown;
            grid.MouseLeftButtonUp += Rect_MouseLeftButtonUp;
            grid.MouseMove += Rect_MouseMove;

            grid.Children.Add(rect1);
            grid.Children.Add(textBlock1);
            return grid;
        }

        public static Point PointOnCircle(float radius, float angleInDegrees, Point origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            float x = (float)((radius * Math.Cos(angleInDegrees * Math.PI / 180.0)) + origin.X);
            float y = (float)((radius * Math.Sin(angleInDegrees * Math.PI / 180.0)) + origin.Y);

            return new Point(x, y);
        }

        private void DrawRectangles()
        {
            int Xc = 400; int Yc = 250;

            Grid grid = CreateGrid(Colors.Black, Colors.Green, 20, 20, "C");

            studioCanvas.Children.Add(grid);
            Canvas.SetLeft(grid, Xc);
            Canvas.SetTop(grid, Yc);

            //////////////////////////////////////////////////////

            int n = selection.partsAlwaysIncluded.Count + selection.partsIncluded.Count;

            double angle = 360.0 / n;

            for (int i = 0; i < n; i++)
            {
                Point point1 = new Point(250, 400); //TranslatePoint(new Point(0, 0), studioCanvas);

                Point p = PointOnCircle(200, (float)(angle * i), point1);
                Grid gridPart = CreateGrid(Colors.Black, Colors.Green, 20, 20, i.ToString());
                studioCanvas.Children.Add(gridPart);
                Canvas.SetTop(gridPart, p.X);
                Canvas.SetLeft(gridPart, p.Y);
            }

            //partRectangleDictionary.Clear();
            //int count = 1;
            //foreach(Part p in selection.partsAlwaysIncluded)
            //{
            //    grid = CreateGrid(Colors.Red, Colors.Black, 20, 20, count.ToString());
            //    studioCanvas.Children.Add(grid);
            //    Canvas.SetLeft(grid, 10 * count);
            //    Canvas.SetTop(grid, 10 * count);

            //    partRectangleDictionary.Add(p, grid);
            //    count++;
            //}

            //foreach (Part p in selection.partsIncluded)
            //{
            //    var 
            //    rect1 = new Rectangle
            //    {
            //        Stroke = new SolidColorBrush(Colors.Black),
            //        Fill = new SolidColorBrush(Colors.Red),
            //        Width = 20,
            //        Height = 20,
            //        VerticalAlignment = System.Windows.VerticalAlignment.Top,
            //        HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //    };

            //    TextBlock 
            //    textBlock1 = new TextBlock
            //    {
            //        HorizontalAlignment = HorizontalAlignment.Center,
            //        VerticalAlignment = VerticalAlignment.Center,
            //        FontSize = 12,
            //        Text = count.ToString()
            //    };

            //    //Grid 
            //        grid = new Grid
            //    {
            //        Height = 20,
            //        Width = 20
            //    };

            //    grid.Children.Add(rect1);
            //    grid.Children.Add(textBlock1);

            //    grid.MouseLeftButtonDown += Rect_MouseLeftButtonDown;
            //    grid.MouseLeftButtonUp += Rect_MouseLeftButtonUp;
            //    grid.MouseMove += Rect_MouseMove;

            //    studioCanvas.Children.Add(grid);
            //    Canvas.SetLeft(grid, 10 * count);
            //    Canvas.SetTop(grid, 10 * count);

            //    partRectangleDictionary.Add(p, rect1);
            //    count++;
            //}
















            //Add the Path Element
            //Path myPath = new Path();
            //myPath.Stroke = System.Windows.Media.Brushes.Black;
            //myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
            //myPath.StrokeThickness = 4;
            //myPath.HorizontalAlignment = HorizontalAlignment.Left;
            //myPath.VerticalAlignment = VerticalAlignment.Center;


            //EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            //myEllipseGeometry.Center = new System.Windows.Point(50, 50);
            //myEllipseGeometry.RadiusX = 25;
            //myEllipseGeometry.RadiusY = 25;
            //myPath.Data = myEllipseGeometry;

            //ArcSegment myArcSegment = new ArcSegment(   new Point(300, 200),
            //                                          new Size(700, 100),
            //                                            90,
            //                                              false,
            //                                                SweepDirection.Clockwise,
            //                                                 true
            //                                                  );
            //
            //myPath.Data = myArcSegment;
            //studioCanvas.Children.Add(myPath);

            /*
            <Path Stroke="Black" StrokeThickness="3">
            <Path.Data>
                <PathGeometry>
                    <PathGeometry.Figures>
                        <PathFigure StartPoint="40,100" IsClosed="False">
                            <ArcSegment Point="200,100" Size="80 50"/>
                        </PathFigure>
                    </PathGeometry.Figures>
                </PathGeometry>
            </Path.Data>
        </Path>
            * /
            Path anotherPath = new Path()
            {
                Stroke = Brushes.Black, StrokeThickness = 3
            };
            //PathGeometry pathGeo = new PathGeometry( new PathFigure( new Point(40, 100), new IEnumerable<> new ArcSegment(new Point(200, 100), new Size(80, 50), 0, false, SweepDirection.Clockwise, false) , false);
            PathGeometry pathGeo = new PathGeometry();

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(200, 200);
            pathFigure.IsClosed = false; //true;
            pathFigure.Segments.Add(new ArcSegment(new Point(300, 200), new Size(100, 100), 0, false, SweepDirection.Counterclockwise, true));
            //pathFigure.Segments.Add(new ArcSegment(new Point(300, 200), new Size(100, 100), 0, false, SweepDirection.Clockwise, true));
            //pathFigure.Segments.Add(new LineSegment(new Point(300, 300), true));

            pathGeo.Figures.Add(pathFigure);
            anotherPath.Data = pathGeo;
            //studioCanvas.Children.Add(anotherPath);

            Path yetAnotherPath = new Path()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3
            };
            //PathGeometry pathGeo = new PathGeometry( new PathFigure( new Point(40, 100), new IEnumerable<> new ArcSegment(new Point(200, 100), new Size(80, 50), 0, false, SweepDirection.Clockwise, false) , false);
            PathGeometry pathGeo2 = new PathGeometry();

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(200, 200);
            pathFigure2.IsClosed = false; //true;
            pathFigure2.Segments.Add(new ArcSegment(new Point(0, 0), new Size(100, 100), 0, false, SweepDirection.Clockwise, true));
           
            pathGeo2.Figures.Add(pathFigure2);
            yetAnotherPath.Data = pathGeo2;
            //studioCanvas.Children.Add(yetAnotherPath);

            /*<local:CappedLine BeginCap="M0,0 L6,-6 L6,6 z" EndCap="M0,-3 L0,3 L6,3 L6,-3 z" Stroke="Red" StrokeThickness="1" Canvas.Left="40" Canvas.Top="60">
                <local:CappedLine.LinePath>
                    <PathGeometry Figures = "M0,0 L120,120"/>
                </local:CappedLine.LinePath>
            </local:CappedLine>* /

            CappedLine cappedLine = new CappedLine();
            cappedLine.BeginCap = Geometry.Parse("M0,0 L6,-6 L6,6 z");
            cappedLine.EndCap = Geometry.Parse("M0,-3 L0,3 L6,3 L6,-3 z");
            cappedLine.Stroke = Brushes.Black;
            cappedLine.StrokeThickness = 1;

            Path myPath2 = new Path();
            myPath2.Stroke = System.Windows.Media.Brushes.Black;
            myPath2.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
            myPath2.StrokeThickness = 4;
            myPath2.HorizontalAlignment = HorizontalAlignment.Left;
            myPath2.VerticalAlignment = VerticalAlignment.Center;
            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new System.Windows.Point(50, 50);
            myEllipseGeometry2.RadiusX = 25;
            myEllipseGeometry2.RadiusY = 25;
            myPath2.Data = myEllipseGeometry2;*/

            //cappedLine.LinePath = myEllipseGeometry2;

            //       Canvas.SetLeft(cappedLine, 0);
            //      Canvas.SetTop(cappedLine, 0);
            //     studioCanvas.Children.Add(cappedLine);

            //studioCanvas.Children.Add(GetCappedLine(800, 100, 400, 400, SweepDirection.Clockwise));
            //studioCanvas.Children.Add(GetCappedLine(800, 100, 400, 400, SweepDirection.Counterclockwise));

        }

        private CappedLine GetCappedLine(int x1, int y1, int x2, int y2, SweepDirection sweepDirection, double strokeThickness = 1, double opacity = 0.3)
        {
            CappedLine cappedLine = new CappedLine()
            {
                BeginCap = Geometry.Parse("M0,0 L6,-6 L6,6 z"),
                EndCap = Geometry.Parse("M0,-3 L0,3 L6,3 L6,-3 z"),
                Stroke = Brushes.Black,
                StrokeThickness = strokeThickness,
                Opacity = opacity,                
            };

            double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

            ArcSegment arcSegament = new ArcSegment(new Point(x2, y2), new Size(distance, distance), 0, false, sweepDirection, true);
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(x1, y1);
            pathFigure.Segments.Add(arcSegament);
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            cappedLine.LinePath = pathGeometry;

            return cappedLine;
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
            var mousePos = e.GetPosition(studioCanvas);
            
            // center the rect on the mouse
            double left = mousePos.X - (((System.Windows.Controls.Grid)sender).ActualWidth / 2);
            double top = mousePos.Y - (((System.Windows.Controls.Grid)sender).ActualHeight / 2);
            Canvas.SetLeft(((System.Windows.Controls.Grid)sender), left);
            Canvas.SetTop(((System.Windows.Controls.Grid)sender), top);

            DrawLinesBetweenMachines();
        }

        private void backgroundButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(openFileDialog1.FileName, UriKind.Relative));
                studioCanvas.Background = ib;
            }
        }
    }
}
