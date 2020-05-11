namespace TVB.Game.Dialogues
{
    using UnityEngine;

    [CreateNodeMenu("ChangeAtractivityNode"), NodeTint("#55592c")]
    class ChangeAtractivityNode : BaseDialogueNode
    {
        [Input]  public BaseDialogueNode InputNode;
        [Output] public BaseDialogueNode OutputNode;

        public int ChangedValue;
    }
}

