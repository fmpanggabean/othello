using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class BoardBlock : MonoBehaviour
    {

        internal void SetPosition(int x, int y) {
            transform.position = new Vector3(x, 0, y);
        }
    }
}
