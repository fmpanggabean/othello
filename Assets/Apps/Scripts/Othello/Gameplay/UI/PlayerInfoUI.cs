using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class PlayerInfoUI : MonoBehaviour
    {
        private OthelloPieceController OthelloPieceController => FindObjectOfType<OthelloPieceController>();

        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;

        private void Awake() {
            OthelloPieceController.OnTurnChanged += ChangeHighlightedSide;
        }

        private void ChangeHighlightedSide(PieceSide side) {
            if (side == PieceSide.White) {
                player1.SetActive(false);
                player2.SetActive(true);
            } else if (side == PieceSide.Black) {
                player1.SetActive(true);
                player2.SetActive(false);
            }
        }
    }
}
