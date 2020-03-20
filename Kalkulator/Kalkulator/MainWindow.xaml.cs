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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool result = false;
        public MainWindow()
        {
            InitializeComponent();
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (result == true)
            {
                if (b.Content.ToString() == "÷")
                {
                    tbPrev.Text = tbResult.Text+ " ÷ ";
                    tbResult.Text = "";
                }
                else if (b.Content.ToString() == "×")
                {
                    tbPrev.Text = tbResult.Text + " × ";
                    tbResult.Text = "";
                }
                else if (b.Content.ToString() == "-")
                {
                    tbPrev.Text = tbResult.Text + " - ";
                    tbResult.Text = "";
                }
                else if (b.Content.ToString() == "+")
                {
                    tbPrev.Text = tbResult.Text + " × ";
                    tbResult.Text = "";
                }
                else
                {
                    tbResult.Text = "";
                    tbPrev.Text = "";
                }
                
                result = false;
            }

            if (b.Content.ToString() == "1" || b.Content.ToString() == "2" || b.Content.ToString() == "3" || b.Content.ToString() == "4" || b.Content.ToString() == "5" ||
                b.Content.ToString() == "6" || b.Content.ToString() == "7" || b.Content.ToString() == "8" || b.Content.ToString() == "9")
            {
                if (tbResult.Text.Length < 12)
                {
                    if (tbResult.Text == "0")
                    {
                        tbResult.Text = "";
                        tbResult.Text += b.Content.ToString();
                    }
                    else
                        tbResult.Text += b.Content.ToString();
                }
                

            }
            else if (b.Content.ToString() == "0")
            {
                if(tbResult.Text != "0")
                    tbResult.Text += b.Content.ToString();
            }
            else if (b.Content.ToString() == "Del")
            {
                if (tbResult.Text.Length != 0)
                {
                    tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 1, 1);
                }
            }
            else if (b.Content.ToString() == "C")
            {
                tbResult.Text = "";
                tbPrev.Text = "";
            }
            else if (b.Content.ToString() == "CE")
            {
                tbResult.Text = "";
            }
            else if (b.Content.ToString() == ",")
            {
                if (tbResult.Text.Contains(",") || tbResult.Text.Length == 0)
                {
                    return;
                }
                tbResult.Text += b.Content.ToString();
            }
            else if (b.Content.ToString() == "+/-")
            {
                if (tbResult.Text.Contains("-"))
                    tbResult.Text = tbResult.Text.Remove(0, 1);
                else if (tbResult.Text.Length == 0 || tbResult.Text == "0")
                    return;
                else
                    tbResult.Text = tbResult.Text.Insert(0, "-");
            }
            else if(b.Content.ToString() == "÷" || b.Content.ToString() == "×" || b.Content.ToString() == "-" || b.Content.ToString() == "+")
            {
                if (tbResult.Text.Length != 0 & tbPrev.Text.Length == 0)
                {
                    tbPrev.Text = tbResult.Text;
                    tbResult.Text = "";
                    tbPrev.Text += " " + b.Content.ToString() + " ";
                }
            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            if (tbPrev.Text.Length != 0 & result == false)
            {
                string tmp = tbPrev.Text;
                tbPrev.Text += tbResult.Text + " = ";
                double wynik, a, b;

                if (tmp.Contains("+"))
                {
                    tmp = tmp.Replace("+", "");
                    a = Convert.ToDouble(tmp);
                    b = Convert.ToDouble(tbResult.Text);
                    wynik = a + b;
                    tbResult.Text = wynik.ToString();
                }
                else if (tmp.Contains("-"))
                {
                    tmp = tmp.Replace("-", "");
                    a = Convert.ToDouble(tmp);
                    b = Convert.ToDouble(tbResult.Text);
                    wynik = a - b;
                    tbResult.Text = wynik.ToString();
                }
                else if (tmp.Contains("÷"))
                {
                    tmp = tmp.Replace("÷", "");
                    a = Convert.ToDouble(tmp);
                    b = Convert.ToDouble(tbResult.Text);
                    if(b == 0)
                    {
                        tbResult.Text = "Błąd";
                        result = true;
                        return;
                    }
                    wynik = a / b;
                    tbResult.Text = wynik.ToString();
                }
                else if (tmp.Contains("×"))
                {
                    tmp = tmp.Replace("×", "");
                    a = Convert.ToDouble(tmp);
                    b = Convert.ToDouble(tbResult.Text);
                    wynik = a * b;
                    tbResult.Text = wynik.ToString();
                }
                result = true;
            }
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (result == true)
            {
                if (e.Key == Key.OemPlus || e.Key == Key.Add)
                {
                    tbPrev.Text = tbResult.Text + " + ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
                {
                    tbPrev.Text = tbResult.Text + " - ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.Multiply)
                {
                    tbPrev.Text = tbResult.Text + " × ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.Divide || e.Key == Key.OemQuestion)
                {
                    tbPrev.Text = tbResult.Text + " ÷ ";
                    tbResult.Text = "";
                }
                else
                {
                    tbResult.Text = "";
                    tbPrev.Text = "";
                }
                result = false;
            }
            if (tbResult.Text.Length < 12)
            {
                if ((e.Key == Key.D0 || e.Key == Key.NumPad0) && tbResult.Text != "0")
                    tbResult.Text += "0";
                else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                    tbResult.Text += "1";
                else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                    tbResult.Text += "2";
                else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
                    tbResult.Text += "3";
                else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
                    tbResult.Text += "4";
                else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
                    tbResult.Text += "5";
                else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
                    tbResult.Text += "6";
                else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
                    tbResult.Text += "7";
                else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
                    tbResult.Text += "8";
                else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
                    tbResult.Text += "9";
            }
                
                
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (tbResult.Text.Length != 0)
                    tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 1, 1);
            }
            else if (e.Key == Key.OemPeriod || e.Key == Key.OemComma)
            {
                if (tbResult.Text.Contains(",") || tbResult.Text.Length == 0)
                    return;
                tbResult.Text += ",";
            }
            else if (tbResult.Text.Length != 0 & tbPrev.Text.Length == 0)
            {
                if (e.Key == Key.OemPlus || e.Key == Key.Add) 
                {
                    tbPrev.Text = tbResult.Text + " + ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
                {
                    tbPrev.Text = tbResult.Text + " - ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.Multiply)
                {
                    tbPrev.Text = tbResult.Text + " × ";
                    tbResult.Text = "";
                }
                else if (e.Key == Key.Divide || e.Key == Key.OemQuestion)
                {
                    tbPrev.Text = tbResult.Text + " ÷ ";
                    tbResult.Text = "";
                }
            }
            else if (e.Key == Key.Enter)
            {
                if (tbPrev.Text.Length != 0 & result == false & tbResult.Text.Length != 0)
                {
                    string tmp = tbPrev.Text;
                    tbPrev.Text += tbResult.Text + " = ";
                    double wynik, a, b;

                    if (tmp.Contains("+"))
                    {
                        tmp = tmp.Replace("+", "");
                        a = Convert.ToDouble(tmp);
                        b = Convert.ToDouble(tbResult.Text);
                        wynik = a + b;
                        tbResult.Text = wynik.ToString();
                    }
                    else if (tmp.Contains("-"))
                    {
                        tmp = tmp.Replace("-", "");
                        a = Convert.ToDouble(tmp);
                        b = Convert.ToDouble(tbResult.Text);
                        wynik = a - b;
                        tbResult.Text = wynik.ToString();
                    }
                    else if (tmp.Contains("÷"))
                    {
                        tmp = tmp.Replace("÷", "");
                        a = Convert.ToDouble(tmp);
                        b = Convert.ToDouble(tbResult.Text);
                        if (b == 0)
                        {
                            tbResult.Text = "Błąd";
                            result = true;
                            return;
                        }
                        wynik = a / b;
                        tbResult.Text = wynik.ToString();
                    }
                    result = true;
                }
            }
        }
    }
}
