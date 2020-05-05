namespace TVB.Dialogue
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DialogueManager : MonoBehaviour
    {
        private DialogueTree        m_ActiveTree;
        private Coroutine           m_ProcessingCoroutine;
        private Stack<DialogueTree> m_TreesStack = new Stack<DialogueTree>();
        private int                 m_Selection;

        [SerializeField]
        private DialogueGraph m_DialogueGraph;

        public void ProcessGraph()
        {
            m_DialogueGraph.GoThroughNodes();
        }
    }
}
