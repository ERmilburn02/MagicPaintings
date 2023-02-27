using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MagicPaintings.LockAndKey
{
    public class InputManager : MonoBehaviour
    {
        private Piece m_CurrentPiece = null;

        private Camera m_Cam = null;


        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            m_Cam = Camera.main;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            Vector2 MousePos = Mouse.current.position.ReadValue();
            Vector3 MouseWorldPos = m_Cam.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, 9f));
            bool WasPressed = Mouse.current.leftButton.wasPressedThisFrame;

            if (!Mouse.current.leftButton.isPressed)
            {
                if (m_CurrentPiece != null)
                {
                    m_CurrentPiece.Stop();
                    m_CurrentPiece = null;
                }
            }

            if (WasPressed)
            {
                Collider[] intersecting = Physics.OverlapSphere(MouseWorldPos, 0.01f);
                if (intersecting.Length != 0)
                {
                    foreach (Collider col in intersecting)
                    {
                        if (col.TryGetComponent<Piece>(out Piece piece))
                        {
                            m_CurrentPiece = piece;
                        }
                    }
                }
            }

            if (m_CurrentPiece != null)
            {
                m_CurrentPiece.MoveTowards(MouseWorldPos);
            }

        }
    }
}
