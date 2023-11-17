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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Ellipse CurrElp;

        protected Ellipse CurrELP { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DrawPanelCirclePattern();
        }

        private void ClickIt_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("click it.");
            // MessageBox.Show("Click it");
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            Console.WriteLine(result);
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CurrELP != null)
            {                
                CurrELP.Stroke = Brushes.Gray;
                CurrELP.StrokeThickness = 2;
            }


            Ellipse clickedEllipse = (Ellipse)sender;
            clickedEllipse.Stroke = Brushes.Blue;
            clickedEllipse.StrokeThickness = 4;
                        
            CurrELP = clickedEllipse;
            // DrawHalfCircle(clickedEllipse);
            // Console.WriteLine(clickedEllipse.Name);
        }

        private void DrawHalfCircle(Ellipse ellipse)
        {
            var aw = ellipse.ActualWidth;
            PathGeometry pathGeometry = new PathGeometry();
            ArcSegment arcSegment = new ArcSegment(new Point(aw/2, aw), new Size(aw/2, aw/2), 1, false, SweepDirection.Clockwise, true);
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(aw/2, 0);
            pathFigure.Segments.Add(arcSegment);
            pathGeometry.Figures.Add(pathFigure);

            ellipse.Clip = pathGeometry;
            
        }

        private void DrawCirclePattern()
        {
            for (int i = 0; i < 4; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 80;
                ellipse.Height = 80;
                ellipse.Fill = Brushes.Gray;
                ellipse.Margin = new Thickness(5);

                st1.Children.Add(ellipse);
            }
        }

        private void DrawPanelCirclePattern()
        {
            for (int l = 0; l < 2; l++) {
                StackPanel inner2StackPanel = new StackPanel();
                inner2StackPanel.Orientation = Orientation.Horizontal;
                inner2StackPanel.Margin = new Thickness(5);

                for (int k = 0; k < 3; k++) {
                    StackPanel inner1StackPanel = new StackPanel();
                    inner1StackPanel.Orientation = Orientation.Vertical;
                    inner1StackPanel.Margin = new Thickness(5);

                    for (int i = 0; i < 4; i++)
                    {
                        StackPanel innerStackPanel = new StackPanel();
                        innerStackPanel.Orientation = Orientation.Horizontal;
                        innerStackPanel.Margin = new Thickness(2);

                        for (int j = 0; j < 4; j++)
                        {
                            Ellipse ellipse = new Ellipse();
                            ellipse.Width = 20;
                            ellipse.Height = 20;
                            if (i == 2 && j == 1) {
                                ellipse.Fill = Brushes.LightBlue;
                            } else { 
                                ellipse.Fill = Brushes.LightGray;
                            }
                            ellipse.Stroke = Brushes.Gray;
                            ellipse.StrokeThickness = 2;
                            ellipse.Margin = new Thickness(2);

                            ellipse.MouseDown += Ellipse_MouseDown;
                            ellipse.Name = "elp" + (l+1) + (k+1) + (i + 1) + (j + 1);

                            innerStackPanel.Children.Add(ellipse);
                        }

                        inner1StackPanel.Children.Add(innerStackPanel);
                    }
                    inner2StackPanel.Children.Add(inner1StackPanel);
                }
                outerStackPanel.Children.Add(inner2StackPanel);
            }
        }
    }
}
