using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20_Tic_Tac_Toe
{
    internal class Game
    {
        private Player player1 = new Player();
        private Player player2 = new Player();
        private Player firstPlayer;
        private Board board = new Board();
        

        /// <summary>
        /// transfer key to a 2 dimensional coordinate 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static public int[] KeyTransfer(string x)
        {
            if (x == "7" || x == "q")
                return new []{ 0, 0 };
            else if(x == "8" || x == "w")
                return new[] { 0, 1 };
            else if (x == "9" || x == "e")
                return new[] { 0, 2 };
            else if (x == "4" || x == "a")
                return new[] { 1, 0 };
            else if (x == "5" || x == "s")
                return new[] { 1, 1 };
            else if (x == "6" || x == "d")
                return new[] { 1, 2 };
            else if (x == "1" || x == "z")
                return new[] { 2, 0 };
            else if (x == "2" || x == "x")
                return new[] { 2, 1 };
            else
                return new[] { 2, 2 };

        }

        private void SetPlayer() // set player name, who play first, and chesspiece type
        {
            Console.WriteLine("Player one use 'qweasdzxc'   Player two use 789456123");
            Console.WriteLine("Type player one name:");
            player1.name = Console.ReadLine();
            Console.WriteLine("Type player two name:");
            player2.name = Console.ReadLine();

            Console.WriteLine("Who start first? Type the player's name:");

            string name;  //Choose who start first
            do
            {
                name = Console.ReadLine();  //set each player chess type
                if (name == player1.name)
                {
                    firstPlayer = player1;
                    player1.chessType = "X";
                    player1.turn = true;
                    player2.chessType = "O";
                }

                else if (name == player2.name)
                {
                    firstPlayer = player2;
                    player2.chessType = "X";
                    player2.turn = true;
                    player1.chessType = "O";
                }
            }
            while (name != player1.name && name != player2.name);
        }

        private void ProcessGame(Game newgame)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(newgame.board.Display());
                string pressKey = Console.ReadLine();
                if (Player.isValidKey(pressKey))   //check if it is a valid input key
                {
                    int[] coord = Game.KeyTransfer(pressKey);
                    if (newgame.board.IsEmpty(coord[0], coord[1]))    //check if it is empty on the board given the coordinate
                    {
                        if (player1.turn)   // check whose turn
                        {
                            newgame.board.SetChess(coord[0], coord[1], player1.chessType);
                            player1.turn = false;
                            player2.turn = true;
                        }
                        else if (player2.turn)
                        {
                            newgame.board.SetChess(coord[0], coord[1], player2.chessType);
                            player2.turn = false;
                            player1.turn = true;
                        }
                    }
                }


            }
            while (!newgame.board.CheckWin() && !newgame.board.CheckAllFull());
        }

        private void DecideWinner(Game newgame)
        {
            if (!newgame.board.CheckWin())
            {
                Console.WriteLine("Draw! Nobody win!");
            }
            else
            {
                if (player1.turn == false)
                {
                    Console.WriteLine("Congratulation! " + player1.name + " You win!");
                }
                else if (player2.turn == false)
                {
                    Console.WriteLine("Congratulation! " + player2.name + " You win!");
                }
            }
        }
        
        public void StartGame()
        {
            Game newgame = new Game();

            SetPlayer();

            ProcessGame(newgame);

            Console.Clear();

            Console.WriteLine(newgame.board.Display());

            DecideWinner(newgame);

        }
    }
}
