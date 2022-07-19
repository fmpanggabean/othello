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
            SetBlocksPosition();
            SetEvent();
        }

        private void SetEvent() {
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    BoardBlock[y, x].OnPiecePlaced += BoardCheck;
                }
            }
        }

        private void BoardCheck(int x, int y) {
            PieceSide side = BoardBlock[y, x].OthelloPiece.PieceSide;
            //side check othello
        }

        private void SetBlocksPosition() {
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    BoardBlock[y, x].SetPosition(x, y);
                }
            }
        }

        internal bool IsValidMove(BoardBlock boardBlock) {
            List<BoardBlock> validBlocks = new List<BoardBlock>();

            validBlocks = GetAllEmptyBlocks();

            if (validBlocks.Contains(boardBlock)) {
                return true;
            }
            return false;
        }

        private List<BoardBlock> GetAllEmptyBlocks() {
            List<BoardBlock> items = new List<BoardBlock>();

            foreach(BoardBlock bb in BoardBlock) {
                if (bb.OthelloPiece == null) {
                    items.Add(bb);
                }
            }

            return items;
        }

        private void GenerateBoard() {
            BoardBlock = new BoardBlock[8, 8];
            for (int y=0; y<8; y++) {
                for (int x=0; x<8; x++) {
                    BoardBlock[y, x] = Instantiate(blockPrefab, transform).GetComponent<BoardBlock>();
                }
            }
        }
    }
}
