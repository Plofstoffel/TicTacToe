using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
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
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 4 });

            //Try and play space 4 again
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 4 });

            Assert.IsTrue(state == GameState.InvalidMove);
        }

        [TestMethod]
        public void Test_Is_Playing()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 0 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 1 });

            Assert.IsTrue(state == GameState.Playing);
        }

        [TestMethod]
        public void Test_PlaceFirstRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 0 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 1 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 7 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 2 });

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceSecondRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 0 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 4 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 1 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 5 });

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceThirdRow_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 6 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 7 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 2 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 8 });

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceDiagonalOne_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 0 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 4 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 7 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 8 });

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_PlaceDiagonalTwo_Winning()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 2 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 4 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 7 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 6 });

            Assert.IsTrue(state == GameState.Winner);
        }

        [TestMethod]
        public void Test_Is_Tie()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state;

            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 0 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 1 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 2 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 4 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 3 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 5 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 7 });
            state = gameBoard.Play(new Space { Marker = Marker.O, Number = 6 });
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = 8 });

            Assert.IsTrue(state == GameState.Tie);
        }
    }
}
