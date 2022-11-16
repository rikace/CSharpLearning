using System;



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



        public TicTacToeGame(Player player1, Player player2)

        {

            Player1 = player1;

            Player2 = player2;

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

                // player++;

                player = player + 1;

            }

        }



        private GameStatus CheckGameStatus(char[] board)

        {

            // 1 - check if all the board is filled , check if any char '-' is present

            // return on going

            bool checkBoardFilled = CheckBoardFilled(board);

            if (checkBoardFilled)

                return GameStatus.OnGoing;



            // 2 is Player 1 winner

            bool isPlayer1Winner = VerticalCheck(board, Player1) || HorizontalCheck(board, Player1) || DiagonalCheck(board, Player1);



            if (isPlayer1Winner)

                return GameStatus.Player1Win;

            // 3 is Player 2 winner

            bool isPlayer2Winner = VerticalCheck(board, Player2) || HorizontalCheck(board, Player2) || DiagonalCheck(board, Player2);

            if (isPlayer2Winner)

                return GameStatus.Player2Win;

            // 4 else no winners



            return GameStatus.NoWinners;



        }



        private bool CheckBoardFilled(char[] board)

        {

            return false;

        }



        private bool HorizontalCheck(char[] board, Player player1)

        {
            
            throw new NotImplementedException();

        }



        private bool DiagonalCheck(char[] board, Player player1)

        {

            throw new NotImplementedException();

        }



        private bool VerticalCheck(char[] board, Player player1)

        {
            if (board[0] == board[3] && board[3] == board[6])
            {
                
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {

            }
            else if (board[2] == board[5] && board[5] == board[8])
            {

            }





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



        private void PrintBoard(char[] board)

        {

            string boardVisual = $"| {board[0]} | {board[1]} | {board[2]} |\n| {board[3]} | {board[4]} | {board[5]} |\n| {board[6]} | {board[7]} | {board[8]} |\n";

            Console.WriteLine(boardVisual);
            

        }

    }



    class Program

    {

        static void Main(string[] args)

        {



            var player1 = new Player("Joe", 'X');

            var player2 = new Player("Smith", 'O');



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