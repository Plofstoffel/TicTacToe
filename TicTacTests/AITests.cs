using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacJoe.Engine;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacTests
{
    [TestClass]
    public class AITests
    {
        [TestMethod]
        public void Test_WallE_Engine_First_Row()
        {
            var gameBoard = new TicTacToe.Board();
            GameState state = GameState.Playing;

            var wallE = new Wall_E_Engine();
            int moves = 0;
            //Play the first row
            state = gameBoard.Play(new Space { Marker = Marker.X, Number = moves });
            while (state == GameState.Playing && moves < 9)
            {
                moves++;
                Space aIMove = wallE.GetNextMove(gameBoard, Marker.O);
                state = gameBoard.Play(new Space { Marker = Marker.O, Number = aIMove.Number });
                while (state == GameState.InvalidMove)
                {
                    aIMove = wallE.GetNextMove(gameBoard, Marker.O);
                    state = gameBoard.Play(new Space { Marker = Marker.O, Number = aIMove.Number });
                }                
            }

            Assert.IsTrue(state != GameState.InvalidMove && state != GameState.Playing);
        }
    }
}
