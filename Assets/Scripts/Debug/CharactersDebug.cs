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
                StartCoroutine(m_GirlCharacter.PlayHappyAnimatoin_Coroutine());
                m_Laught = false;
            }

            if (m_StartTalking == true)
            {
                m_GirlCharacter.StartTalkingAnimation();
                m_StartTalking = false;
            }

            if (m_StopTalking == true)
            {
                m_GirlCharacter.StopTalkingAnimation();
                m_StopTalking = false;
            }

            if (m_Angry == true)
            {
                StartCoroutine(m_GirlCharacter.PlayAngryAnimation_Coroutine());
                m_Angry = false;
            }

            if (m_Looser == true)
            {
                StartCoroutine(m_GirlCharacter.PlayLooserAnimation_Coroutine());
                m_Looser = false;
            }
        }
    }
}
