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
        public int GetNextMove(Board boardState, Marker marker)
        {
            int[] spacesLeft = new int[boardState.Spaces.Count(x => x == Marker.Empty)];

            for (int i = 0; i < boardState.Spaces.Count(x => x == Marker.Empty); i++)
            {
                spacesLeft[i] = boardState.Spaces.ToList().IndexOf(boardState.Spaces.Where(x => x == Marker.Empty).ToArray()[i]);
            }
            Random random = new Random();            
            return spacesLeft[random.Next(spacesLeft.Length)];
        }
    }
}
