using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Initial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
