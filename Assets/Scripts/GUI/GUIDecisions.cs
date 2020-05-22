namespace TVB.Game.GUI
{
    using UnityEngine;
    using UnityEngine.UI;

    using TVB.Core.Attributes;
    using TVB.Core.GUI;

    class GUIDecisions : GUIComponent
    {
        [GetComponentInChildren("Left", true), SerializeField, HideInInspector]
        private RectTransform         m_Left;
        [GetComponentInChildren("Left", true), SerializeField, HideInInspector]
        private Button                m_LeftButton;
        [GetComponentInChildren("LeftText", true), SerializeField, HideInInspector]
        private TMPro.TextMeshProUGUI m_LeftText;
        [GetComponentInChildren("Right", true), SerializeField, HideInInspector]
        private RectTransform         m_Right;
        [GetComponentInChildren("Right", true), SerializeField, HideInInspector]
        private Button                m_RightButton;
        [GetComponentInChildren("RightText", true), SerializeField, HideInInspector]
        private TMPro.TextMeshProUGUI m_RightText;
        [GetComponentInChildren("Middle", true), SerializeField, HideInInspector]
        private RectTransform         m_Middle;
        [GetComponentInChildren("Middle", true), SerializeField, HideInInspector]
        private Button                m_MiddleButton;
        [GetComponentInChildren("MiddleText", true), SerializeField, HideInInspector]
        private TMPro.TextMeshProUGUI m_MiddleText;

        public System.Action<int> OnDecisionSelected;

        private void Start()
        {
            m_LeftButton.onClick.AddListener(OnLeftButtonClicked);
            m_RightButton.onClick.AddListener(OnRightButtonClicked);
            m_MiddleButton.onClick.AddListener(OnMiddleButtonClicked);
        }

        public void SetData(string[] decisions)
        {
            var lenght = decisions.Length;

            if (lenght == 1)
            {
                m_Left.gameObject.SetActive(true);
                m_Right.gameObject.SetActive(false);
                m_Middle.gameObject.SetActive(false);

                m_LeftText.text = decisions[0];
            }

            if (lenght == 2)
            {
                m_Left.gameObject.SetActive(true);
                m_Middle.gameObject.SetActive(true);
                m_Right.gameObject.SetActive(false);

                m_LeftText.text  = decisions[0];
                m_MiddleText.text = decisions[1];
            }

            if (lenght > 2)
            {
                m_Left.gameObject.SetActive(true);
                m_Right.gameObject.SetActive(true);
                m_Middle.gameObject.SetActive(true);

                m_LeftText.text   = decisions[0];
                m_MiddleText.text = decisions[1];
                m_RightText.text  = decisions[2];
            }
        }

        // HANDLERS

        private void OnLeftButtonClicked()   => OnDecisionSelected.SafeInvoke(0);
        private void OnMiddleButtonClicked() => OnDecisionSelected.SafeInvoke(1);
        private void OnRightButtonClicked()  => OnDecisionSelected.SafeInvoke(2);
    }
}
