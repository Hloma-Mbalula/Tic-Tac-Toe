using System;
using Tic_Tac_Toe;

class Program
{
    static void Main(string[] args)
    {
        Board gameBoard = new Board();

        gameBoard.Draw();

        string currentPlayer = "X";
        bool gameWon = false;
        bool isDraw = false;

        while (!gameWon && !isDraw)
        {
            gameBoard.Input(currentPlayer);
            gameBoard.Draw();
            gameWon = gameBoard.CheckWin(currentPlayer);
            if (!gameWon)
            {
                isDraw = gameBoard.CheckDraw();
            }

            if(!gameWon && !isDraw)
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";

            }

        }
        if (gameWon)
        {
            Console.WriteLine($"{currentPlayer} Wins!");
        }
        else
        {
            Console.WriteLine("The game is a draw");
        }
    }
}

