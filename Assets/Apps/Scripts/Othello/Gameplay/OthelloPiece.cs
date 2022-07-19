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

        private void Start() {
            SetSide(PieceSide.Black);
        }
        public void SetSide(PieceSide pieceSide) {
            Animator.SetTrigger(pieceSide.ToString());
            PieceSide = pieceSide;
        }
    }
}
