using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Board
    {
        string[,] grid = { { "1", "2", "3" }, 
                        { "4", "5", "6" }, 
                        { "7", "8", "9" } };

        public void Draw()
        {
            for( int row = 0; row < grid.GetLength(0); row++ )
            {
                for ( int col = 0; col < grid.GetLength(1); col++)
                {
                    Console.Write(grid[row, col]);
                    if( col < grid.GetLength(1) - 1)
                    {
                        Console.Write(" | ");
                    }
                }

                Console.WriteLine();
                if (row < grid.GetLength(0) - 1)
                {
                    Console.WriteLine("------------");
                }
            }
        }

        public void Input(string playerSymbol)
        {
            Console.WriteLine("Make your move on the board!");
            int move;

            if (int.TryParse(Console.ReadLine(), out move))
            {
                if( move < 1 || move > 9)
                {
                    Console.WriteLine("Invalid option, please choose a number between 1 and 8"); ;
                    Input(playerSymbol);

                }
                else
                {
                    int row = (move - 1) / 3;
                    int col = (move - 1) % 3;

                    if (grid[row, col] == "X" || grid[row, col] == "O")
                    {
                        Console.WriteLine("Position is already taken,choose another move!");
                        Input(playerSymbol);
                    }
                    else
                    {
                        grid[row, col] = playerSymbol;
                    }
                }
            }
            else
            {
                Console.WriteLine("Option Invalid! Try inserting a number");
                Input(playerSymbol);
               
            } 
        }

        public bool CheckWin(string playerSymbol)
        {
            // checking Horizontal
            for ( int row = 0; row < 3; row++)
            {
                if (grid[row, 0] == playerSymbol && grid[row, 1] == playerSymbol && grid[row, 2] == playerSymbol)
                {
                    Console.WriteLine($"{playerSymbol} has won the game!");
                    return true;
                }
            }
            // For Vertical

            for ( int col = 0; col < 3; col++)
            {
                if (grid[0, col] == playerSymbol && grid[1, col] == playerSymbol && grid[2, col] == playerSymbol)
                {
                    Console.WriteLine($"{playerSymbol} has won the game!");
                    return true;
                }
            }
            // Diagonals

            if (grid[0, 0] == playerSymbol && grid[1,1] == playerSymbol && grid[2,2] == playerSymbol)
            {
                Console.WriteLine($"{playerSymbol} has won the game!");
                return true;
            }
            if (grid[0, 2] == playerSymbol && grid[1, 1] == playerSymbol && grid[2, 0] == playerSymbol)
            {
                Console.WriteLine($"{playerSymbol} has won the game!");
                return true;
            }

            return false;
        }

        public bool CheckDraw()
        {
            foreach(var position in grid)
            {
                if(position != "X" && position != "O")
                {
                    return false;
                }
            }

            Console.WriteLine("All spots filled, Its a draw!");
            return true;
        }

        public void Reset()
        {
            grid = new string[,] {
                { "1", "2", "3" }, 
                { "4", "5", "6" }, 
                { "7", "8", "9" }
            };
        }
       
    }
}
