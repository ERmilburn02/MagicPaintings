using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Audio", menuName = "ScriptableObjects/Audio")]
    public class AudioSO : ScriptableObject
    {
        public string audioName = string.Empty;
        public AudioClip audioClip = null;
        public bool shouldLoop = false;
        public AudioSOCategory category = AudioSOCategory.NONE;

        public enum AudioSOCategory
        {
            NONE,
            MUSIC,
            SFX
        }
    }
}
