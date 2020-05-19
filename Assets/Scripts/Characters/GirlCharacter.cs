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

        private static int TalkingHash   = Animator.StringToHash("IsTalking");
        private static int AngryHash     = Animator.StringToHash("Angry");
        private static int LooserHash    = Animator.StringToHash("Looser");
        private static int LaughtingHash = Animator.StringToHash("Laughting");

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

        // Animations

        public void Laught()
        {
            m_Animator.SetTrigger(LaughtingHash);
        }

        public void StartTalking()
        {
            m_Animator.SetBool(TalkingHash, true);
        }

        public void StopTalking()
        {
            m_Animator.SetBool(TalkingHash, false);
        }

        public void Angry()
        {
            m_Animator.SetTrigger(AngryHash);
        }

        public void Looser()
        {
            m_Animator.SetTrigger(LooserHash);
        }
    }
}
