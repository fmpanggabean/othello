using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class OthelloPieceController : MonoBehaviour
    {
        private InputController InputController => FindObjectOfType<InputController>();

        public GameObject othelloPiecePrefab;

        //testing
        private PieceSide PieceSide = PieceSide.White;
        //


        private void Awake() {
            InputController.OnClickOnBoard += PutPiece;
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                PieceSide = PieceSide.White;
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PieceSide = PieceSide.Black;
            }
        }

        public void PutPiece(BoardBlock boardBlock) {
            if (boardBlock.OthelloPiece != null) {
                return;
            }
            OthelloPiece othelloPiece = Instantiate(othelloPiecePrefab, transform).GetComponent<OthelloPiece>();
            othelloPiece.Place(boardBlock, PieceSide);
        }
    }
}
