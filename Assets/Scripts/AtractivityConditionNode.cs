namespace TVB.Game.Dialogues
{
    using UnityEngine;

    [CreateNodeMenu("AtractivityConditionNode"), NodeTint("#656565")]
    class AtractivityConditionNode : BaseDialogueNode
    {
        [Input]                          public BaseDialogueNode InputNode;
        [Output(dynamicPortList = true)] public Condition[]      Conditions;
    }

    [System.Serializable]
    public struct Condition
    {
        public int            Atractivity;
        public EConditionType Type;
    }

    public enum EConditionType
    {
        Equals,
        Greater,
        Less,
        GreaterEquals,
        LessEquals
    }

}


