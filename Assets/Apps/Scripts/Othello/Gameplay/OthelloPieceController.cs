using System;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class OthelloPieceController : MonoBehaviour
    {
        private InputController InputController => FindObjectOfType<InputController>();
        private Board Board => FindObjectOfType<Board>();

        public GameObject othelloPiecePrefab;

        public PieceSide PieceSide { get; set; }
        public event Action OnPiecePlaced;
        public event Action<PieceSide> OnNoValidMove;
        public event Action<Board> OnGameOver;


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
            if (Board.IsValidMove(boardBlock, PieceSide)) {
                OthelloPiece op = GeneratePiece();
                op.Place(boardBlock, PieceSide);
                OnPiecePlaced?.Invoke();
            }
        }

        internal void NextTurn() {
            if (!Board.HasValidMove(PieceSide.Black) && !Board.HasValidMove(PieceSide.White) ) {
                Debug.Log("Game Over");
                OnGameOver?.Invoke(Board);
                return;
            }
            if (PieceSide == PieceSide.White) {
                if (SideHasValidMove(PieceSide.Black)) {
                    PieceSide = PieceSide.Black;
                } else {
                    Debug.Log("Black has no valid move!");
                    OnNoValidMove?.Invoke(PieceSide.Black);
                }
            } else {
                if (SideHasValidMove(PieceSide.White)) {
                    PieceSide = PieceSide.White;
                } else {
                    Debug.Log("White has no valid move!");
                    OnNoValidMove?.Invoke(PieceSide.White);
                }
            }
        }

        private bool SideHasValidMove(PieceSide side) {
            if (Board.HasValidMove(side)) {
                return true;
            }
            return false;
        }

        public void PutInitialPiece(int x, int y, PieceSide pieceSide) {
            BoardBlock boardBlock = Board.GetBlock(x, y);
            OthelloPiece othelloPiece = GeneratePiece();
            othelloPiece.Place(boardBlock, pieceSide);
        }
        private OthelloPiece GeneratePiece() {
            OthelloPiece othelloPiece = Instantiate(othelloPiecePrefab, transform).GetComponent<OthelloPiece>();

            return othelloPiece;
        }
    }
}
