namespace TVB.Game.Dialogues
{
    using UnityEngine;

    using XNode;

    [CreateNodeMenu("DecisionNode"), System.Serializable]
    class DecisionNode : BaseDialogueNode
    {
        [Input] public BaseDialogueNode InputNode;

        [Output(dynamicPortList = true)] public string[] Decisions;
    }
}

