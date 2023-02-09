using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20_Tic_Tac_Toe
{
    internal class Spot
    {
        public string state { get; set; } = " ";
        public Spot()
        {
            state = " ";
        }

        public void SetCross()
        {
            state = "X";
        }

        public void SetCircle()
        {
            state = "O";
        }

        public bool IsEmpty()
        {
            if (state == " ")
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
