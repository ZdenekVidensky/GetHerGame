namespace TVB.Dialogue
{
    using UnityEngine;
    using XNode;

    [CreateAssetMenu]
    public class DialogueGraph : NodeGraph
    {
        public void GoThroughNodes()
        {
            if (nodes.Count == 0)
                return;

            if (nodes[0] is BaseDialogueNode dialogueNode)
            {
                ProcessDialogueNode(dialogueNode);
            }
        }

        public void ProcessDialogueNode(BaseDialogueNode node)
        {
            if (node == null)
                return;

            switch (node)
            {
                case DialogueLineNode lineNode:
                    Debug.LogError(lineNode.TextValues[0].Text);
                    break;
                case DecisionNode decisionNode:
                    foreach(var decision in decisionNode.Decisions)
                    {
                        Debug.LogError(decision.Text);
                    }
                    break;
            }

            var output = node.GetPort("OutputNode").Connection;
            if (output == null)
                return;

            ProcessDialogueNode(output.node as BaseDialogueNode);
        }
    }
}
