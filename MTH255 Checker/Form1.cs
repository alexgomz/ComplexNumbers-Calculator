using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTH255_Checker
{
    public partial class Form1 : Form
    {
        private class cn
        {
            double real;
            double imaginary;
            double polar;
            int angle;

            public cn(double r, double i)
            {
                real = r;
                imaginary = i;
                double powHolder;
                powHolder = Math.Pow(real, 2) + Math.Pow(imaginary, 2);
                polar = Math.Sqrt(powHolder);
                angle = Convert.ToInt16((Math.Atan2(real, imaginary) * 180)/Math.PI);
            }

            public cn(double p, int a)
            {
                polar = p;
                angle = a;
                real = polar * Math.Sin(Convert.ToDouble((angle * Math.PI)/180)); //It takes radians, so converting to rad first
                imaginary = polar * Math.Cos(Convert.ToDouble((angle * Math.PI)/180));
            }

            public string getReal()
            {
                double ret = Math.Round(real, 3);
                return Convert.ToString(ret);
            }
            public double getRealDouble()
            {
                double ret = Math.Round(real, 3);
                return ret;
            }
            public string getImaginary()
            {
                double ret = Math.Round(imaginary, 3);
                return Convert.ToString(ret);
            }
            public double getImaginaryDouble()
            {
                double ret = Math.Round(imaginary, 3);
                return ret;
            }
            public string getPolar()
            {
                double ret = Math.Round(polar, 3);
                return Convert.ToString(ret);
            }
            public double getPolarDouble()
            {
                double ret = Math.Round(polar, 3);
                return ret;
            }
            public string getAngle()
            {
                return Convert.ToString(angle);
            }
            public int getAngleInt()
            {
                return angle;
            }

        } //End of Complex Number class

        public Form1()
        {
            InitializeComponent();

        }

        //All calculations are handled by the button presses (+ - * /) on the screen. They are all bellow.
        private void btnConvertRecPol_Click(object sender, EventArgs e)
        {
            double real, imaginary;
            real = Convert.ToDouble(txtRealRecPol.Text);
            imaginary = Convert.ToDouble(txtImagRecPol.Text);
            cn recToPol = new cn(real, imaginary);
            txtPolarRecPol.Text = recToPol.getPolar();
            txtAngleRecPol.Text = recToPol.getAngle();
        }

        private void btnConvertPolRec_Click(object sender, EventArgs e)
        {
            double polar = Convert.ToDouble(txtPolarPolRec.Text);
            int angle = Convert.ToInt16(txtAnglePolRec.Text);
            cn polToRec = new cn(polar, angle);
            txtRealPolRec.Text = polToRec.getReal();
            txtImagPolRec.Text = polToRec.getImaginary();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double real = Convert.ToDouble(txtAddRecReal1.Text);
            double imaginary = Convert.ToDouble(txtAddRecImag1.Text);
            cn one = new cn(real, imaginary);
            real = Convert.ToDouble(txtAddRecReal2.Text);
            imaginary = Convert.ToDouble(txtAddRecImag2.Text);
            cn two = new cn(real, imaginary);

            txtAddRecRealTotal.Text = Convert.ToString(one.getRealDouble() + two.getRealDouble());
            txtAddRecImagTotal.Text = Convert.ToString(one.getImaginaryDouble() + two.getImaginaryDouble());
           
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            double real = Convert.ToDouble(txtAddRecReal1.Text);
            double imaginary = Convert.ToDouble(txtAddRecImag1.Text);
            cn one = new cn(real, imaginary);
            real = Convert.ToDouble(txtAddRecReal2.Text);
            imaginary = Convert.ToDouble(txtAddRecImag2.Text);
            cn two = new cn(real, imaginary);

            txtAddRecRealTotal.Text = Convert.ToString(one.getRealDouble() - two.getRealDouble());
            txtAddRecImagTotal.Text = Convert.ToString(one.getImaginaryDouble() - two.getImaginaryDouble());
           
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            double polar = Convert.ToDouble(txtMDPol1.Text);
            int angle = Convert.ToInt16(txtMDPolAngel1.Text);
            cn one = new cn(polar, angle);
            polar = Convert.ToDouble(txtMDPol2.Text);
            angle = Convert.ToInt16(txtMDPolAngle2.Text);
            cn two = new cn(polar, angle);

            txtMDPolTotal.Text = Convert.ToString(one.getPolarDouble() * two.getPolarDouble());
            txtMDPolAngleTotal.Text = Convert.ToString(one.getAngleInt() + two.getAngleInt());
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            double polar = Convert.ToDouble(txtMDPol1.Text);
            int angle = Convert.ToInt16(txtMDPolAngel1.Text);
            cn one = new cn(polar, angle);
            polar = Convert.ToDouble(txtMDPol2.Text);
            angle = Convert.ToInt16(txtMDPolAngle2.Text);
            cn two = new cn(polar, angle);

            txtMDPolTotal.Text = Convert.ToString(one.getPolarDouble() / two.getPolarDouble());
            txtMDPolAngleTotal.Text = Convert.ToString(one.getAngleInt() - two.getAngleInt());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Alejandro Gomez");
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Simply clears all the text fields, one by one.
            txtAddRecImag1.Clear(); txtAddRecImag2.Clear(); txtAddRecImagTotal.Clear(); txtAddRecReal1.Clear();
            txtAddRecReal2.Clear(); txtAddRecRealTotal.Clear(); txtAnglePolRec.Clear(); txtAngleRecPol.Clear();
            txtImagPolRec.Clear(); txtImagRecPol.Clear(); txtMDPol1.Clear(); txtMDPol2.Clear();
            txtMDPolAngel1.Clear(); txtMDPolAngle2.Clear(); txtMDPolAngleTotal.Clear(); txtMDPolTotal.Clear();
            txtPolarPolRec.Clear(); txtPolarRecPol.Clear(); txtRealPolRec.Clear(); txtRealRecPol.Clear();
        }
    }
}
