using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Marker[] _spaces;
        private Marker _winner;

        public Marker[] Spaces
        {
            get
            {
                if (_spaces == null)
                {
                    _spaces = new Marker[9];

                }
                return _spaces;
            }
            set
            {
                _spaces = value;
            }
        }

        public Marker Winner
        {
            get
            {
                var state = GetGameState();
                if (state == GameState.Playing || state == GameState.InvalidMove)
                    return Marker.Empty;
                else
                    return _winner;
            }
            set
            {
                _winner = value;
            }
        }

        public IBoard Clone()
        {
            Board b = new Board();
            b.Spaces = (Marker[])Spaces.Clone();
            return (IBoard)b;
        }

        public GameState GetGameState()
        {
            for (int i = 0; i < 3; i++)
            {
                if (
                    ((Spaces[i * 3] != Marker.Empty && Spaces[(i * 3)] == Spaces[(i * 3) + 1] && Spaces[(i * 3)] == Spaces[(i * 3) + 2]) ||
                     (Spaces[i] != Marker.Empty && Spaces[i] == Spaces[i + 3] && Spaces[i] == Spaces[i + 6])))
                {
                    return GameState.Winner;
                }
            }

            if ((Spaces[0] != Marker.Empty && Spaces[0] == Spaces[4] && Spaces[0] == Spaces[8]) || (Spaces[2] != Marker.Empty && Spaces[2] == Spaces[4] && Spaces[2] == Spaces[6]))
            {
                return GameState.Winner;
            }

            if (Spaces.Count(x => x == Marker.Empty) == 0)
            {
                return GameState.Tie;
            }

            return GameState.Playing;
        }

        public bool PlaceMarker(Marker marker, int space)
        {
            if (Spaces[space] != Marker.Empty)
            {
                return false;
            }

            Spaces[space] = marker;
            return true;
        }

        public GameState Play(Marker marker, int space)
        {
            var isValidMove = PlaceMarker(marker, space);
            if (!isValidMove)
            {
                return GameState.InvalidMove;
            }

            return GetGameState();
        }
    }
}
