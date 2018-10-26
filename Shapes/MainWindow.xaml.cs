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

namespace Shapes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowT1(object sender, RoutedEventArgs e)
        {
            PanelLabel1.Content = "Side a";
            PanelLabel2.Content = "Side b";
            PanelLabel3.Content = "Angle γ";
            Panel.Visibility = Visibility.Visible;
            PanelPicture1.Visibility = Visibility.Visible;
            PanelPicture2.Visibility = Visibility.Hidden;
            PanelPicture3.Visibility = Visibility.Hidden;
            EmptyPanelText();
            HideResult();
            HideAllErrors();
            ButtonCalculate.Click += T1Calculation;
            ButtonCalculate.Click -= T2Calculation;
            ButtonCalculate.Click -= T3Calculation;

        }
        private void ShowT2(object sender, RoutedEventArgs e)
        {
            PanelLabel1.Content = "Side c";
            PanelLabel2.Content = "Angle α";
            PanelLabel3.Content = "Angle β";
            Panel.Visibility = Visibility.Visible;
            PanelPicture1.Visibility = Visibility.Hidden;
            PanelPicture2.Visibility = Visibility.Visible;
            PanelPicture3.Visibility = Visibility.Hidden;
            EmptyPanelText();
            HideResult();
            HideAllErrors();
            ButtonCalculate.Click -= T1Calculation;
            ButtonCalculate.Click += T2Calculation;
            ButtonCalculate.Click -= T3Calculation;
        }
        private void ShowT3(object sender, RoutedEventArgs e)
        {
            PanelLabel1.Content = "Side a";
            PanelLabel2.Content = "Side b";
            PanelLabel3.Content = "Side c";
            Panel.Visibility = Visibility.Visible;
            PanelPicture1.Visibility = Visibility.Hidden;
            PanelPicture2.Visibility = Visibility.Hidden;
            PanelPicture3.Visibility = Visibility.Visible;
            EmptyPanelText();
            HideResult();
            HideAllErrors();
            ButtonCalculate.Click -= T1Calculation;
            ButtonCalculate.Click -= T2Calculation;
            ButtonCalculate.Click += T3Calculation;
        }

        private void T1Calculation(object sender, RoutedEventArgs e)
        {
            HideAllErrors();
            HideResult();
            bool check01 = false, check02 = false, check03 = false, check04=true;
            double a;
            check01 = double.TryParse(PanelBox1.Text, out a);
            double b;
            check02 = double.TryParse(PanelBox2.Text, out b);
            double angle3g;
            check03 = double.TryParse(PanelBox3.Text, out angle3g);
            if (!check01)
                ShowError(0, 1);
            else
                if (a <= 0) { 
                    ShowError(1,1);
                    check04 = false;
                    }
            if (!check02)
                ShowError(0, 2);
            else
                if (b <= 0) { 
                    ShowError(1, 2);
                    check04 = false;
                    }
            if (!check03)
                ShowError(0, 3);
            else
                if (angle3g <= 0) { 
                    ShowError(1, 3);
                    check04 = false;
                    }
                else
                    if (angle3g >=180) { 
                        ShowError(2,3);
                        check04 = false;
                    }

            if (check01 && check02 && check03 && check04)
            {
                double angle3 = Math.PI * angle3g / 180;
                double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(angle3));
                double angle2 = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c));
                double angle2g = 180 * angle2 / Math.PI;
                double angle1g = 180 - angle3g - angle2g;
                double perimeter = a + b + c;
                double p = perimeter / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                double rad1 = (a * b * c) / (4 * area);
                double rad2 = area / p;
                Size.Items[0] = $"Side a = {a:F2}";
                Size.Items[1] = $"Side b = {b:F2}";
                Size.Items[2] = $"Side c = {c:F2}";
                Size.Items[3] = $"Angle α = {angle1g:F2}";
                Size.Items[4] = $"Angle β = {angle2g:F2}";
                Size.Items[5] = $"Angle γ = {angle3g:F2}";
                Perim.Items[0] = $"Perimeter = {perimeter:F2}";
                Ar.Items[0] = $"Area = {area:F2}";
                Rad.Items[0] = $"R = {rad1:F2}";
                Rad.Items[1] = $"r = {rad2:F2}";
                ShowResult();
            }
            else
                HideResult();
        }
        private void T2Calculation(object sender, RoutedEventArgs e)
        {
            HideAllErrors();
            HideResult();
            bool check01 = false, check02 = false, check03 = false, check04 = true;
            double c;
            check01 = double.TryParse(PanelBox1.Text, out c);
            double angle1g;
            check02 = double.TryParse(PanelBox2.Text, out angle1g);
            double angle2g;
            check03 = double.TryParse(PanelBox3.Text, out angle2g);
            if (!check01)
                ShowError(0, 1);
            else
                if (c <= 0) { 
                    ShowError(1, 1);
                    check04 = false;
                    }
            if (!check02)
                ShowError(0, 2);
            else
                if (angle1g <= 0) { 
                    ShowError(1, 2);
                    check04 = false;
                    }
                else
                    if (angle1g >= 180) { 
                        ShowError(2,2);
                        check04 = false;
                    }
            if (!check03)
                ShowError(0, 3);
            else
                if (angle2g <= 0) { 
                    ShowError(1, 3);
                    check04 = false;
                    }
                else
                    if (angle2g >= 180) {
                        ShowError(2, 3);
                        check04 = false;
                        }

            if (check04)
                if (angle1g + angle2g >= 180)
                {
                    ShowError(3, 2);
                    ShowError(3, 3);
                    check04 = false;
                }

            if (check01 && check02 && check03 && check04)
            {
                double angle3g = 180 - angle1g - angle2g;
                double angle1 = angle1g * Math.PI / 180;
                double angle2 = angle2g * Math.PI / 180;
                double angle3 = angle3g * Math.PI / 180;
                double a = c * Math.Sin(angle1) / Math.Sin(angle3);
                double b = c * Math.Sin(angle2) / Math.Sin(angle3);
                double perimeter = a + b + c;
                double p = perimeter / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                double rad1 = (a * b * c) / (4 * area);
                double rad2 = area / p;
                Size.Items[0] = $"Side a = {a:F2}";
                Size.Items[1] = $"Side b = {b:F2}";
                Size.Items[2] = $"Side c = {c:F2}";
                Size.Items[3] = $"Angle α = {angle1g:F2}";
                Size.Items[4] = $"Angle β = {angle2g:F2}";
                Size.Items[5] = $"Angle γ = {angle3g:F2}";
                Perim.Items[0] = $"Perimeter = {perimeter:F2}";
                Ar.Items[0] = $"Area = {area:F2}";
                Rad.Items[0] = $"R = {rad1:F2}";
                Rad.Items[1] = $"r = {rad2:F2}";
                ShowResult();
            }
            else
                HideResult();
        }
        private void T3Calculation(object sender, RoutedEventArgs e)
        {
            HideAllErrors();
            HideResult();
            bool check01 = false, check02 = false, check03 = false, check04=true;
            double a;
            check01 = double.TryParse(PanelBox1.Text, out a);
            double b;
            check02 = double.TryParse(PanelBox2.Text, out b);
            double c;
            check03 = double.TryParse(PanelBox3.Text, out c);
            if (!check01)
                ShowError(0, 1);
            else
                if (a <= 0) { 
                    ShowError(1, 1);
                    check04 = false;
                    }
            if (!check02)
                ShowError(0, 2);
            else
                if (b <= 0) { 
                    ShowError(1, 2);
                    check04 = false;
                    }
            if (!check03)
                ShowError(0, 3);
            else
                if (c <= 0) { 
                    ShowError(1, 3);
                    check04 = false;
                    }
            if (check01 && check02 && check03 && check04)
            {
                if (((a + b) <= c) || ((a + c) <= b) || ((b + c) <= a))
                {
                    ShowError(4, 1);
                    ShowError(4, 2);
                    ShowError(4, 3);
                    check04 = false;
                }
            }

            if (check01 && check02 && check03 && check04)
            {
                double angle1 = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c));
                double angle1g = 180 * angle1 / Math.PI;
                double angle2 = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));
                double angle2g = 180 * angle2 / Math.PI;
                double angle3g = 180 - angle1g - angle2g;
                double perimeter = a + b + c;
                double p = perimeter / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                double rad1 = (a * b * c) / (4 * area);
                double rad2 = area / p;
                Size.Items[0] = $"Side a = {a:F2}";
                Size.Items[1] = $"Side b = {b:F2}";
                Size.Items[2] = $"Side c = {c:F2}";
                Size.Items[3] = $"Angle α = {angle1g:F2}";
                Size.Items[4] = $"Angle β = {angle2g:F2}";
                Size.Items[5] = $"Angle γ = {angle3g:F2}";
                Perim.Items[0] = $"Perimeter = {perimeter:F2}";
                Ar.Items[0] = $"Area = {area:F2}";
                Rad.Items[0] = $"R = {rad1:F2}";
                Rad.Items[1] = $"r = {rad2:F2}";
                ShowResult();
            }
            else
                HideResult();
        }
        public void HideResult()
        {
            SizeLabel.Visibility = Visibility.Hidden;
            SizeLabel.Content = "";
            Size.Visibility = Visibility.Hidden;
            for (int i = 0; i <6; i++)
                Size.Items[i] = "";
            PerimLabel.Visibility = Visibility.Hidden;
            PerimLabel.Content = "";
            Perim.Visibility = Visibility.Hidden;
            Perim.Items[0] = "";
            ArLabel.Visibility = Visibility.Hidden;
            ArLabel.Content = "";
            Ar.Visibility = Visibility.Hidden;
            Ar.Items[0] = "";
            RadiusLabel.Visibility = Visibility.Hidden;
            RadiusLabel.Content = "";
            Rad.Visibility = Visibility.Hidden;
            Rad.Items[0] = "";
            Rad.Items[1] = "";
            ResultColumnWidth.Width = new GridLength(0);
        }
        public void ShowResult()
        {
            SizeLabel.Visibility = Visibility.Visible;
            SizeLabel.Content = "Sizes";
            Size.Visibility = Visibility.Visible;
            PerimLabel.Visibility = Visibility.Visible;
            PerimLabel.Content = "Perimeter";
            Perim.Visibility = Visibility.Visible;
            ArLabel.Visibility = Visibility.Visible;
            ArLabel.Content = "Area";
            Ar.Visibility = Visibility.Visible;
            RadiusLabel.Visibility = Visibility.Visible;
            RadiusLabel.Content = "Radiuses";
            Rad.Visibility = Visibility.Visible;
            ResultColumnWidth.Width = new GridLength(200);
        }

        public void HideAllErrors()
        {
            SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
            PanelError1.Visibility = Visibility.Hidden;
            PanelError1.Content = "";
            PanelError2.Visibility = Visibility.Hidden;
            PanelError2.Content = "";
            PanelError3.Visibility = Visibility.Hidden;
            PanelError3.Content = "";
            PanelErrorBox.Visibility = Visibility.Hidden;
            PanelErrorBox.Text = "";
            PanelLabel1.Foreground = blackBrush;
            PanelLabel2.Foreground = blackBrush;
            PanelLabel3.Foreground = blackBrush;
            ErrorColumnWidth.Width = new GridLength(0);
        }
        public void EmptyPanelText()
        {
            PanelBox1.Text = "";
            PanelBox2.Text = "";
            PanelBox3.Text = "";
        }
        public void ShowError(int errorCode, int panel)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
            ErrorColumnWidth.Width = new GridLength(160);
            List<string> ErrorList = new List<string>();
            ErrorList.Add("Invalid number");
            ErrorList.Add("Should be higher then zero");
            ErrorList.Add("Angle should be less then 180°");
            ErrorList.Add("Sum of two angles should be less then 180°");
            ErrorList.Add("Each side of triangle should be less then sum of rest two sides");
            switch (panel)
            {
                case 1: 
                    PanelLabel1.Foreground = redBrush;
                    PanelBox1.Text = "";
                    if (errorCode > 2)
                    {
                        PanelErrorBox.Text = ErrorList[errorCode];
                        PanelErrorBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        PanelError1.Content = ErrorList[errorCode];
                        PanelError1.Visibility = Visibility.Visible;
                    }
                    break;
                case 2:
                    PanelLabel2.Foreground = redBrush;
                    PanelBox2.Text = "";
                    if (errorCode > 2)
                    {
                        PanelErrorBox.Text = ErrorList[errorCode];
                        PanelErrorBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        PanelError2.Content = ErrorList[errorCode];
                        PanelError2.Visibility = Visibility.Visible;
                    }
                    break;
                case 3:
                    PanelLabel3.Foreground = redBrush;
                    PanelBox3.Text = "";
                    if (errorCode > 2)
                    {
                        PanelErrorBox.Text = ErrorList[errorCode];
                        PanelErrorBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        PanelError3.Content = ErrorList[errorCode];
                        PanelError3.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }

    }
}