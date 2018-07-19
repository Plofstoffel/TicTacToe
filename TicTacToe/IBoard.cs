using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Enums;

namespace TicTacToe
{
    public interface IBoard
    {
        /// <summary>
        /// A Placeholder for the winner of the game;
        /// </summary>
        Marker Winner { get; set; }

        /// <summary>
        /// Represents the spaces on the board.
        /// </summary>
        Marker[] Spaces { get; set; }
 
        /// <summary>
        /// Set a marker on the board.
        /// </summary>
        /// <param name="marker"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        GameState Play(Marker marker, int space);

        /// <summary>
        /// Get the gamestate after a larker is set to determine the state of the game.
        /// </summary>
        /// <returns></returns>
        GameState GetGameState();

        /// <summary>
        /// Place the marker on the board.
        /// </summary>
        /// <param name="marker"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        bool PlaceMarker(Marker marker, int space);

        /// <summary>
        /// Helper to clone the board.
        /// </summary>
        /// <returns></returns>
        IBoard Clone();
    }
}
