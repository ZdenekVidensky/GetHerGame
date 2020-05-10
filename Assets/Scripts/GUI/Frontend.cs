namespace TVB.Core.GUI
{
    using UnityEngine;
    
    class Frontend : MonoBehaviour
    {
        public Camera UICamera;

        private GUIScreen[] m_Screens;
        
        public void Initialize()
        {
            var m_Screens = GetComponentsInChildren<GUIScreen>();

            for (int idx = 0, count = m_Screens.Length; idx < count; idx++)
            {
                m_Screens[idx].Initialize(this);
            }
        }
    }
}
