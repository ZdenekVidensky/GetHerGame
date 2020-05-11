namespace TVB.Game.Dialogues
{
    using UnityEngine;

    [CreateNodeMenu("DialogueNode"), NodeTint("#4564e9")]
    class DialogueLineNode : BaseDialogueNode
    {
        [Input]  public BaseDialogueNode InputNode;
        [Output] public BaseDialogueNode OutputNode;

        public ECharacter  Character;
        public TextValue[] TextValues;
    }

    [System.Serializable]
    public struct TextValue
    {
        public string         Text;
        public SystemLanguage Language;
    }

    public enum ECharacter
    {
        Boy,
        Girl
    }
}
