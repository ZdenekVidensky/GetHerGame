using UnityEngine;

namespace TVB.Game.Characters
{
    class GirlCharacter : CharacterBase
    {
        public int Atractivity => m_Atracitivity;

        private int m_Atracitivity = 0;

        public override void Initialize()
        {
            base.Initialize();
            m_Atracitivity = 0;
        }

        public void AddAtractivity(int value)
        {
            m_Atracitivity = Mathf.Clamp(m_Atracitivity + value, 0, int.MaxValue);
            Debug.Log($"Girl: Atractivity changed on {m_Atracitivity}");
        }
    }
}
