namespace TVB.Core.GUI
{
    using UnityEngine;
    
    class GUIScreen : MonoBehaviour
    {
        protected Frontend Frontend;

        public virtual void Initialize(Frontend frontend)
        {
            Frontend = frontend;
        }

        public virtual void Deinitialize() { }
    }
}
