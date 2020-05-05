namespace TVB.Dialogue
{
    using UnityEngine;

    using XNode;

    [CreateNodeMenu("DecisionNode"), System.Serializable]
    class DecisionNode : BaseDialogueNode
    {
        [Input] public BaseDialogueNode InputNode;

        [Output(dynamicPortList = true)] public Decision[] Decisions;
    }

    [System.Serializable]
    public struct Decision
    {
        public string Text;
    }
}

