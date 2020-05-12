namespace TVB.Core
{
    using UnityEngine;
    
    public abstract class SceneDirector : MonoBehaviour
    {
        public abstract bool IsFinished { get; }

        public abstract void Initialize();
        public abstract void Play();
        public abstract void OnUpdate();
        public abstract void Deinitialize();
    }
}
