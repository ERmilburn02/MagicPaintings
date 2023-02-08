using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.LockAndKey
{
    public class Exit : MonoBehaviour
    {
        /// <summary>
        /// OnTriggerEnter is called when the Collider other enters the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Win!");
            }
        }
    }
}
