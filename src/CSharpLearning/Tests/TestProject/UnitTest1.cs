using NUnit.Framework;
using TicTacToe;

namespace TestProject
{
    public class Tests
    {
        Player player1;
        Player player2;
        TicTacToeGame ticTacToe;

        [SetUp]
        public void Setup()
        {
            player1 = new Player("Joe", 'X');
            player2 = new Player("Smith", 'O');
            ticTacToe = new TicTacToeGame(player1, player2);
        }
              
        [Test]
        public void GivenBoardCheckWinnerByRow()
        {
            // Set the stage for the testing            
            char[] gameBoard = new char[9] {
                            '-', '-', player1.Symbol,
                            player1.Symbol, player1.Symbol, player1.Symbol,
                            player2.Symbol, '-', player2.Symbol
                };

            // Test the code/functionality
            bool player1IsWinner = ticTacToe.HorizontalCheck(gameBoard, player1);
            bool player2IsNotWinner = ticTacToe.HorizontalCheck(gameBoard, player2);

            // Assert
            Assert.IsTrue(player1IsWinner);
            Assert.IsFalse(player2IsNotWinner);
        }

        [TestCase(new char[9] { 'O', '-', 'X', 'O', 'X', 'X', 'O', '-', 'O' })]
        [TestCase(new char[9] { 'X', 'O', 'X', '-', 'O', 'X', '-', 'O', 'O' })]
        public void GivenBoardCheckWinnerByCol(char[] gameBoard)
        {
            // Set the stage for the testing            

            // Test the code/functionality
            bool player2IsWinner = ticTacToe.VerticalCheck(gameBoard, player2);
            bool player1IsNotWinner = ticTacToe.VerticalCheck(gameBoard, player1);

            // Assert
            Assert.IsTrue(player2IsWinner);
            Assert.IsFalse(player1IsNotWinner);
        }
    }
}