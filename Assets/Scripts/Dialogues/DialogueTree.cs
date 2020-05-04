namespace TVB.Dialogue
{
    using TVB.Game;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "DialogueTree")]
    public class DialogueTree : ScriptableObject
    {
        public ETreeBehavior Behavior;
        public TreeNode[] RootNodes;
    }

    public abstract class TreeNode { }

    // HELPERS

    public enum ETreeBehavior
    {
        Normal,
        Pause,
        Replace
    }

    [System.Serializable]
    public class DialogueNode : TreeNode
    {
        public ECharacter  Character;
        public string      Text;
        public AudioSource Clip;
    }

    [System.Serializable]
    public class ChooseNode : TreeNode
    {
        public float DecisionDuration;
        public ChooseItem[] Choices;
    }

    public class ChooseItem
    {
        public string Text;
        public TreeNode[] Nodes;
    }
}
