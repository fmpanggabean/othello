using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public enum PieceSide {
        Black, White
    }
    public class OthelloPiece : MonoBehaviour
    {
        public Animator Animator => GetComponentInChildren<Animator>();
        public PieceSide PieceSide { get; set; }

        public void SetSide(PieceSide pieceSide) {
            Animator.SetTrigger(pieceSide.ToString());
            PieceSide = pieceSide;
        }

        internal void SetPosition(BoardBlock boardBlock) {
            transform.position = boardBlock.GetPosition();
        }

        internal void Place(BoardBlock boardBlock, PieceSide pieceSide) {
            SetPosition(boardBlock);
            SetSide(pieceSide);
            boardBlock.SetPiece(this);
        }

        internal void Flip() {
            if (PieceSide == PieceSide.White) {
                SetSide(PieceSide.Black);
            } else {
                SetSide(PieceSide.White);
            }
        }
    }
}
