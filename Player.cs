using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20_Tic_Tac_Toe
{
    internal class Player
    {
        public string name { get; set; }
        public byte score { get; set; }   //will be 1 or 0
        public string chessType { get; set; }   //will be "X" or "O"
        static string[] validKey = new[] { "q", "w", "e", "a", "s", "d", "z", "x", "c", "7", "8", "9", "4", "5", "6", "1", "2", "3" };
        public bool turn { get; set; } = false;


        public void AddScore()
        { 
            score++; 
        }

        static public bool isValidKey(string key)
        {
            foreach (var i in validKey)
            {
                if (key == i)
                {
                    return true;
                }
            }
            return false;
        }


        
    }
}
