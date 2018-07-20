using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacJoe.Engine
{
    public class Skynet_Engine : IEngine
    {
        /// <summary>
        /// Skynet will use a MiniMax Algorithm to determine the Best move.
        /// Todo: Add A B pruning to make Skynet evem more advanced.
        /// </summary>
        /// <param name="boardState"></param>
        /// <param name="marker"></param>
        /// <returns></returns>
        public Space GetNextMove(Board boardState, Marker marker)
        {
            return new Space { Marker = marker, Number = 0 };
        }

        /// <summary>
        /// Detrmine if the AI won
        /// </summary>
        /// <returns></returns>
        private bool JudgementDay(Board boardState, Marker marker)
        {
            return boardState.Winner == marker;
        }        
    }

}
