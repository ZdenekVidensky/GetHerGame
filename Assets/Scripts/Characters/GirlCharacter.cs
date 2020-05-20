using System.Collections;
using TVB.Core.Attributes;
using TVB.Game.Dialogues;
using TVB.Game.GUI;
using UnityEngine;

namespace TVB.Game.Characters
{
    class GirlCharacter : Character
    {

        public DialogueGraph DialogueGraph;
        public int           Atractivity;

        [SerializeField]
        private Animator m_Animator;

        [Header("GUI"), SerializeField]
        private GUIGirlHUD m_GirlHUD;
        [GetComponent(true), SerializeField, HideInInspector]
        private InteractableObject m_InteractableObject;

        private static int            TalkingHash     = Animator.StringToHash("IsTalking");
        private static int            AngryHash       = Animator.StringToHash("Angry");
        private static int            LooserHash      = Animator.StringToHash("Loser");
        private static int            HappyHash       = Animator.StringToHash("Happy");
        private static WaitForSeconds TransitionWait  = new WaitForSeconds(0.3f);

        public void Initialize(int initAtractivity, int goalAtractivity)
        {
            Atractivity = initAtractivity;
            m_GirlHUD.Initialize(initAtractivity, goalAtractivity);
            m_GirlHUD.SetActive(true);
        }

        public override void Initialize()
        {
            base.Initialize();
            Atractivity = 0;
        }

        public IEnumerator ChangeAttractivity(int changedValue)
        {
            if (changedValue < 0)
            {
                yield return PlayAngryAnimation_Coroutine();
            }

            yield return m_GirlHUD.ChangeValue(changedValue);
            Atractivity = Mathf.Clamp(Atractivity + changedValue, 0, int.MaxValue);
        }

        public void SetInteractable(bool state)
        {
            m_InteractableObject.SetGUIActive(state);
        }

        public void SetInactive()
        {
            m_GirlHUD.SetActive(false);
        }

        public override IEnumerator Talk(string text)
        {
            StartTalkingAnimation();
            yield return base.Talk(text);
            StopTalkingAnimation();
        }

        // Animations

        public IEnumerator PlayHappyAnimatoin_Coroutine()
        {
            m_Animator.SetTrigger(HappyHash);

            yield return TransitionWait;
            while (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == HappyHash)
                yield return null;
        }

        public void StartTalkingAnimation()
        {
            m_Animator.SetBool(TalkingHash, true);
        }

        public void StopTalkingAnimation()
        {
            m_Animator.SetBool(TalkingHash, false);
        }

        public IEnumerator PlayAngryAnimation_Coroutine()
        {
            m_Animator.SetTrigger(AngryHash);
            yield return TransitionWait;
            while (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == AngryHash)
                yield return null;
        }

        public IEnumerator PlayLooserAnimation_Coroutine()
        {
            m_Animator.SetTrigger(LooserHash);
            yield return TransitionWait;
            while (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == LooserHash)
                yield return null;
        }
    }
}
