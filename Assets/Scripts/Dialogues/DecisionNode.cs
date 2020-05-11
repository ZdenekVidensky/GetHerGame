namespace TVB.Game.Dialogues
{
    using UnityEngine;

    [CreateNodeMenu("DecisionNode"), NodeTint("#49eb45")]
    class DecisionNode : BaseDialogueNode
    {
        [Input] public BaseDialogueNode InputNode;

        [Output(dynamicPortList = true)] public string[] Decisions;
    }
}

