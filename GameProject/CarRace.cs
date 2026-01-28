using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class CarRace : Form
    {
        public CarRace()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            moveLine(20);
        }

        void moveLine (int speed)
        {
            if (middleLine1.Top >= 600)
            {
                middleLine1.Top = 0;
            }
            else
            {
                middleLine1.Top += speed;
            }

            if (middleLine2.Top >= 600)
            {
                middleLine2.Top = 0;
            }
            else
            {
                middleLine2.Top += speed;
            }

            if (middleLine3.Top >= 600)
            {
                middleLine3.Top = 0;
            }
            else
            {
                middleLine3.Top += speed;
            }

            if (middleLine4.Top >= 600)
            {
                middleLine4.Top = 0;
            }
            else
            {
                middleLine4.Top += speed;
            }
        }
    }
}
