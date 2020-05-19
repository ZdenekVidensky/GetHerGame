namespace TVB.Game
{
    using TVB.Game.Characters;
    using UnityEngine;
    
    class DebugComponent : MonoBehaviour
    {
        [SerializeField]
        private BoyCharacter m_BoyCharacter;
        [SerializeField]
        private GirlCharacter m_GirlCharacter;
        [SerializeField]
        private int m_Change = 10;

        // HANDLERS

        public void OnAddAtractivity()
        {
            StartCoroutine(m_GirlCharacter.ChangeAttractivity(m_Change));
        }

        public void OnRemoveAtractivity()
        {
            StartCoroutine(m_GirlCharacter.ChangeAttractivity(-m_Change));
        }
    }
}
