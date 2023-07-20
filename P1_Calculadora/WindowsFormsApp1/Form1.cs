using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }
        char signo = '.';
        decimal resultado = 0, numeroX=0;
        bool bd2 = true;
        bool saveme = true;
        bool check = true;

        private void Suma_Click(object sender, EventArgs e)
        {
            if (bd2==true)
            {
                
                try
                {
                    signo = '+';
                    numeroX = int.Parse(VisorCalculadora.Text);
                    Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {
                }
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }
            else if (bd2==false)
            {
                try
                {
                    numeroX = int.Parse(VisorCalculadora.Text);
                    Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {
                }               
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '+';
            }
 
            
        }     
        private void Resta_Click(object sender, EventArgs e)
        {
            if (bd2 == true)
            {
                signo = '-';
                try
                {
                    numeroX = int.Parse(VisorCalculadora.Text);
                    Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {

                }   
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }

            else if (bd2 == false)
            {
                try
                {
                   numeroX = int.Parse(VisorCalculadora.Text);
                   Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {
                }
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '-';
            }
        }
        private void Multiplicacion_Click(object sender, EventArgs e)
        {
            
            if (bd2 == true)
            {
                signo = '*';
                try
                {
                    numeroX = int.Parse(VisorCalculadora.Text);
                    Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {

                }
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }

            else if (bd2 == false)
            {
                try
                {
                    numeroX = int.Parse(VisorCalculadora.Text);
                    Operacion(signo, ref resultado, ref numeroX, ref bd2);
                }
                catch (Exception)
                {

                }
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '*';
            }
        }
                void Operacion(char signardo, ref decimal resultado, ref decimal numeroX, ref bool bd2)
        {
            if (!bd2)
            {
                if (signo == '+')
                {
                    resultado += numeroX;

                }
                else if (signo == '-')
                {
                    resultado -= numeroX;

                }
                else if (signo == '*')
                {
                    resultado *= numeroX;

                }
                else if (signo == '/')
                {
                    resultado /= numeroX;

                }

            }
            else
            {
                if (signo == '+')
                {
                    resultado += numeroX;
                    bd2 = false;
                }

                else if (signo == '-')
                {
                    resultado -= numeroX;
                    bd2 = false;
                }

                else if (signo == '*')
                {
                    resultado += numeroX;
                    bd2 = false;
                }
                else if (signo == '/')
                {
                    resultado /= numeroX;
                    bd2 = false;
                }
            }
        }
        private void VisiorCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            VisorCalculadora.ReadOnly = false;
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 ||
                e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract
                || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Divide || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemcomma)
            {
                if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Oemcomma)
                {
                    if (saveme == true)
                    {
                        VisorCalculadora.Text = "";
                        VisorCalculadora.SelectionStart = 1;
                        saveme = false;
                    }
                }
                else
                {
                    VisorCalculadora.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Add)
                {
                    if (bd2 == true)
                    {
                        try
                        {
                            signo = '+';
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '+';
                    }
                }

                else if (e.KeyCode == Keys.Subtract)
                {
                    if (bd2 == true)
                    {
                        signo = '+';
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '+';
                    }
                }

                else if (e.KeyCode == Keys.Multiply)
                {
                    if (bd2 == true)
                    {
                        signo = '*';
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();

                    }

                    else if (bd2 == false)
                    {
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '*';
                    }
                }
                else if (e.KeyCode == Keys.Divide)
                {
                    if (bd2 == true)
                    {
                        signo = '/';
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                    }

                    else if (bd2 == false)
                    {
                        try
                        {
                            numeroX = decimal.Parse(VisorCalculadora.Text);
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                        }
                        VisorCalculadora.Clear();
                        VisorCalculadora.Focus();
                        signo = '/';
                    }
                }

                else if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (signo == '+')
                        {
                            resultado += decimal.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = resultado.ToString();
                        }
                        else if (signo == '-')
                        {
                            resultado -= decimal.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = resultado.ToString();
                        }
                        else if (signo == '*')
                        {
                            resultado *= decimal.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = resultado.ToString();
                        }
                        else if (signo == '/')
                        {
                            resultado /= decimal.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = resultado.ToString();
                        }
                        else if (signo == '.')
                        {
                            VisorCalculadora.Text = resultado.ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    //VisorCalculadora.Clear();
                    resultado = 0;
                    //VisorCalculadora.Text = "0";
                    //VisorCalculadora.Focus();
                    bd2 = true;
                    saveme = true;
                }
                
            }
            else
            {
                e.SuppressKeyPress = true;
                VisorCalculadora.Text = "";
            }

        }
        private void Igual_Click(object sender, EventArgs e)
        {
            try
            {
                if (signo == '+')
                {
                    resultado += decimal.Parse(VisorCalculadora.Text);
                    VisorCalculadora.Text = resultado.ToString();
                }
                else if (signo == '-')
                {
                    resultado -= decimal.Parse(VisorCalculadora.Text);
                    VisorCalculadora.Text = resultado.ToString();
                }

                else if (signo == '*')
                {
                    resultado *= decimal.Parse(VisorCalculadora.Text);
                    VisorCalculadora.Text = resultado.ToString();
                }

                else if (signo == '/')
                {
                    resultado /= decimal.Parse(VisorCalculadora.Text);
                    VisorCalculadora.Text = resultado.ToString();
                }
                else if (signo == '.')
                {
                    resultado += decimal.Parse(VisorCalculadora.Text);
                    VisorCalculadora.Text = resultado.ToString();
                }
            }
            catch (Exception)
            {
                VisorCalculadora.Clear();
                resultado = 0;
                VisorCalculadora.Text = "0";
                bd2 = true;
                saveme = true;
                check = true;
                VisorCalculadora.Focus();
            }
           
            
        }
        private void ClearBox_Click(object sender, EventArgs e)
        {
            VisorCalculadora.Clear();
            resultado = 0;
            VisorCalculadora.Text = "0";
            bd2 = true;
            saveme = true;
            check = true;
            VisorCalculadora.Focus();
        }
        private void VisorCalculadora_TextChanged(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text=="*")
            {
                VisorCalculadora.Text = "";
            }
            else if (VisorCalculadora.Text == "+")
            {
                VisorCalculadora.Text = "";
            }
            else if (VisorCalculadora.Text == "/")
            {
                VisorCalculadora.Text = "";
            }
        }
        private void Division_Click(object sender, EventArgs e)
        {
            if (bd2 == true)
            {
                signo = '/';
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
            }

            else if (bd2 == false)
            {
                numeroX = int.Parse(VisorCalculadora.Text);
                Operacion(signo, ref resultado, ref numeroX, ref bd2);
                VisorCalculadora.Clear();
                VisorCalculadora.Focus();
                signo = '/';
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "1";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "1";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "1";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }

            }
            else
            {
                VisorCalculadora.Text += "1";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "2";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        try
                        {
                            signo = '+';
                            resultado = 0;
                            check = false;
                            numeroX = int.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = "2";
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error Inesperado");
                        }
                        
                    }
                    
                }
                else
                {
                    VisorCalculadora.Text = "2";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "2";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "3";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        try
                        {
                            signo = '+';
                            resultado = 0;
                            check = false;
                            numeroX = int.Parse(VisorCalculadora.Text);
                            VisorCalculadora.Text = "3";
                            Operacion(signo, ref resultado, ref numeroX, ref bd2);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error Inesperado");
                        }

                    }

                }
                else
                {
                    VisorCalculadora.Text = "3";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "3";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "4";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "4";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "4";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "4";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "5";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "5";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "5";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "5";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "6";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "6";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "6";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "6";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "7";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "7";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "7";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "7";
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "8";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "8";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "8";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "8";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "9";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "9";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "9";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }
            }
            else
            {
                VisorCalculadora.Text += "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (VisorCalculadora.Text == "" || VisorCalculadora.Text == "0")
            {
                if (check)
                {
                    if (!bd2)
                    {
                        resultado = 0;
                        check = false;
                        VisorCalculadora.Text = "0";
                        numeroX = int.Parse(VisorCalculadora.Text);
                    }
                    else
                    {
                        signo = '+';
                        resultado = 0;
                        check = false;
                        numeroX = int.Parse(VisorCalculadora.Text);
                        VisorCalculadora.Text = "0";
                        Operacion(signo, ref resultado, ref numeroX, ref bd2);
                    }
                }
                else
                {
                    VisorCalculadora.Text = "0";
                    numeroX = int.Parse(VisorCalculadora.Text);
                }

            }
            else
            {
                VisorCalculadora.Text += "0";
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            VisorCalculadora.Focus();
        }


    }
}
