using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Enums;

namespace TicTacTests
{
    [TestClass]
    public class BoardTests
    {

        //Assumptions:
        //Board is 9 Spaces:
        //  0 | 1 | 2
        //  ---------
        //  3 | 4 | 5
        //  ---------
        //  6 | 7 | 8        

        [TestMethod]
        public void Test_InvalidMove()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;
            //Play the first X on 4
            state = gameBoard.Play(Marker.X, 4);

            //Try and play space 4 again
            state = gameBoard.Play(Marker.X, 4);

            Assert.IsTrue(state == GameState.InvalidMove);
        }

        [TestMethod]
        public void Test_Is_Playing()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 0);
            state = gameBoard.Play(Marker.O, 3);
            state = gameBoard.Play(Marker.X, 1);

            Assert.IsTrue(state == GameState.Playing);
        }

        [TestMethod]
        public void Test_PlaceFirstRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 0);
            state = gameBoard.Play(Marker.O, 3);
            state = gameBoard.Play(Marker.X, 1);
            state = gameBoard.Play(Marker.O, 7);
            state = gameBoard.Play(Marker.X, 2);

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceSecondRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 3);
            state = gameBoard.Play(Marker.O, 0);
            state = gameBoard.Play(Marker.X, 4);
            state = gameBoard.Play(Marker.O, 1);
            state = gameBoard.Play(Marker.X, 5);

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceThirdRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 6);
            state = gameBoard.Play(Marker.O, 3);
            state = gameBoard.Play(Marker.X, 7);
            state = gameBoard.Play(Marker.O, 2);
            state = gameBoard.Play(Marker.X, 8);

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceDiagonalOne_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 0);
            state = gameBoard.Play(Marker.O, 3);
            state = gameBoard.Play(Marker.X, 4);
            state = gameBoard.Play(Marker.O, 7);
            state = gameBoard.Play(Marker.X, 8);

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceDiagonalTwo_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 2);
            state = gameBoard.Play(Marker.O, 3);
            state = gameBoard.Play(Marker.X, 4);
            state = gameBoard.Play(Marker.O, 7);
            state = gameBoard.Play(Marker.X, 6);

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_Is_Tie()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(Marker.X, 0);
            state = gameBoard.Play(Marker.O, 1);
            state = gameBoard.Play(Marker.X, 2);
            state = gameBoard.Play(Marker.O, 4);
            state = gameBoard.Play(Marker.X, 3);
            state = gameBoard.Play(Marker.O, 5);
            state = gameBoard.Play(Marker.X, 7);
            state = gameBoard.Play(Marker.O, 6);
            state = gameBoard.Play(Marker.X, 8);

            Assert.IsTrue(state == GameState.Tie);
        }
    }
}
