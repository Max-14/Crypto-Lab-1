using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string AffineEncrypt(string plainText, int a, int b)
        {
            string cipherText = ""; //This is where we will insert the result of the encryption

            // Put Plain Text (all capitals) into Character Array
            char[] chars = plainText.ToUpper().ToCharArray();

            // Compute e(x) = (ax + b)(mod m) for every character in the Plain Text
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 64);
                cipherText += Convert.ToChar(((a * x + b) % 26) + 64);
            }

            return cipherText;
           
        }
        /// This function takes cipher text and decrypts it using the Affine Cipher
        /// d(x) = aInverse * (e(x)  b)(mod m).
        public static string AffineDecrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            // Get Multiplicative Inverse of a
            int aInverse = MultiplicativeInverse(a);

            // Put Cipher Text (all capitals) into Character Array
            char[] chars = cipherText.ToUpper().ToCharArray();

            // Computer d(x) = aInverse * (e(x)  b)(mod m)
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 64);
                if (x - b < 0) x = Convert.ToInt32(x) + 26;
                plainText += Convert.ToChar(((aInverse * (x - b)) % 26) + 64);
            }

            return plainText;
        }

        ///
        /// This functions returns the multiplicative inverse of integer a mod 26.
        ///
        public static int MultiplicativeInverse(int a)
        {
            
            for (int x = 1; x < 27; x++)
            {
                if ((a * x) % 26 == 1)
                    return x;
            }
            throw new Exception("No multiplicative inverse found!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
           textBox2.Text =  AffineDecrypt(textBox1.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = AffineEncrypt(textBox1.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));

        }

    }
}
