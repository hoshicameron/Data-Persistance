using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int menuSceneIndex;
        [SerializeField] private int mainSceneIndex;

        private void LoadScene(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void LoadMenu()
        {
            LoadScene(menuSceneIndex);
        }

        public void LoadMain() => LoadScene(mainSceneIndex);

        public void Quit()
        {
            GameManager.Instance.SaveData();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else   
            Application.Quit();
#endif
        }
    }
}