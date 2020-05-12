namespace TVB.Game
{
    using UnityEngine;
    
    using TVB.Game.GUI;
    
    [RequireComponent(typeof(Collider))]
    class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        private GUIInteractableObject m_GUIObject;

        public void SetText(string text)
        {
            m_GUIObject.SetText(text);
        }

        public void SetGUIActive(bool state)
        {
            m_GUIObject.SetActive(state);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                m_GUIObject.ShowText();
            }
        }
        
        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                m_GUIObject.HideText();
            }
        }
    }
}
