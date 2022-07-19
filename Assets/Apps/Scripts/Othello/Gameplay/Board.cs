using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private GameObject blockPrefab;

        private BoardBlock[,] BoardBlock;

        private void Awake() {
            GenerateBoard();
        }

        private void GenerateBoard() {
            BoardBlock = new BoardBlock[8, 8];
            for (int y=0; y<8; y++) {
                for (int x=0; x<8; x++) {
                    BoardBlock[y, x] = Instantiate(blockPrefab, transform).GetComponent<BoardBlock>();
                    BoardBlock[y, x].SetPosition(x, y);
                }
            }
        }
    }
}
