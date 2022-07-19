using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class OthelloPieceController : MonoBehaviour
    {
        private InputController InputController => FindObjectOfType<InputController>();
        private Board Board => FindObjectOfType<Board>();

        public GameObject othelloPiecePrefab;

        //testing
        private PieceSide PieceSide = PieceSide.White;
        //


        private void Awake() {
            InputController.OnClickOnBoard += PutPiece;
        }
        private void Update() {
            //testing
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                PieceSide = PieceSide.White;
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PieceSide = PieceSide.Black;
            }
            //testing
        }

        public void PutPiece(BoardBlock boardBlock) {
            if (boardBlock.OthelloPiece != null) {
                return;
            }
            if (Board.IsValidMove(boardBlock)) {
                OthelloPiece othelloPiece = Instantiate(othelloPiecePrefab, transform).GetComponent<OthelloPiece>();
                othelloPiece.Place(boardBlock, PieceSide);
            }
        }
    }
}
