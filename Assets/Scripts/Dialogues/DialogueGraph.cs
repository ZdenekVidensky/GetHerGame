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
                    var output = lineNode.GetPort(nameof(DialogueLineNode.OutputNode))?.Connection;
                    if (output == null)
                        return;

                    ProcessDialogueNode(output.node as BaseDialogueNode);
                    break;
                case DecisionNode decisionNode:
                    for (int idx = 0; idx < decisionNode.Decisions.Length; idx++)
                    {
                        var decision = decisionNode.Decisions[idx];
                        Debug.LogError(decision.Text);
                        var decOutput = decisionNode.GetOutputPort($"{nameof(DecisionNode.Decisions)} {idx}");

                        if (decOutput != null && decOutput.Connection != null)
                        {
                            ProcessDialogueNode(decOutput.Connection.node as BaseDialogueNode);
                        }
                    }
                    break;
            }
        }
    }
}
