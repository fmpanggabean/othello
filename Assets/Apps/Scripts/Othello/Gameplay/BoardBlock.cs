using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class BoardBlock : MonoBehaviour {
        public event Action<int, int> OnPiecePlaced;
        public OthelloPiece OthelloPiece { get; private set; }
        public (int x, int y) position;

        internal void SetPosition(int x, int y) {
            transform.position = new Vector3(x, 0, y);
            position = (x, y);
        }

        internal Vector3 GetPosition() {
            return transform.position;
        }

        internal void SetPiece(OthelloPiece othelloPiece) {
            OthelloPiece = othelloPiece;
            OnPiecePlaced?.Invoke(position.x, position.y);
        }
    }
}
