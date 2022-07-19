using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class BoardBlock : MonoBehaviour
    {
        public PieceSide PieceSide { get; set; }

        public OthelloPiece OthelloPiece { get; private set; }

        internal void SetPosition(int x, int y) {
            transform.position = new Vector3(x, 0, y);
        }

        internal Vector3 GetPosition() {
            return transform.position;
        }

        internal void SetPiece(OthelloPiece othelloPiece) {
            OthelloPiece = othelloPiece;
        }
    }
}
