namespace TVB.Game
{
    using System.Collections;

    using UnityEngine;

    using TVB.Core;
    using TVB.Game.Characters;
    using TVB.Core.GUI;
    using TVB.Game.GUI;

    class GameplaySceneDirector : SceneDirector
    {
        [SerializeField]
        private BoyCharacter  m_BoyCharacter;
        [SerializeField]
        private GirlCharacter m_GirlCharacter;
        [SerializeField]
        private int           m_GoalAtractivity = 100;
        [SerializeField]
        private int           m_InitAtractivity = 20;

        [SerializeField]
        private Frontend      m_Frontend; // TODO

        [SerializeField]
        private GUIEndScreen  m_EndScreen;

        private bool          m_IsFinished               = false;
        private bool          m_AtractivityAchieved      = false;
        private bool          m_IsPlaying                = false;
        private int           m_AtractivityCheckInterval = 30;

        // SCENEDIRECTOR INTERFACE

        public override bool IsFinished => m_IsFinished;


        public override void Initialize()
        {
            m_BoyCharacter.Initialize();
            m_GirlCharacter.Initialize(m_InitAtractivity, m_GoalAtractivity);
            m_Frontend.Initialize();
            m_IsFinished = false;
            m_IsPlaying  = false;
        }

        public override void Play()
        {
            m_IsPlaying = true;
            m_EndScreen.SetActive(false);
        }

        public override void OnUpdate()
        {
            if (m_IsPlaying == false)
                return;

            if (m_AtractivityAchieved == true)
                return;

            if (Time.frameCount % m_AtractivityCheckInterval != 0)
                return;

            var atractivity = m_GirlCharacter.Atractivity;

            if (atractivity >= m_GoalAtractivity || atractivity <= 0)
            {
                StartCoroutine(OnAtractivityAchieved(atractivity));
                m_AtractivityAchieved = true;
            }
        }

        public override void Deinitialize()
        {
            
        }

        // PRIVATE METHODS

        private IEnumerator OnAtractivityAchieved(int atractivity)
        {
            m_BoyCharacter.CanMove = false;
            m_GirlCharacter.SetInactive();

            m_EndScreen.SetActive(true);
            
            if (atractivity >= m_GoalAtractivity)
            {
                m_EndScreen.PlayGoodEnding();
            }
            else
            {
                m_EndScreen.PlayBadEnding();
            }

            while (m_EndScreen.IsFinished == false)
                yield return null;

            m_IsFinished = true;
        }
    }
}
