namespace TVB.Core
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        private SceneDirector m_ActiveSceneDirector;
        //private static bool GameManagerExists;

        private void Awake()
        {
            //if (GameManagerExists == false)
            //{
            //    GameManagerExists = true;
            //    DontDestroyOnLoad(this.gameObject);
            //}
            //else
            //{
            //    Destroy(this.gameObject);
            //}
        }

        private void Start()
        {
            if (m_ActiveSceneDirector == null)
            {
                m_ActiveSceneDirector = FindObjectOfType(typeof(SceneDirector)) as SceneDirector;
            }

            m_ActiveSceneDirector.Initialize();
            m_ActiveSceneDirector.Play();
        }

        private void Update()
        {
            if (m_ActiveSceneDirector == null)
                return;

            m_ActiveSceneDirector.OnUpdate();

            if (m_ActiveSceneDirector.IsFinished == true)
            {
                SceneManager.LoadScene("MainScene");
                m_ActiveSceneDirector = FindObjectOfType(typeof(SceneDirector)) as SceneDirector;
                m_ActiveSceneDirector.Initialize();
                m_ActiveSceneDirector.Play();
            }
        }

        private void OnDestroy()
        {
            if (m_ActiveSceneDirector != null)
            {
                m_ActiveSceneDirector.Deinitialize();
            }
        }
    }
}
