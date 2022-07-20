using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Othello.Gameplay
{
    public class NoValidMoveUI : MonoBehaviour
    {
        private OthelloPieceController OthelloPieceController => FindObjectOfType<OthelloPieceController>();

        [SerializeField] private GameObject window;
        [SerializeField] private TMP_Text messageText;

        private void Awake() {
            OthelloPieceController.OnNoValidMove += ShowWindow;
        }
        private void Start() {
            window.SetActive(false);
        }

        public void ShowWindow(PieceSide pieceSide) {
            StartCoroutine(TimedShow(pieceSide));
        }

        private IEnumerator TimedShow(PieceSide pieceSide) {
            window.SetActive(true);
            messageText.text = pieceSide + " has no valid move!";
            yield return new WaitForSeconds(1);
            window.SetActive(false);
        }
    }
}
