namespace TVB.Core
{
    using System.Collections;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        private SceneDirector m_ActiveSceneDirector;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private IEnumerator Start()
        {
            if (m_ActiveSceneDirector == null)
            {
                m_ActiveSceneDirector = FindObjectOfType(typeof(SceneDirector)) as SceneDirector;
            }

            m_ActiveSceneDirector.Initialize();
            yield return null;
        }

        private void Update()
        {
            if (m_ActiveSceneDirector == null)
                return;

            m_ActiveSceneDirector.Update();
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
