using System;
using System.Collections.Generic;
using UnityEngine;

namespace Othello.Gameplay
{
    public class InputController : MonoBehaviour
    {
        public event Action<BoardBlock> OnClickOnBoard;

        public bool isEnabled { get; set; }

        private void Start() {
            Enable();
        }
        private void Update() {
            if (!isEnabled) {
                return;
            }
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100)) {
                    OnClickOnBoard?.Invoke(hit.collider.GetComponent<BoardBlock>());
                }
            }
        }
        public void Enable() {
            isEnabled = true;
        }
        public void Disable() {
            isEnabled = false;
        }
    }
}
