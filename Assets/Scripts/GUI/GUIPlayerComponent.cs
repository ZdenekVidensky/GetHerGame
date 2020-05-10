namespace TVB.Game.GUI
{
    using UnityEngine;
    using TVB.Core.Attributes;
    
    class GUIPlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private Color m_Color;

        [GetComponentInChildren("BubbleAnchor", true), SerializeField, HideInInspector]
        private Transform m_BubbleAnchor;

        public Transform BubbleAnchor     => m_BubbleAnchor;
        public Color     Color            => m_Color;
    }
}
