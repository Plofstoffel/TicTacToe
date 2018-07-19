using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacJoe.Engine
{
    public class Skynet_Engine : IEngine
    {
        public int GetNextMove(Board boardState, Marker marker)
        {
            


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
