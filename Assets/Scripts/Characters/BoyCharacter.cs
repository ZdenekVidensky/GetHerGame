namespace TVB.Game.Characters
{
    using System.Collections;
    using TVB.Game.Dialogues;
    using UnityEngine;

    class BoyCharacter : Character
    {
        // CONFIGURATION

        [SerializeField]
        private Animator m_Animator;
        
        public DialogueManager DialogueManager;

        private static int TalkingHash = Animator.StringToHash("IsTalking");

        public override IEnumerator Talk(string text)
        {
            StartTalkingAnimation();
            yield return base.Talk(text);
            StopTalkingAnimation();
        }

        public void StartTalkingAnimation()
        {
            m_Animator.SetBool(TalkingHash, true);
        }

        public void StopTalkingAnimation()
        {
            m_Animator.SetBool(TalkingHash, false);
        }
    }
}
