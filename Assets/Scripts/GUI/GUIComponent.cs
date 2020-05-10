namespace TVB.Core.GUI
{
    using UnityEngine;

    using TVB.Core.Attributes;
    
    class GUIComponent : MonoBehaviour
    {
        [GetComponent(true), SerializeField, HideInInspector]
        protected RectTransform RectTransform;
    }
}
