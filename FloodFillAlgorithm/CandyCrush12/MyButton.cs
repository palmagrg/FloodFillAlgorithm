using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyCrush12
{
    class MyButton : Button
    {
        public static Color[] myColors = { Color.Red, Color.Blue, Color.Yellow, Color.Black, Color.Gray, Color.Aqua, Color.Olive };
        static Random rnd = new Random();

        public static int Btn_size = 25;

        public int row { get; set; }
        public int col { get; set; }

        public MyButton()
        {
            Width = Height = Btn_size;
            int inittColor = rnd.Next() % myColors.Length;
            this.BackColor = myColors[inittColor];
        }
         
    }
}
