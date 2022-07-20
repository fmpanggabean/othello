using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private OthelloPieceController OthelloPieceController => FindObjectOfType<OthelloPieceController>();

        void Start()
        {
            OthelloPieceController.PutInitialPiece(3, 3, PieceSide.White);
            OthelloPieceController.PutInitialPiece(4, 4, PieceSide.White);
            OthelloPieceController.PutInitialPiece(3, 4, PieceSide.Black);
            OthelloPieceController.PutInitialPiece(4, 3, PieceSide.Black);
        }
    }
}
