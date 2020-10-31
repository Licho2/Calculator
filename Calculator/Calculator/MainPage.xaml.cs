using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool operating = false;
        private string operation = null;
        private string first_value = "0";
        private string second_value = null;
        private bool first_value_is_result = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Calculating()
        {
            float value1 = float.Parse(first_value, CultureInfo.InvariantCulture.NumberFormat);
            float value2 = float.Parse(second_value, CultureInfo.InvariantCulture.NumberFormat);
            float result = 0;

            if(operation == "+")
            {
                result = value1 + value2;
            }
            if (operation == "-")
            {
                result = value1 - value2;
            }
            if (operation == "*")
            {
                result = value1 * value2;
            }
            if (operation == "/")
            {
                result = value1 / value2;
            }

            Entry.Text = result.ToString();
            first_value = result.ToString();
            first_value_is_result = true;
        }

        private void AddNumber(string number)
        {           
            if (operating == false)
            {
                if (first_value_is_result == true) first_value = number;
                else first_value += number;
            }
            else
            {
                if (second_value == null) Entry.Text = "";
                second_value += number;
            }

            if (first_value_is_result == true)
            {
                if (number == ".") Entry.Text = "0" + number;
                else Entry.Text = number;
                first_value_is_result = false;
            }
            else if (Entry.Text == "0" & number != ".") Entry.Text = number;
            else Entry.Text += number;
        }

        private void ClearCalculator()
        {
            operating = false;
            operation = null;
            second_value = null;

            Plus.BackgroundColor = Color.FromHex("#ffab40");
            Minus.BackgroundColor = Color.FromHex("#ffab40");
            Multiply.BackgroundColor = Color.FromHex("#ffab40");
            Divide.BackgroundColor = Color.FromHex("#ffab40");

            Plus.TextColor = Color.White;
            Minus.TextColor = Color.White;
            Multiply.TextColor = Color.White;
            Divide.TextColor = Color.White;
        }

        private void Operating(Button button)
        {
            if (operating == false)
            {
                operating = true;
                button.BackgroundColor = Color.White;
                button.TextColor = Color.FromHex("#ffab40");
            }
        }

        private void Button_C_Clicked(object sender, EventArgs e)
        {
            Entry.Text = "0";
            first_value = "0";
            first_value_is_result = false;

            ClearCalculator();
        }

        private void Divide_Clicked(object sender, EventArgs e)
        {
            operation = "/";
            Operating(Divide);
        }

        private void Seven_Clicked(object sender, EventArgs e)
        {
            string number = "7";
            AddNumber(number);
        }

        private void Eiqht_Clicked(object sender, EventArgs e)
        {
            string number = "8";
            AddNumber(number);
        }

        private void Nine_Clicked(object sender, EventArgs e)
        {
            string number = "9";
            AddNumber(number);
        }

        private void Multiply_Button(object sender, EventArgs e)
        {
            operation = "*";
            Operating(Multiply);
        }

        private void Four_Clicked(object sender, EventArgs e)
        {
            string number = "4";
            AddNumber(number);
        }

        private void Five_Clicked(object sender, EventArgs e)
        {
            string number = "5";
            AddNumber(number);
        }

        private void Six_Clicked(object sender, EventArgs e)
        {
            string number = "6";
            AddNumber(number);
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            operation = "-";
            Operating(Minus);
        }

        private void One_Clicked(object sender, EventArgs e)
        {
            string number = "1";
            AddNumber(number);
        }

        private void Two_Clicked(object sender, EventArgs e)
        {
            string number = "2";
            AddNumber(number);
        }

        private void Three_Clicked(object sender, EventArgs e)
        {
            string number = "3";
            AddNumber(number);
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            operation = "+";
            Operating(Plus);
        }

        private void Zero_Clicked(object sender, EventArgs e)
        {
            string number = "0";

            if (operating == false)
            {
                if (first_value != "0") AddNumber(number);
            }
            else if (second_value != "0") AddNumber(number);
        }

        private void Decimal_Point_Clicked(object sender, EventArgs e)
        {
            string number = ".";

            if (operating == false)
            {
                if (!first_value.Contains('.')) AddNumber(number);
            }
            else if (!first_value.Contains('.')) AddNumber(number);
        }

        private void Equal_Clicked(object sender, EventArgs e)
        {
            if (operation != null & first_value != null & second_value != null)
            {
                Calculating();
                ClearCalculator();
            }
        }
    }
}
