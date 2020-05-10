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

        // HANDLERS

        public void OnAddAtractivity()
        {
            m_GirlCharacter.AddAtractivity(10);
        }

        public void OnRemoveAtractivity()
        {
            m_GirlCharacter.AddAtractivity(-10);
        }
    }
}
