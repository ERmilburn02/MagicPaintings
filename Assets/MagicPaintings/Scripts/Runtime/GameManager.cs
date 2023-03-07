using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MagicPaintings.Generics;

namespace MagicPaintings
{
    public class GameManager : Singleton<GameManager>
    {
        public UnityEvent OnPuzzleComplete;

        [SerializeField]
        private GameObject m_BoardPrefab = null;

        [SerializeField]
        private GameObject m_Board6x6ExtensionPrefab = null;

        [SerializeField]
        private GameObject m_PlayerPrefab = null;

        [SerializeField]
        private GameObject m_Player6x6Prefab = null;

        [SerializeField]
        private List<GameObject> m_LayoutPrefabs = new List<GameObject>();

        [SerializeField]
        private List<GameObject> m_Layout6x6Prefabs = new List<GameObject>();

        private Transform m_SpawnParent;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            m_SpawnParent = new GameObject("Spawn Parent").transform;

            SpawnPuzzle();
        }

        public void SpawnPuzzle()
        {
            bool hasBigRemaining = m_LayoutPrefabs.Count > 0;
            bool hasSmallRemaining = m_Layout6x6Prefabs.Count > 0;

            if (!hasBigRemaining && !hasSmallRemaining)
            {
                Menus.Loader.Instance.LoadWin();

                return;
            }

            int totalPuzzlesRemaining = m_LayoutPrefabs.Count + m_Layout6x6Prefabs.Count;

            int chosenPuzzle = Random.Range(0, totalPuzzlesRemaining);

            if (chosenPuzzle > m_LayoutPrefabs.Count - 1)
            {
                chosenPuzzle -= m_LayoutPrefabs.Count;
                SpawnSmallLayout();
                Instantiate(m_Layout6x6Prefabs[chosenPuzzle], m_SpawnParent);
                m_Layout6x6Prefabs.RemoveAt(chosenPuzzle);
            }
            else
            {
                SpawnLayout();
                Instantiate(m_LayoutPrefabs[chosenPuzzle], m_SpawnParent);
                m_LayoutPrefabs.RemoveAt(chosenPuzzle);
            }
        }

        private void SpawnSmallLayout()
        {
            // Instantiate(m_BoardPrefab, m_SpawnParent);
            // Instantiate(m_Board6x6ExtensionPrefab, m_SpawnParent);
            Instantiate(m_Player6x6Prefab, m_SpawnParent);
        }

        private void SpawnLayout()
        {
            // Instantiate(m_BoardPrefab, m_SpawnParent);
            Instantiate(m_PlayerPrefab, m_SpawnParent);
        }

        public void OnPuzzleCompleteCallback()
        {
            foreach (var child in m_SpawnParent.GetComponentsInChildren<Transform>())
            {
                if (child != m_SpawnParent)
                {
                    Destroy(child.gameObject);
                }
            }

            // TODO: Delay Spawn

            SpawnPuzzle();
        }
    }
}
