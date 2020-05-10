namespace TVB.Game.GUI
{
    using UnityEngine;
    using UnityEngine.UI;

    using TVB.Core.Attributes;
    using TVB.Core.GUI;

    class GUIBubble : GUIComponent
    {
        [GetComponent(true), SerializeField, HideInInspector]
        private Image m_Image;

        public void SetData(Vector3 position, Color color, bool flipped = false)
        {
            m_Image.color = color;
            var newPosition = new Vector3(position.x, position.y, RectTransform.position.z);
            RectTransform.position = newPosition;
        }
    }
}
