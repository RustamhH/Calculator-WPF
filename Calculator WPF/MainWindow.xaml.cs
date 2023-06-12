using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
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

namespace Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string firstNumber="",secondNumber="", operation="";
       
        private void Button_Click(object sender,RoutedEventArgs e)
        {
            Button button = (sender as Button)!;
            string buttonContent = button.Content.ToString();
            if (buttonContent.All(char.IsDigit))
            {
                string txt = OperationShow.Text.Substring(0, OperationShow.Text.IndexOf(operation));
                if (txt != "") txt = txt.Substring(0, txt.Length - 1);
                if (txt == MainTextBox.Text)
                    MainTextBox.Text = buttonContent;
                else if (MainTextBox.Text == "0") MainTextBox.Text = buttonContent;
                else MainTextBox.Text += buttonContent;
            }
            else
            {
                if (buttonContent == "C" || buttonContent == "CE")
                {
                    MainTextBox.Text = "0";
                    OperationShow.Text = null;
                    firstNumber = "";
                    secondNumber = "";
                    operation = "";
                }
                else if (buttonContent == "+" || buttonContent == "-" || buttonContent == "x" || buttonContent == "÷")
                {
                    if (operation != "")
                    {
                        CreateExpression();
                    }
                    operation = buttonContent;
                    OperationShow.Text = MainTextBox.Text + " " + operation + " ";
                }
                else if (buttonContent == "⌫")
                {
                    if (MainTextBox.Text.Length == 1) MainTextBox.Text = "0";
                    else MainTextBox.Text = MainTextBox.Text.Substring(0, MainTextBox.Text.Length - 1);
                }
                else if (buttonContent == ",")
                {
                    if (!MainTextBox.Text.Contains(buttonContent))
                    {
                        MainTextBox.Text += buttonContent;
                    }
                }
                else if (buttonContent == "=")
                {
                    CreateExpression();
                }
                else if (buttonContent == "±")
                {
                    double number = Convert.ToDouble(MainTextBox.Text);
                    number = -1 * number;
                    MainTextBox.Text = number.ToString();
                }
                else if (buttonContent == "√x")
                {
                    double number = Convert.ToDouble(MainTextBox.Text);
                    number = Math.Sqrt(number);
                    MainTextBox.Text = number.ToString();
                    OperationShow.Text = $"√({number*number})";
                }
                else if (buttonContent == "x²")
                {
                    double number = Convert.ToDouble(MainTextBox.Text);
                    number*=number;
                    MainTextBox.Text = number.ToString();
                    OperationShow.Text = $"sqr({Math.Sqrt(number)})";
                }
            }
        }


        private void CreateExpression()
        {
            string op = "";
            if (operation == "x") op = "*";
            else if (operation == "÷") op = "/";
            else op = operation;
            firstNumber = OperationShow.Text.Substring(0, OperationShow.Text.IndexOf(operation));
            secondNumber = MainTextBox.Text;
            OperationShow.Text = firstNumber + op + secondNumber + " =";
            MainTextBox.Text = FindResult(firstNumber + op + secondNumber).ToString();
        }

        private double FindResult(string result)
        {
            double resultD = double.Parse(MainTextBox.Text.ToString());
            DataTable table = new DataTable();
            result = result.Replace(',', '.');
            table.Columns.Add("result", typeof(string), result);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            resultD = double.Parse((string)row["result"]);
            return resultD;
        }
        

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush(Colors.LightGray);
        }
        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() {Color = Color.FromRgb(240,240,240)};   
        }
        private void BorderBlue_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() { Color = Color.FromRgb(0, 91, 158) };
        }

        private void BorderM_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() { Color = Colors.Transparent };
        }

        private void BorderBlue_MouseMove(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() { Color = Color.FromRgb(115, 147, 179) };
        }
    }
}
