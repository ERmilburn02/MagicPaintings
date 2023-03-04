using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_MenuCamera;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            m_MenuCamera.SetActive(true);
        }

        public void OnPlayButtonClick()
        {
            StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            m_MenuCamera.SetActive(false);

            yield return new WaitForSeconds(2);

            Loader.Instance.LoadGame();
        }
    }
}
