namespace TVB.Game.Dialogues
{
    using UnityEngine;

    [CreateNodeMenu("DialogueNode"), NodeTint("#4564e9")]
    class DialogueLineNode : BaseDialogueNode
    {
        [Input]  public BaseDialogueNode InputNode;
        [Output] public BaseDialogueNode OutputNode;

        public ECharacter  Character;
        public string      Text;
    }

    public enum ECharacter
    {
        Boy,
        Girl
    }
}
