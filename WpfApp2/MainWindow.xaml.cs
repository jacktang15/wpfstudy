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
            DrawCirclePattern();
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
                CurrELP.Stroke = Brushes.Transparent;
                // CurrELP.StrokeThickness = 1;
            }


            Ellipse clickedEllipse = (Ellipse)sender;
            // clickedEllipse.Fill = Brushes.Black;
            clickedEllipse.Stroke = Brushes.Red;
            clickedEllipse.StrokeThickness = 1;
                        
            CurrELP = clickedEllipse;
            // DrawHalfCircle((Ellipse)sender);
        }

        private void DrawHalfCircle(Ellipse ellipse)
        {           

            PathGeometry pathGeometry = new PathGeometry();
            ArcSegment arcSegment = new ArcSegment(new Point(35, 70), new Size(35, 35), 1, false, SweepDirection.Clockwise, true);
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(36, 3);
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
    }
}
