using System;
using System.Collections.Generic;

using System.Linq;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; }
        public char Symbol { get; }


        public static Player Create(string name, char symbol)
        {
            return new Player(name, symbol);
        }
    }

    public static class Game
    {
        public static string PrettyPrint(this Player player)
        {
            return $"The Player {player.Name} has Symbol {player.Symbol}";
        }
    }




    public enum GameStatus
    {
        Player1Win,
        Player2Win,
        NoWinners,
        OnGoing
    }

    public class TicTacToeGame
    {
        char[] board = new String('-', 9).ToCharArray();
        char[] gameBoard = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        List<int[]> rows;
        List<int[]> cols;

        public TicTacToeGame(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;

            rows = new List<int[]>
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
            };

            cols = new List<int[]>
            {
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 6, 8 },
            };
        }



        public Player Player1 { get; }
        public Player Player2 { get; }

        public void Play()
        {
            int player = 0;

            while (true)
            {
                PrintBoard(this.board);

                GameStatus gameStatus = CheckGameStatus(board);

                switch (gameStatus)
                {
                    case GameStatus.Player1Win:
                        Console.WriteLine($"Player {Player1.Name} is the Winner!!!");
                        return;
                    case GameStatus.Player2Win:
                        Console.WriteLine($"Player {Player2.Name} is the Winner!!!");
                        return;
                    case GameStatus.NoWinners:
                        Console.WriteLine("No Winners :(");
                        return;
                    case GameStatus.OnGoing:
                        break;
                }


                if (player % 2 == 0)
                {
                    board = PlayBoard(Player1, this.board);
                }
                else
                {
                    board = PlayBoard(Player2, this.board);
                }
                player++;
            }
        }

        private GameStatus CheckGameStatus(char[] board)
        {
            // 1 - check if all the board is filled , check if any char '-' is present
            // return on going
            bool checkBoardFilled = CheckBoardFilled(board);
            if (checkBoardFilled)
                return GameStatus.NoWinners;

            // 2 is Player 1 winner
            bool isPlayer1Winner = VerticalCheck(board, Player1) || HorizontalCheck(board, Player1);// || DiagonalCheck(board, Player1);

            if (isPlayer1Winner)
                return GameStatus.Player1Win;
            // 3 is Player 2 winner
            bool isPlayer2Winner = VerticalCheck(board, Player2) || HorizontalCheck(board, Player2);// || DiagonalCheck(board, Player2);

            if (isPlayer2Winner)
                return GameStatus.Player2Win;
            // 4 else no winners
            return GameStatus.OnGoing;

        }
        private bool CheckBoardFilled(char[] board)
        {
            return board.All(c => c != '-');
        }

        private bool IsWinnerCheck(char[] board, List<int[]> boardLines, Player player)
        {
            return boardLines.Any(line => line.All(cell => board[cell] == player.Symbol));
        }

        public bool HorizontalCheck(char[] board, Player player)
        {
            return IsWinnerCheck(board, rows, player);
        }

        public bool VerticalCheck(char[] board, Player player)
        {
            return IsWinnerCheck(board, cols, player);
        }

        private char[] PlayBoard(Player player, char[] board)
        {
            Console.WriteLine($"Player {player.Name} select position in the board");
            while (true)
            {
                string position = Console.ReadLine();

                if (int.TryParse(position, out int cellIndex)
                        && IsValideMove(cellIndex, board))
                {
                    board[cellIndex] = player.Symbol;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }

            return board;
        }

        private bool IsValideMove(int cellIndex, char[] board)
        {
            if (cellIndex >= board.Length || cellIndex < 0)
            {
                Console.WriteLine("Position no legal, out of boundries");
                return false;
            }

            if (board[cellIndex] == '-')
                return true;
            else
            {
                Console.WriteLine("Position no legal, cell is not empty");
                return false;
            }

        }

        private void PrintBoard(char[] gameBoard)
        {
            string outPutBoard = $"  {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]}  \n" +
                $"_____________\n" +
                $"" +
                $"  {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]}  \n" +
                $"_____________\n" +
                $"  {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]}  \n";
            Console.WriteLine(outPutBoard);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            var player1 = new Player("Joe", 'X');
            var player2 = new Player("Smith", 'O');

            player1.PrettyPrint();

            Game.PrettyPrint(player2);


            Player.Create("John", 'z');

            var game = new TicTacToeGame(player1, player2);

            game.Play();

            Console.ReadLine();

            // - Tic Tac Toe 
            /*
                x_|_x|_x
                __|_x|_x_
                  |  | x       
             */
        }
    }
}
