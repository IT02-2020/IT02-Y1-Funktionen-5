using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT02_Y1_Funktionen_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public int Add(int x, int y)
        {
            
            if(x ==  0 && y == 0)
            {
                return 0;
            }

            else if (x == 0)
            {
                return 1 + Add(x, y - 1);
            }
            else if (y == 0)
            {
                return 1 + Add(x - 1, y);
            }
            else
            {
                return 1 + 1 + Add(x - 1, y - 1);
            }
        }


        public int Sub(int x, int y)
        {
            if (y == 0)
            {
                return  Add(x,0);
            }
            else
            {
                return Sub(x, y - 1) - 1;
            }
        }

        public int Mul(int x, int y)
        {
            if (y == 0)
            {
                return 0;
            }
            else if (y == 1)
            {
                return Add(x, 0);
            }
            else
            {
                return Add(Add(x,0),Mul(x,y-1));
            }

        }

        public int Div(int x, int y)
        {
            if (Sub(x,y) < 0)
            {
                return 0;
            }
            else
            {
                return 1 + Div(Sub(x, y), y);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (resultListView.Items.Count > 0)
            {
                resultListView.Items.Clear();
            }

            if (xTextBox.TextLength > 0 && yTextBox.TextLength > 0)
            {
                if (int.TryParse(xTextBox.Text, out int numOne) && int.TryParse(yTextBox.Text, out int numTwo))
                {
                    if (numOne >= 0 && numTwo >= 0)
                    {
                        resultListView.Items.Add($"{numOne} + {numTwo} = {Add(numOne, numTwo)}");
                        resultListView.Items.Add($"{numOne} - {numTwo} = {Sub(numOne, numTwo)}");
                        resultListView.Items.Add($"{numOne} * {numTwo} = {Mul(numOne, numTwo)}");
                        if (numOne > 0 && numTwo > 0)
                        {
                            resultListView.Items.Add($"{numOne} / {numTwo} = {Div(numOne, numTwo)}");
                        }
                    }
  
                }
            }

        }
    }
}
