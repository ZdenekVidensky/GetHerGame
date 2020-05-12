namespace TVB.Game.GUI
{
    using UnityEngine;

    using TVB.Core.Attributes;
    using TVB.Core.GUI;

    class GUIInteractableObject : GUIComponent
    {
        [GetComponent(true), SerializeField, HideInInspector]
        private Animation m_Animation;
        [GetComponentInChildren("Text", true), SerializeField, HideInInspector]
        private TMPro.TextMeshProUGUI m_Text;

        public void SetText(string text)
        {
            m_Text.text = text;
        }

        public void ShowText()
        {
            var clipName = m_Animation.clip.name;
            m_Animation[clipName].speed = 1;
            m_Animation[clipName].time  = 0;
            m_Animation.Play();
        }

        public void HideText()
        {
            var clipName = m_Animation.clip.name;
            m_Animation[clipName].speed = -1;
            m_Animation[clipName].time = m_Animation[clipName].length;
            m_Animation.Play();
        }
    }
}
