using UnityEngine;

namespace TwentyFortyEight.Utils
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public SceneLoader SceneLoader { get; private set; }


        private void Awake()
        {
            SceneLoader = new SceneLoader();
        }


        public void LoadScene(int sceneId)
        {
            SceneLoader.LoadScene(sceneId);
        }
        public void ReloadCurrentScene()
        {
            SceneLoader.ReloadCurrentScene();
        }
    }
}