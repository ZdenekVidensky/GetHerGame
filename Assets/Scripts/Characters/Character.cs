namespace TVB.Game.Characters
{
    using System.Collections;
    using UnityEngine;
    
    public abstract class Character : MonoBehaviour
    {
        public Transform BubbleAnchor;
        public Color     Color;
        public bool      IsTalking;
        public bool      IsBusy;

        public virtual void Initialize()
        {
            IsTalking = false;
            IsBusy    = false;
        }

        public virtual IEnumerator Talk(string text)
        {
            IsTalking = true;
            yield return new WaitForSeconds(text.Length / 5f);
            IsTalking = false;
        }
    }
}
