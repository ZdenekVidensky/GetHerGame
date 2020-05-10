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
        private Frontend      m_Frontend;

        private bool          m_IsFinished          = false;
        private bool          m_AtractivityAchieved = false;

        // SCENEDIRECTOR INTERFACE

        public override bool IsFinished => m_IsFinished;


        public override void Initialize()
        {
            m_BoyCharacter.Initialize();
            m_GirlCharacter.Initialize();
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

            if (m_GirlCharacter.Atractivity >= m_GoalAtractivity)
            {
                OnAtractivityAchieved();
                m_AtractivityAchieved = true;
            }
        }
        public override void Deinitialize()
        {
            
        }

        // PRIVATE METHODS

        private void OnAtractivityAchieved()
        {
            Debug.LogError("Game Over!");
            m_IsFinished = true;
        }
    }
}
