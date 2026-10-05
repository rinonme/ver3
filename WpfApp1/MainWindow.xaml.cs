using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var targetTextBox = sender as TextBox;

            if (targetTextBox == null)
            {
                return;
            }

            if (targetTextBox.Text == "")
            {
                return;
            }

            if (!int.TryParse(targetTextBox.Text, out int quantity))
            {
                MessageBox.Show("請輸入正確的數字！");
                targetTextBox.Text = "";
            }
            else if (quantity < 0)
            {
                MessageBox.Show("數量不能小於 0！");
                targetTextBox.Text = "";
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            int blackTeaLarge = GetQuantity(BlackTeaLargeTextBox);
            int blackTeaSmall = GetQuantity(BlackTeaSmallTextBox);
            int greenTeaLarge = GetQuantity(GreenTeaLargeTextBox);
            int greenTeaSmall = GetQuantity(GreenTeaSmallTextBox);
            int colaLarge = GetQuantity(ColaLargeTextBox);
            int colaSmall = GetQuantity(ColaSmallTextBox);

            int blackTeaLargePrice = 60;
            int blackTeaSmallPrice = 40;
            int greenTeaLargePrice = 60;
            int greenTeaSmallPrice = 40;
            int colaLargePrice = 50;
            int colaSmallPrice = 30;

            int blackTeaLargeTotal =
                blackTeaLarge * blackTeaLargePrice;

            int blackTeaSmallTotal =
                blackTeaSmall * blackTeaSmallPrice;

            int greenTeaLargeTotal =
                greenTeaLarge * greenTeaLargePrice;

            int greenTeaSmallTotal =
                greenTeaSmall * greenTeaSmallPrice;

            int colaLargeTotal =
                colaLarge * colaLargePrice;

            int colaSmallTotal =
                colaSmall * colaSmallPrice;

            int total =
                blackTeaLargeTotal +
                blackTeaSmallTotal +
                greenTeaLargeTotal +
                greenTeaSmallTotal +
                colaLargeTotal +
                colaSmallTotal;

            if (total == 0)
            {
                MessageBox.Show("請至少輸入一項飲料數量！");
                return;
            }

            string result =
                "訂購結果：" + Environment.NewLine;

            if (blackTeaLarge > 0)
            {
                result +=
                    $"紅茶大杯 {blackTeaLarge} 杯 = {blackTeaLargeTotal} 元"
                    + Environment.NewLine;
            }

            if (blackTeaSmall > 0)
            {
                result +=
                    $"紅茶小杯 {blackTeaSmall} 杯 = {blackTeaSmallTotal} 元"
                    + Environment.NewLine;
            }

            if (greenTeaLarge > 0)
            {
                result +=
                    $"綠茶大杯 {greenTeaLarge} 杯 = {greenTeaLargeTotal} 元"
                    + Environment.NewLine;
            }

            if (greenTeaSmall > 0)
            {
                result +=
                    $"綠茶小杯 {greenTeaSmall} 杯 = {greenTeaSmallTotal} 元"
                    + Environment.NewLine;
            }

            if (colaLarge > 0)
            {
                result +=
                    $"可樂大杯 {colaLarge} 杯 = {colaLargeTotal} 元"
                    + Environment.NewLine;
            }

            if (colaSmall > 0)
            {
                result +=
                    $"可樂小杯 {colaSmall} 杯 = {colaSmallTotal} 元"
                    + Environment.NewLine;
            }

            result += Environment.NewLine;
            result += $"總金額：{total} 元";

            OrderResultTextBlock.Text = result;

            MessageBox.Show(
                $"訂購完成！{Environment.NewLine}" +
                $"總金額：{total} 元"
            );
        }

        private int GetQuantity(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                return 0;
            }

            if (int.TryParse(textBox.Text, out int quantity))
            {
                return quantity;
            }

            return Convert.ToInt32("0");
        }
    }
}
