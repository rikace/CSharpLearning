using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopVary
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
    }

    public class TicTacToeGame
    {
        /*
         p1 = x
         p2 = o

            _x|__|_x
            __|_o|__
              | o|
         */

        enum GameStatus
        {
            Player1Winner,
            Player2Winner,
            NoWinner,
            OnGoing
        }

        char[] board = new String('-', 9).ToCharArray();        
        //char[] board2 = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };

        public TicTacToeGame(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public Player Player1 { get; }
        public Player Player2 { get; }

        public void Play()
        {
            // print board
            // each player play by turn 
            // loop we keep a turn 
            // check the board for winner or full board no winner 
            int turn = 0;
            while (true)
            {
                PrintBoard(board);

                GameStatus gamestatus = CheckStatusBoard(board);

                switch (gamestatus)
                {
                    case GameStatus.Player1Winner:
                        Console.WriteLine($"Player {Player1.Name} is the Winner");
                        return;
                    case GameStatus.Player2Winner:
                        Console.WriteLine($"Player {Player2.Name} is the Winner");
                        return;
                    case GameStatus.NoWinner:
                        Console.WriteLine("No Winner :(");
                        return;
                    case GameStatus.OnGoing:
                        break;
                    default:
                        break;
                }


                if (turn % 2 == 0)
                    this.board = PlayerSubmitSymbol(Player1, board);
                else
                    this.board = PlayerSubmitSymbol(Player2, board);

                turn++;
            }
        }

        private GameStatus CheckStatusBoard(char[] board)
        {
            // check if the board is all full (check all cell <> '-')

            // if player 1 or player 2 is winner
            // check any consecutive symbol for player in any row
            // check any consecutive symbol for player in any column
            // check any consecutive symbol for player in any diagonal

            bool isWinnerByRow = checkRow(Player1, board);
            bool isWinnerByColumn = checkColumn(Player1, board);
            bool isWinnerByDiagonal = checkDiagonal(Player1, board);

            //bool isWinnerByRow = checkRow(Player2, board);
            //bool isWinnerByColumn = checkColumn(Player2, board);
            //bool isWinnerByDiagonal = checkDiagonal(Player2, board);

            throw new NotImplementedException();
        }

        private bool checkDiagonal(Player player1, char[] board)
        {
            // TODO 
            throw new NotImplementedException();
        }

        private bool checkColumn(Player player1, char[] board)
        {
            // TODO 
            throw new NotImplementedException();
        }

        private bool checkRow(Player player1, char[] board)
        {
            // TODO 
            throw new NotImplementedException();
        }

        private char[] PlayerSubmitSymbol(Player player, char[] board)
        {
            Console.WriteLine($"Player {player.Name} submit valid position in the board");
            int attempt = 0;
            while (true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int index);
                if (success && attempt < 4)
                {
                    if (InputNoOutOfBoundriesCheck(index, board))
                    {
                        board[index] = player.Symbol;
                        return board;
                    }
                }
                else
                {
                    Console.WriteLine($"Input no valid number, retry");
                    attempt++;
                }
            }
        }

        private bool InputNoOutOfBoundriesCheck(int index, char[] board)
        {
            // index <> board boundries 
            // the index in the board is empty 
            if(index >= board.Length || index < 0)
            {
                Console.WriteLine("Invalid input value");
                return false;
            }
            if (board[index] == '-')
                return true;

            Console.WriteLine("Cell is not empty, try again");
            return false;
        }

        private void PrintBoard(char[] board)
        {
            string stringBoard = $"| {board[0]} | {board[1]} | {board[2]} |\n| {board[3]} | {board[4]} | {board[5]} |\n| {board[6]} | {board[7]} | {board[8]} |";

            // TODO create stringBoard using for/loop

            Console.WriteLine(stringBoard);

        }
    }
}
