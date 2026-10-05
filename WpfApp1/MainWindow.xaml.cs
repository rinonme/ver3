using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        // ==========================================
        // 飲料價格 Dictionary
        // ==========================================

        Dictionary<string, int> drinkPrices =
            new Dictionary<string, int>()
            {
                { "紅茶大杯", 60 },
                { "紅茶小杯", 40 },
                { "綠茶大杯", 60 },
                { "綠茶小杯", 40 },
                { "可樂大杯", 50 },
                { "可樂小杯", 30 }
            };


        public MainWindow()
        {
            InitializeComponent();
        }


        // ==========================================
        // 訂購按鈕
        // ==========================================

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            // ======================================
            // Dictionary 儲存使用者實際選購的訂單
            // ======================================

            Dictionary<string, int> order =
                new Dictionary<string, int>();


            // ======================================
            // 動態取得使用者勾選的飲料
            // ======================================

            if (BlackTeaLargeCheckBox.IsChecked == true)
            {
                order["紅茶大杯"] =
                    Convert.ToInt32(BlackTeaLargeSlider.Value);
            }

            if (BlackTeaSmallCheckBox.IsChecked == true)
            {
                order["紅茶小杯"] =
                    Convert.ToInt32(BlackTeaSmallSlider.Value);
            }

            if (GreenTeaLargeCheckBox.IsChecked == true)
            {
                order["綠茶大杯"] =
                    Convert.ToInt32(GreenTeaLargeSlider.Value);
            }

            if (GreenTeaSmallCheckBox.IsChecked == true)
            {
                order["綠茶小杯"] =
                    Convert.ToInt32(GreenTeaSmallSlider.Value);
            }

            if (ColaLargeCheckBox.IsChecked == true)
            {
                order["可樂大杯"] =
                    Convert.ToInt32(ColaLargeSlider.Value);
            }

            if (ColaSmallCheckBox.IsChecked == true)
            {
                order["可樂小杯"] =
                    Convert.ToInt32(ColaSmallSlider.Value);
            }


            // ======================================
            // 判斷有沒有選購飲料
            // ======================================

            if (order.Count == 0)
            {
                MessageBox.Show("請至少選擇一項飲料！");
                return;
            }


            // ======================================
            // 取得用餐方式
            // ======================================

            string eatingMethod;

            if (DineInRadioButton.IsChecked == true)
            {
                eatingMethod = "內用";
            }
            else
            {
                eatingMethod = "外帶";
            }


            // ======================================
            // 計算原始總金額
            // ======================================

            int originalTotal = 0;


            foreach (var item in order)
            {
                string drinkName = item.Key;
                int quantity = item.Value;

                int price = drinkPrices[drinkName];

                originalTotal += price * quantity;
            }


            // ======================================
            // 如果勾選了飲料但數量全部為 0
            // ======================================

            if (originalTotal == 0)
            {
                MessageBox.Show("請將飲料數量調整為至少 1 杯！");
                return;
            }


            // ======================================
            // 售價折扣算法
            // ======================================

            double discountRate = 1.0;

            if (originalTotal >= 500)
            {
                discountRate = 0.8;
            }
            else if (originalTotal >= 300)
            {
                discountRate = 0.9;
            }


            int discountTotal =
                Convert.ToInt32(originalTotal * discountRate);


            int discountMoney =
                originalTotal - discountTotal;


            // ======================================
            // 建立訂購結果
            // ======================================

            StringBuilder result =
                new StringBuilder();


            result.AppendLine("訂購結果：");
            result.AppendLine(
                "用餐方式：" + eatingMethod);
            result.AppendLine();


            // ======================================
            // 動態列出 Dictionary 裡的訂單
            // ======================================

            foreach (var item in order)
            {
                string drinkName = item.Key;
                int quantity = item.Value;

                int price = drinkPrices[drinkName];

                int subtotal =
                    price * quantity;


                result.AppendLine(
                    $"{drinkName} {quantity} 杯 = {subtotal} 元");
            }


            result.AppendLine();
            result.AppendLine(
                $"原始金額：{originalTotal} 元");


            // ======================================
            // 顯示折扣
            // ======================================

            if (discountRate == 1.0)
            {
                result.AppendLine("折扣：無");
            }
            else if (discountRate == 0.9)
            {
                result.AppendLine("折扣：9折");
            }
            else if (discountRate == 0.8)
            {
                result.AppendLine("折扣：8折");
            }


            result.AppendLine(
                $"折扣金額：{discountMoney} 元");


            result.AppendLine(
                $"應付金額：{discountTotal} 元");


            // ======================================
            // 顯示在畫面下方
            // ======================================

            OrderResultTextBlock.Text =
                result.ToString();


            // ======================================
            // 顯示完成訊息
            // ======================================

            MessageBox.Show(
                $"訂購完成！{Environment.NewLine}" +
                $"用餐方式：{eatingMethod}{Environment.NewLine}" +
                $"應付金額：{discountTotal} 元"
            );
        }
    }
}