using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.LockAndKey
{
    [RequireComponent(typeof(Rigidbody))]
    public class Piece : MonoBehaviour
    {
        [SerializeField] private bool m_CanMoveX;
        [SerializeField] private bool m_CanMoveY;

        private Rigidbody m_RB;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            m_RB = GetComponent<Rigidbody>();

            if (!m_CanMoveX)
                m_RB.constraints |= RigidbodyConstraints.FreezePositionX;

            if (!m_CanMoveY)
                m_RB.constraints |= RigidbodyConstraints.FreezePositionY;
        }

        public void MoveTowards(Vector3 targetPosition)
        {
            if (!m_CanMoveX)
                targetPosition.x = transform.position.x;
            if (!m_CanMoveY)
                targetPosition.y = transform.position.y;

            Vector3 move = targetPosition - transform.position;
            Vector3 direction = move.normalized;
            float speed = Vector3.Distance(targetPosition, transform.position);
            if (speed < 0.01)
                return;

            m_RB.velocity = direction * speed;
        }

        public void Stop()
        {
            m_RB.velocity = Vector3.zero;
        }
    }
}
