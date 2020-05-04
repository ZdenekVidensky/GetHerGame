namespace TVB.Dialogue
{
    using UnityEngine;

    using XNode;

    [CreateNodeMenu("DialogueNode")]
    class DialogueLineNode : BaseDialogueNode
    {
        [Input]  public BaseDialogueNode InputNode;
        [Output] public BaseDialogueNode OutputNode;

        public TextValue[] TextValues;
    }

    [System.Serializable]
    public struct TextValue
    {
        public string         Text;
        public SystemLanguage Language;
    }
}
