using TVB.Core.Attributes;
using UnityEngine;

namespace TVB.Game.GUI
{
    class GUIPlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private Color m_Color;

        [GetComponentInChildren("BubbleAnchor", true), SerializeField, HideInInspector]
        private Transform m_BubbleAnchor;

        [GetComponent(true), SerializeField, HideInInspector]
        private DialogueComponent m_DialogueComponent;

        public Transform BubbleAnchor     => m_BubbleAnchor;
        public Color     Color            => m_Color;
        public bool      IsTalking        => m_DialogueComponent.IsTalking;
    }
}
