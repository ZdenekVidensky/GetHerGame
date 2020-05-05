namespace TVB.Game
{
    using TVB.Core.Attributes;
    using TVB.Dialogue;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [GetComponent(true), SerializeField, HideInInspector]
        private DialogueManager m_DialogueManager;

        void Start()
        {
            m_DialogueManager.ProcessGraph();
        }
    }
}
