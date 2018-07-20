using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
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
            int moves = 1;
            Marker marker = Marker.X;
            //Play the first row
            state = gameBoard.Play(new Space { Marker = marker, Number = moves });
            marker = SwapPlayer(marker);
            while (state == GameState.Playing && moves < 9)
            {
                moves++;
                Space aIMove = wallE.GetNextMove(gameBoard, marker);
                state = gameBoard.Play(new Space { Marker = marker, Number = aIMove.Number });
                while (state == GameState.InvalidMove)
                {
                    aIMove = wallE.GetNextMove(gameBoard, marker);
                    state = gameBoard.Play(new Space { Marker = marker, Number = aIMove.Number });
                }
                marker = SwapPlayer(marker);
            }
            Debug.WriteLine($"Game result of {nameof(state)} umber of moves {moves}.");
            Assert.IsTrue(state == GameState.Winner || state != GameState.Tie);
        }

        private Marker SwapPlayer(Marker marker)
        {
            return marker == Marker.X ? Marker.O : Marker.X;
        }
    }
}
