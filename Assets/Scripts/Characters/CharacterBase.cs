namespace TVB.Game.Characters
{
    using UnityEngine;
    
    public abstract class CharacterBase : MonoBehaviour
    {
        public Color Color;
        public bool  IsTalking;

        public virtual void Initialize()
        {
            IsTalking = false;
        }

        public virtual void Talk()
        {

        }
    }
}
