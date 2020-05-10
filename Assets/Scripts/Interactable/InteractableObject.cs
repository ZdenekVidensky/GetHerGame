namespace TVB.Game
{
    using UnityEngine;
    
    [RequireComponent(typeof(Collider))]
    class InteractableObject : MonoBehaviour
    {
        private bool m_PlayerIn = false;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                m_PlayerIn = true;
            }
        }
        
        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                m_PlayerIn = false;
            }
        }
    }
}
