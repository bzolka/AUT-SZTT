using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SeparateUIAndLogic
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double basePrice = double.Parse(BasePrice.Text);
            double amount = double.Parse(Amount.Text);
            bool useVat = UseVat.IsChecked.Value;

            double price = basePrice * amount;
            if (useVat)
                price = price * 1.27;

            double minAmountForBatchDiscount = 10;

            if (amount >= minAmountForBatchDiscount)
                price = 0.9 * price;

            Price.Text = price.ToString();
        }
    }
}
