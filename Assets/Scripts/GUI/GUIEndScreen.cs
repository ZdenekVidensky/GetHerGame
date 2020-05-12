namespace TVB.Game.GUI
{
    using UnityEngine;
    using UnityEngine.UI;

    using TVB.Core.GUI;
    using TVB.Core.Attributes;

    class GUIEndScreen : GUIScreen
    {
        public bool IsFinished = false;

        [GetComponent(true), SerializeField, HideInInspector]
        private Animation m_Animation;
        [GetComponentInChildren("Button", true), SerializeField, HideInInspector]
        private Button    m_Button;

        public override void Initialize(Frontend frontend)
        {
            base.Initialize(frontend);

            m_Button.onClick.AddListener(OnButtonClick);
        }

        public override void Deinitialize()
        {
            m_Button.onClick.RemoveListener(OnButtonClick);

            base.Deinitialize();
        }


        public void PlayGoodEnding()
        {
            m_Animation.Play("GoodEnding");
        }

        public void PlayBadEnding()
        {
            m_Animation.Play("BadEnding");
        }

        // HANDLERS

        private void OnButtonClick()
        {
            IsFinished = true;
            this.SetActive(false);
        }
    }
}
