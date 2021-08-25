using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyCrush12
{
    public partial class Form1 : Form
    {
        private MyButton[,] btnGrid;
        private Color currColor, origColor;
        private int rows, cols;

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            //calculate the number of rows and cols based on the panelsizeand the button size
            //int x, y = 0;
            cols = panel1.Height / MyButton.Btn_size;
            rows = panel1.Width / MyButton.Btn_size;

            //new 2D array of Button
            btnGrid = new MyButton[rows, cols];

            //create a new button at each row and col location.
            for(int r = 0; r< rows; r++)
            {
                for(int c=0; c <cols; c++)
                {
                    btnGrid[r, c] = new MyButton();
                    btnGrid[r, c].row = r;
                    btnGrid[r, c].col = c;


                    //assign the same event handler to every button in the panel
                    btnGrid[r, c].Click += gridButton_Click;

                    //add the button to the panel.
                    panel1.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Location = new Point(r * MyButton.Btn_size, c * MyButton.Btn_size);


                }

            }
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            MyButton btn = (MyButton) sender;

            origColor = btn.BackColor;
            floodFill(btn.row, btn.col);

        }

        private void colorbutton_click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            currColor = btn.BackColor;
            pictureBox1.BackColor = currColor;
           

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            populateGrid();
        }

        private void floodFill(int r, int c)
        {
            if (isValid(r , c) && btnGrid[r,c].BackColor.Equals(origColor))
            {
                //change the current cell clicked
                btnGrid[r, c].BackColor = currColor;

                //apply to the cell to the east (r +1)

                floodFill(r + 1, c);

                //apply to the west (r- 1, c)
                 floodFill(r - 1, c);
                //south
                  floodFill(r, c + 1);
                //north
                floodFill(r, c - 1);
            }

            


        }

        private bool isValid(int r, int c)
        {
            if (r >= 0 && r < rows && c >= 0 && c < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
