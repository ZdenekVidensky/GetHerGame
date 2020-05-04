namespace TVB.Game
{
    using TVB.Core.Attributes;
    using TVB.Dialogue;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [GetComponent(true), SerializeField, HideInInspector]
        private DialogueManager m_DialogueManager;

        void Start()
        {
            var treeNodes = new TreeNode[]
            {
                new DialogueNode()
                {
                    Character = ECharacter.Jason,
                    Text = "Ahoj, jak se vede?"
                },
                new DialogueNode()
                {
                    Character = ECharacter.Emily,
                    Text = "Ahoj, dobře."
                }
            };

            var testingTree = new DialogueTree()
            {
                Behavior = ETreeBehavior.Normal,
                RootNodes = treeNodes
            };

            m_DialogueManager.PushTree(testingTree);
        }
    }
}
