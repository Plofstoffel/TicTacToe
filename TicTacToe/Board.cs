using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class Board
    {
        private Space[] _spaces;
        private Marker _winner;

        public Space[] Spaces
        {
            get
            {
                if (_spaces == null)
                {
                    _spaces = new Space[9]
                    {
                        new Space{ Number = 0, Marker = Marker.Empty },
                        new Space{ Number = 1, Marker = Marker.Empty },
                        new Space{ Number = 2, Marker = Marker.Empty },
                        new Space{ Number = 3, Marker = Marker.Empty },
                        new Space{ Number = 4, Marker = Marker.Empty },
                        new Space{ Number = 5, Marker = Marker.Empty },
                        new Space{ Number = 6, Marker = Marker.Empty },
                        new Space{ Number = 7, Marker = Marker.Empty },
                        new Space{ Number = 8, Marker = Marker.Empty }
                    };
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

        public Board Clone()
        {
            Board b = new Board();
            b.Spaces = (Space[])Spaces.Clone();
            return b;
        }

        private GameState GetGameState()
        {
            for (int i = 0; i < 3; i++)
            {
                if (
                    ((Spaces[i * 3].Marker != Marker.Empty && Spaces[(i * 3)].Marker == Spaces[(i * 3) + 1].Marker && Spaces[(i * 3)].Marker == Spaces[(i * 3) + 2].Marker) ||
                     (Spaces[i].Marker != Marker.Empty && Spaces[i].Marker == Spaces[i + 3].Marker && Spaces[i].Marker == Spaces[i + 6].Marker)))
                {
                    return GameState.Winner;
                }
            }

            if ((Spaces[0].Marker != Marker.Empty && Spaces[0].Marker == Spaces[4].Marker && Spaces[0].Marker == Spaces[8].Marker) || (Spaces[2].Marker != Marker.Empty && Spaces[2].Marker == Spaces[4].Marker && Spaces[2].Marker == Spaces[6].Marker))
            {
                return GameState.Winner;
            }

            if (Spaces.Count(x => x.Marker == Marker.Empty) == 0)
            {
                return GameState.Tie;
            }

            return GameState.Playing;
        }

        private bool PlaceMarker(Space space)
        {
            if (Spaces[space.Number]!= null && Spaces[space.Number].Marker != Marker.Empty)
            {
                return false;
            }

            Spaces[space.Number] = space;
            return true;
        }

        public GameState Play(Space space)
        {
            var isValidMove = PlaceMarker(space);
            if (!isValidMove)
            {
                return GameState.InvalidMove;
            }

            return GetGameState();
        }
    }
}
