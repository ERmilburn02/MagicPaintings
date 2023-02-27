using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicPaintings
{
    public class GameManager : Singleton<GameManager>
    {
        public UnityEvent OnPuzzleComplete;

        public void TempOnPuzzleCompleteCallback()
        {
            Debug.Log("WIN - But inside GameManager now");
        }
    }
}
