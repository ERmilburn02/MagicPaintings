using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using MagicPaintings.Generics;
using MagicPaintings.ScriptableObjects;

namespace MagicPaintings
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField]
        private List<AudioSO> m_Clips = null;

        [SerializeField]
        private AudioMixer m_Mixer = null;

        [SerializeField]
        private AudioMixerGroup m_MusicGroup = null;

        [SerializeField]
        private AudioMixerGroup m_SFXGroup = null;

        [SerializeField]
        private Dictionary<string, AudioSource> m_LoopingClips = new Dictionary<string, AudioSource>();

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(gameObject);
        }

        private AudioSO FindAudio(string name)
        {
            foreach (var item in m_Clips)
            {
                if (item.audioName == name)
                {
                    return item;
                }
            }

            return null;
        }

        public void StopLoopingClip(string name)
        {
            foreach (var item in m_LoopingClips)
            {
                if (item.Key == name)
                {
                    item.Value.Stop();
                    Destroy(item.Value.gameObject);
                    m_LoopingClips.Remove(item.Key);
                    return;
                }
            }

            Debug.LogWarning($"No Looping Audio found with name {name}");
        }

        public void PlayClip(string name)
        {
            AudioSO so = FindAudio(name);

            if (so == null)
            {
                return;
            }

            foreach (var item in m_LoopingClips)
            {
                if (item.Key == name)
                {
                    Debug.LogWarning($"Attempted to play Looping Audio ({name}) multiple times!");
                    return;
                }
            }

            GameObject go = new GameObject("Audio");
            AudioSource source = go.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = so.audioClip;
            source.loop = so.shouldLoop;

            switch (so.category)
            {
                case AudioSO.AudioSOCategory.MUSIC:
                    source.outputAudioMixerGroup = m_MusicGroup;
                    break;

                case AudioSO.AudioSOCategory.SFX:
                    source.outputAudioMixerGroup = m_SFXGroup;
                    break;

                case AudioSO.AudioSOCategory.NONE:
                default:
                    break;
            }

            if (so.shouldLoop)
            {
                m_LoopingClips.Add(name, source);
                DontDestroyOnLoad(source.gameObject);
            }

            source.Play();
        }
    }
}
