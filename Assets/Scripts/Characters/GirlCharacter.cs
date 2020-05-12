﻿using System.Collections;
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

        [Header("GUI"), SerializeField]
        private GUIGirlHUD m_GirlHUD;
        [GetComponent(true), SerializeField, HideInInspector]
        private InteractableObject m_InteractableObject;

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
    }
}
