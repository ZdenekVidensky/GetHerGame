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
            yield return new WaitForSeconds(Mathf.Clamp(text.Length / 10f, 1f, 2.5f));
            IsTalking = false;
        }
    }
}
