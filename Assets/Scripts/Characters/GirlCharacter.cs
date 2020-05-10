using TVB.Game.Dialogues;
using UnityEngine;

namespace TVB.Game.Characters
{
    class GirlCharacter : Character
    {
        public DialogueGraph DialogueGraph;
        public int           Atractivity;

        public override void Initialize()
        {
            base.Initialize();
            Atractivity = 0;
        }

        public void AddAtractivity(int value)
        {
            Atractivity = Mathf.Clamp(Atractivity + value, 0, int.MaxValue);
            Debug.Log($"Girl: Atractivity changed on {Atractivity}");
        }
    }
}
