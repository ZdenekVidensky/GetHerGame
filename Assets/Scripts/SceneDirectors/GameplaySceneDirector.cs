namespace TVB.Game
{
    using UnityEngine;

    using TVB.Core;
    using TVB.Game.Characters;
    using TVB.Core.GUI;

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
        private Frontend      m_Frontend;

        private bool          m_IsFinished          = false;
        private bool          m_AtractivityAchieved = false;
        private int           m_AtractivityCheckInterval = 30;

        // SCENEDIRECTOR INTERFACE

        public override bool IsFinished => m_IsFinished;


        public override void Initialize()
        {
            m_BoyCharacter.Initialize();
            m_GirlCharacter.Initialize(m_InitAtractivity, m_GoalAtractivity);
            m_Frontend.Initialize();

            Debug.Log("GameplaySceneDirector initialized!");
        }

        public override void Play()
        {

        }

        public override void Update()
        {
            if (m_AtractivityAchieved == true)
                return;

            if (Time.frameCount % m_AtractivityCheckInterval != 0)
                return;

            var atractivity = m_GirlCharacter.Atractivity;

            if (atractivity >= m_GoalAtractivity || atractivity <= 0)
            {
                OnAtractivityAchieved(atractivity);
                m_AtractivityAchieved = true;
            }
        }
        public override void Deinitialize()
        {
            
        }

        // PRIVATE METHODS

        private void OnAtractivityAchieved(int atractivity)
        {
            Debug.LogError($"Game Over! Final atractivity: {atractivity}");
            m_IsFinished = true;
        }
    }
}
