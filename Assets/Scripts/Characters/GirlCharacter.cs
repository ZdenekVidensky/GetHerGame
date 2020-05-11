using TVB.Game.Dialogues;
using TVB.Game.GUI;
using UnityEngine;

namespace TVB.Game.Characters
{
    class GirlCharacter : Character
    {
        public DialogueGraph DialogueGraph;
        public int           Atractivity;

        [Header("GUI"), SerializeField]
        private GUIGirlHUD m_GirlHUD;

        public void Initialize(int initAtractivity, int goalAtractivity)
        {
            Atractivity = initAtractivity;
            m_GirlHUD.Initialize(initAtractivity, goalAtractivity);
        }

        public override void Initialize()
        {
            base.Initialize();
            Atractivity = 0;
        }

        public void ChangeAttractivity(int changedValue)
        {
            StartCoroutine(m_GirlHUD.ChangeValue(changedValue));

            Atractivity = Mathf.Clamp(Atractivity + changedValue, 0, int.MaxValue);
            Debug.Log($"Girl: Atractivity changed on {Atractivity}");
        }
    }
}
