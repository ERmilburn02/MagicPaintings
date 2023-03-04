using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicPaintings
{
    public static class SceneLoader
    {
        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadScene(Scenes scene, bool additive = false)
        {
            SceneManager.LoadScene((int)scene, (additive ? LoadSceneMode.Additive : LoadSceneMode.Single));
        }

        public static AsyncOperation UnloadScene()
        {
            return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public static AsyncOperation UnloadScene(Scenes scene)
        {
            return SceneManager.UnloadSceneAsync((int)scene);
        }
    }
}
