namespace TVB.Game.GUI
{
    using TVB.Core.Attributes;
    using UnityEngine;

    class GUIDialogueScreen : MonoBehaviour
    {
        [SerializeField]
        private GUIPlayerComponent m_PlayerComponent;

        [SerializeField]
        private Camera             m_UICamera;

        [GetComponentInChildren("Bubble", true), SerializeField, HideInInspector]
        private RectTransform      m_Bubble;

        private Transform          m_BubbleAnchorTransform;

        private void Start()
        {
            m_BubbleAnchorTransform = m_PlayerComponent.BubbleAnchor.transform;
        }

        private void Update()
        {
            if (m_PlayerComponent == null)
                return;

            if (m_PlayerComponent.IsTalking == false)
                return;

            var newPosition   = new Vector3(m_BubbleAnchorTransform.position.x, m_BubbleAnchorTransform.position.y, m_Bubble.position.z);
            m_Bubble.position = newPosition;
        }
    }
}
