using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private OthelloPieceController OthelloPieceController => FindObjectOfType<OthelloPieceController>();

        public event Action<WinInfo> OnGameOver_WinInfo;
        public event Action OnGameOver;

        private void Awake() {
            OthelloPieceController.OnPiecePlaced += NextTurn;
            OthelloPieceController.OnGameOver += GameOver;
        }

        void Start()
        {
            SetNormalInitialPiece();

            SetTurn();
        }

        private void SetNormalInitialPiece() {
            OthelloPieceController.PutInitialPiece(3, 3, PieceSide.White);
            OthelloPieceController.PutInitialPiece(4, 4, PieceSide.White);
            OthelloPieceController.PutInitialPiece(3, 4, PieceSide.Black);
            OthelloPieceController.PutInitialPiece(4, 3, PieceSide.Black);
        }

        public void SetTurn() {
            OthelloPieceController.PieceSide = PieceSide.Black;
            NextTurn();
        }

        private void NextTurn() {
            OthelloPieceController.NextTurn();
        }

        private void GameOver(Board board) {
            WinInfo winInfo = new WinInfo();

            winInfo.SetScore(board.GetPieceCount(PieceSide.White), board.GetPieceCount(PieceSide.Black));
            OnGameOver_WinInfo?.Invoke(winInfo);
        }
    }
}
