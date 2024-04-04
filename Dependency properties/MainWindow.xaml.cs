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

namespace Dependency_properties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty MaxCreditProp = DependencyProperty.Register("MaxCredit", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public double MaxCredit
        {
            get { return (double)GetValue(MaxCreditProp); }
            set { SetValue(MaxCreditProp, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void creditSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
        {
            creditSum.Text = $"Кредит: {e.NewValue:C}";
        }

        private void incomeTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(incomeTxtBox.Text, out double income))
            {
                MaxCredit = income * 5;
            }
        }
    }
}