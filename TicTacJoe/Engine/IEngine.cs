using TicTacToe;
using TicTacToe.Enums;

namespace TicTacJoe.Engine
{
    interface IEngine
    {
        int GetNextMove(Board boardState, Marker marker);
    }
}
