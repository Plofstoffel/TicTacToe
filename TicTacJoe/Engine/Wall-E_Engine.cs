using System;
using System.Linq;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacJoe.Engine
{
    /// <summary>
    /// Wall-E is not that smart so he just choses a random space from the spaces available. He also does not care if he is X or O. He just loves Eva!
    /// ********** _.----. .----._ 
    /// **********/ ( O ) ' ( O ) \
    /// **********\ _ _.-^-._ _ /
    /// ***********`-''''' \\''''`-'
    /// **********______//_____
    /// *********.----. :: == .----.
    /// *********[]---| ...== |---[]
    /// *********'----' _____ '----'
    /// ******* _____  | | | | |  _____
    /// *******|_-_-_| | | | | | |_-_-_|
    /// *******|_-_-_|'---------'|_-_-_|
    /// *******|_-_-_|***********|_-_-_| 
    /// </summary>
    public class Wall_E_Engine : IEngine
    {
        public Space GetNextMove(Board boardState, Marker marker)
        {
            Random random = new Random();
            return boardState.Spaces.Where(x => x.Marker == Marker.Empty).Skip(random.Next(boardState.Spaces.Count(x => x.Marker == Marker.Empty) - 1)).Take(1).FirstOrDefault();

        }
    }
}
