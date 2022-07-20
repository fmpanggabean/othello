using System;

namespace Othello.Gameplay {
    public class WinInfo {
        private int white;
        private int black;

        internal void SetScore(int white, int black) {
            this.white = white;
            this.black = black;
        }

        internal string GetScore(PieceSide side) {
            if (side == PieceSide.White) {
                return white.ToString();
            } else {
                return black.ToString();
            }
        }
    }
}