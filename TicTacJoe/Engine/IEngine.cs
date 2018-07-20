using TicTacToe;
using TicTacToe.Enums;

namespace TicTacJoe.Engine
{
    interface IEngine
    {
        Space GetNextMove(Board boardState, Marker marker);
    }
}
