namespace TVB.Game
{
    using UnityEngine;
    using TVB.Game.Characters;
    
    class CharactersDebug : MonoBehaviour
    {
        [SerializeField]
        private GirlCharacter m_GirlCharacter;

        [Header("Girl")]
        [SerializeField] private bool m_Laught;
        [SerializeField] private bool m_StartTalking;
        [SerializeField] private bool m_StopTalking;
        [SerializeField] private bool m_Angry;
        [SerializeField] private bool m_Looser;

        private void Update()
        {
            if (m_Laught == true)
            {
                m_GirlCharacter.Laught();
                m_Laught = false;
            }

            if (m_StartTalking == true)
            {
                m_GirlCharacter.StartTalking();
                m_StartTalking = false;
            }

            if (m_StopTalking == true)
            {
                m_GirlCharacter.StopTalking();
                m_StopTalking = false;
            }

            if (m_Angry == true)
            {
                m_GirlCharacter.Angry();
                m_Angry = false;
            }

            if (m_Looser == true)
            {
                m_GirlCharacter.Looser();
                m_Looser = false;
            }
        }
    }
}
