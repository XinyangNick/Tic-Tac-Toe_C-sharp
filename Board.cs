using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20_Tic_Tac_Toe
{
    internal class Board
    {
        private Spot[,] grid = new Spot[3, 3]; //spot is 3x3 array
        private string winningtype; // refer to "X" or "O"

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = new Spot();
                }
            }

        }

        public void SetChess(int x, int y, string type)   // set a "X" or "O" at given coord
        {
            if (type == "X")
            {
                SetX(x, y);
            }
            else if (type == "O")
            {
                SetO(x, y);
            }
        }

        private string SetX(int x, int y)
        {
            grid[x, y].SetCross();
            return "X";
        }

        private string SetO(int x, int y)
        {
            grid[x, y].SetCircle();
            return "O";
        }

        public string Display()   //spawn a visual board in string
        {
            string a = grid[0,0].state + "|" + grid[0,1].state + "|" + grid[0,2].state + "\n";
            string b = "-+-+-\n";
            string c = grid[1,0].state + "|" + grid[1,1].state + "|" + grid[1,2].state + "\n";
            string d = "-+-+-\n";
            string e = grid[2,0].state + "|" + grid[2,1].state + "|" + grid[2,2].state + "\n";

            return a + b + c + d + e;
        }

        public bool IsEmpty(int x, int y)    //check grid[x,y] is empty
        {
            if (grid[x, y].IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAllFull() //check whether spot was set a "X" or "O"
        {
            foreach (Spot spot in grid)
            {
                if (spot.IsEmpty())
                { 
                    return false; 
                }
            }
            return true;
        }

        public bool CheckWin()  //check if any player have three in a row
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 1)
                    {
                        if (grid[i, j].state == grid[i, j - 1].state && grid[i, j].state == grid[i, j + 1].state && grid[i, j].state == "X")
                        {
                            winningtype = "X";
                            return true;
                        }
                        else if (grid[i, j].state == grid[i, j - 1].state && grid[i, j].state == grid[i, j + 1].state && grid[i, j].state == "O")
                        {
                            winningtype = "O";
                            return true; }
                    }
                    if (i == 1)
                    {
                        if (grid[i, j].state == grid[i - 1, j].state && grid[i, j].state == grid[i + 1, j].state && grid[i, j].state == "X")
                        {
                            winningtype = "X";
                            return true;
                        }
                        else if (grid[i, j].state == grid[i - 1, j].state && grid[i, j].state == grid[i + 1, j].state && grid[i, j].state == "O")
                        {
                            winningtype = "O";
                            return true;
                        }
                    }
                    if (i == 1 && j == 1)
                    {
                        if (grid[i, j].state == grid[i - 1, j - 1].state && grid[i, j].state == grid[i + 1, j + 1].state && grid[i, j].state == "X")
                        {
                            winningtype = "X";
                            return true;
                        }
                        if (grid[i, j].state == grid[i - 1, j + 1].state && grid[i, j].state == grid[i + 1, j - 1].state && grid[i, j].state == "X")
                        {
                            winningtype = "X";
                            return true;
                        }
                        if (grid[i, j].state == grid[i - 1, j - 1].state && grid[i, j].state == grid[i + 1, j + 1].state && grid[i, j].state == "O")
                        {
                            winningtype = "O";
                            return true;
                        }
                        if (grid[i, j].state == grid[i - 1, j + 1].state && grid[i, j].state == grid[i + 1, j - 1].state && grid[i, j].state == "O")
                        {
                            winningtype = "O";
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
