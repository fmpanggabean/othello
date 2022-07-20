using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private OthelloPieceController OthelloPieceController => FindObjectOfType<OthelloPieceController>();

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
            OthelloPieceController.PieceSide = PieceSide.White;
        }

        private void NextTurn() {
            OthelloPieceController.NextTurn();
        }

        private void GameOver(Board board) {
            int whiteCount = board.GetPieceCount(PieceSide.White);
            int blackCount = board.GetPieceCount(PieceSide.Black);
            Debug.LogFormat("White: {0}     Black: {1}", whiteCount, blackCount);
        }
    }
}
