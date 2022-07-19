using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class OthelloPieceController : MonoBehaviour
    {
        private InputController InputController => FindObjectOfType<InputController>();

        public GameObject othelloPiecePrefab;

        private void Awake() {
            InputController.OnClickOnBoard += PutPiece;
        }

        public void PutPiece(BoardBlock boardBlock) {
            if (boardBlock.OthelloPiece != null) {
                return;
            }
            OthelloPiece othelloPiece = Instantiate(othelloPiecePrefab, transform).GetComponent<OthelloPiece>();
            othelloPiece.Place(boardBlock, PieceSide.White);
        }
    }
}
