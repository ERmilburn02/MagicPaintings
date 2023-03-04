using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.Menus
{
    public class Loader : Singleton<Loader>
    {
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            LoadInitial();
        }

        public void LoadInitial()
        {
            SceneLoader.LoadScene(Scenes.VOID, true);
            SceneLoader.LoadScene(Scenes.MAINMENU, true);
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadMenuE());
        }

        public void LoadGame()
        {
            StartCoroutine(LoadGameE());
        }

        public void LoadWin()
        {
            StartCoroutine(LoadWinE());
        }

        private IEnumerator LoadMenuE()
        {
            AsyncOperation op = SceneLoader.UnloadScene(Scenes.WIN);

            while (!op.isDone)
            {
                yield return null;
            }

            SceneLoader.LoadScene(Scenes.MAINMENU, true);
        }

        private IEnumerator LoadGameE()
        {
            AsyncOperation op = SceneLoader.UnloadScene(Scenes.MAINMENU);

            while (!op.isDone)
            {
                yield return null;
            }

            SceneLoader.LoadScene(Scenes.GAME, true);
        }

        private IEnumerator LoadWinE()
        {
            AsyncOperation op = SceneLoader.UnloadScene(Scenes.GAME);

            while (!op.isDone)
            {
                yield return null;
            }

            SceneLoader.LoadScene(Scenes.WIN, true);
        }
    }
}
