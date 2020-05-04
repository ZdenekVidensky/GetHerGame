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

        public void PushTree(DialogueTree tree)
        {
            if (m_ActiveTree == null)
            {
                m_ActiveTree = tree;
                m_ProcessingCoroutine = StartCoroutine(ProcessActiveTree(tree));
            }
            else
            {
                m_TreesStack.Push(tree);
            }

            m_DialogueGraph.GoThroughNodes();
        }

        // PRIVATE METHODS

        private IEnumerator ProcessActiveTree(DialogueTree tree)
        {
            yield return ProcessNodes(tree.RootNodes);
            m_ActiveTree = null;
        }

        private IEnumerator ProcessNodes(TreeNode[] nodes)
        {
            for (int idx = 0; idx < nodes.Length; idx++)
            {
                yield return ProcessNode(nodes[idx]);
            }
        }

        private IEnumerator ProcessNode(TreeNode node)
        {
            switch (node)
            {
                case DialogueNode dialogueNode:
                    yield return ProcessDialogueNode(dialogueNode);
                    break;
                case ChooseNode chooseNode:
                    yield return ProcessChooseNode(chooseNode);
                    break;
            }
        }

        private IEnumerator ProcessDialogueNode(DialogueNode dialogueNode)
        {
            var duration = (float)dialogueNode.Text.Length / 10;
            Debug.Log(dialogueNode.Text);
            yield return new WaitForSeconds(duration);
        }

        private IEnumerator ProcessChooseNode(ChooseNode chooseNode)
        {
            m_Selection = 0;

            for (int idx = 0; idx < chooseNode.Choices.Length; idx++)
            {
                Debug.LogError($"{idx} - {chooseNode.Choices[idx].Text}");
            }

            var duration = chooseNode.DecisionDuration;

            while(duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return null;
            }

            yield return ProcessNodes(chooseNode.Choices[0].Nodes);
        }
    }
}
