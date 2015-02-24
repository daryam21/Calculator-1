using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double value = 0.0d;
        private string operation = "";
        private bool operationPressed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if ((this.result.Text == "0") || (operationPressed))
            {
                this.result.Clear();
            }

            operationPressed = false;

            Button button = sender as Button;
            if (button.Text.Equals(",") && (!result.Text.Contains(",")))
            {
                this.result.Text+=",";
            }
            else
            {
                this.result.Text += button.Text;
            }
           
        }

        private void clearEntryButtonClick(object sender, EventArgs e)
        {
            this.result.Text = "0";
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            this.operation = button.Text;
            this.value = double.Parse(result.Text);
            this.operationPressed = true;

            if(operation.Equals("sqrt"))
            {
                equation.Text = "sqrt(" + value + ")";
            }
            else if(operation.Equals("1/x"))
            {
                equation.Text = "1/" + value;
            }
            else if (operation.Equals("+/-"))
            {
                equation.Text = "";
                result.Text = (-value).ToString();
            }

            else
            {
                equation.Text = value + " " + operation;
            }
        }

        private void equalsButtonClick(object sender, EventArgs e)
        {
            equation.Text = "";

            switch (operation)
            {
                case "+":
                    this.result.Text = (value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    this.result.Text = (value - double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    this.result.Text = (value * double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    this.result.Text = (value / double.Parse(result.Text)).ToString();
                    break;
                case "%":
                    this.result.Text = (value % double.Parse(result.Text)).ToString();
                    break;
                case "sqrt":
                    this.result.Text = Math.Sqrt(value).ToString();
                    break;
                case "+/-":
                    this.result.Text = (-value).ToString();
                    break;
                case "1/x":
                    this.result.Text = (1.0 / value).ToString();
                    break;
                default: break;
            }

        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            this.value = 0;
            this.result.Text = "0";
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            string strValue = value.ToString();
            int valueLength = strValue.Length;
            for (int i = 0; i < valueLength-1; i++)
            {
                result.Text += strValue[valueLength];
                
            }
            if (valueLength == 1)
            {
                result.Text = "0";
            }
        }

    }
}
