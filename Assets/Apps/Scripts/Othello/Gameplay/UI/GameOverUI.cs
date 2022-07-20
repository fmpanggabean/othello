using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Othello.Gameplay
{
    public class GameOverUI : MonoBehaviour
    {
        private GameManager GameManager => FindObjectOfType<GameManager>();

        [SerializeField] private GameObject window;

        [SerializeField] private TMP_Text whiteText;
        [SerializeField] private TMP_Text blackText;

        private void Awake() {
            GameManager.OnGameOver_WinInfo += ShowGameOver;
        }
        private void Start() {
            window.SetActive(false);
        }

        private void ShowGameOver(WinInfo winInfo) {
            window.SetActive(true);

            whiteText.text = "White: " + winInfo.GetScore(PieceSide.White);
            blackText.text = "Black: " + winInfo.GetScore(PieceSide.Black);
        }
    }
}
