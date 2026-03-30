using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1";
            textBox2.Text = "2";
            textBox3.Text = "1";
            textBox4.Text = "3";

            textBox1.TextChanged += onValueChanged;
            textBox2.TextChanged += onValueChanged;
            textBox3.TextChanged += onValueChanged;
            textBox4.TextChanged += onValueChanged;

            comboBox1.SelectedIndexChanged += onValueChanged;
            comboBox2.SelectedIndexChanged += onValueChanged;
            comboBox3.SelectedIndexChanged += onValueChanged;
        }

        private int GetNumerator(TextBox txtNum, ComboBox cmbSign)
        {
            int num = int.Parse(txtNum.Text);
            if (cmbSign.Text == "-")
                num = -num;
            return num;
        }

        private Rational GetRational(TextBox txtNum, TextBox txtDen, ComboBox cmbSign)
        {
            int numerator = GetNumerator(txtNum, cmbSign);
            int denominator = int.Parse(txtDen.Text);
            return new Rational(numerator, denominator);
        }

        private void Calculate()
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" ||
                    textBox3.Text == "" || textBox4.Text == "")
                {
                    label1.Text = "Введите все значения";
                    return;
                }

                var fraction1 = GetRational(textBox1, textBox2, comboBox1);
                var fraction2 = GetRational(textBox3, textBox4, comboBox2);

                Rational result = null;

                switch (comboBox3.Text)
                {
                    case "+":
                        result = fraction1 + fraction2;
                        label1.Text = result.Verbose();
                        break;

                    case "-":
                        result = fraction1 - fraction2;
                        label1.Text = result.Verbose();
                        break;

                    case "*":
                        result = fraction1 * fraction2;
                        label1.Text = result.Verbose();
                        break;

                    case "/":
                        if (fraction2.Reduce().Numerator == 0)
                        {
                            label1.Text = "Ошибка: деление на ноль!";
                            return;
                        }
                        result = fraction1 / fraction2;
                        label1.Text = result.Verbose();
                        break;

                    case "Сравнение":
                        string compareSign;
                        if (fraction1 == fraction2)
                            compareSign = "=";
                        else if (fraction1 > fraction2)
                            compareSign = ">";
                        else
                            compareSign = "<";

                        double dec1 = (double)fraction1.Reduce().Numerator / fraction1.Reduce().Denominator;
                        double dec2 = (double)fraction2.Reduce().Numerator / fraction2.Reduce().Denominator;

                        label1.Text = $"{fraction1.Verbose()} ({dec1:F4}) {compareSign} {fraction2.Verbose()} ({dec2:F4})";
                        return;

                    case "Сократить":
                        label1.Text = $"{fraction1.RawVerbose()} → {fraction1.Reduce().Verbose()}\n" +
                                     $"{fraction2.RawVerbose()} → {fraction2.Reduce().Verbose()}";
                        return;

                    default:
                        result = fraction1 + fraction2;
                        label1.Text = result.Verbose();
                        break;
                }
            }
            catch (FormatException)
            {
                label1.Text = "Ошибка: введите целые числа";
            }
            catch (ArgumentException ex)
            {
                label1.Text = $"Ошибка: {ex.Message}";
            }
            catch (DivideByZeroException ex)
            {
                label1.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}