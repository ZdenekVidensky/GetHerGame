namespace TVB.Game.Dialogues
{
    using System.Collections;
    
    using UnityEngine;
    
    using TVB.Game.Characters;
    using TVB.Game.GUI;

    class DialogueManager : MonoBehaviour
    {
        [SerializeField]
        private BoyCharacter  m_BoyCharacter;
        [SerializeField]
        private GirlCharacter m_GirlCharacter;

        [Header("GUI")]

        [SerializeField]
        private GUIBubble             m_Bubble;
        [SerializeField]
        private TMPro.TextMeshProUGUI m_Subtitles;
        [SerializeField]
        private GUIDecisions          m_Decisions;

        // PRIVATE MEMBERS

        private int m_SelectedDecision = -1;

        // MONOBEHAVIOUR

        private void Start()
        {
            m_Decisions.OnDecisionSelected += OnDecisionSelected;
        }

        private void OnDestroy()
        {
            m_Decisions.OnDecisionSelected -= OnDecisionSelected;
        }

        // PUBLIC METHODS

        public IEnumerator StartDialogue(DialogueGraph graph)
        {
            m_BoyCharacter.CanMove = false;
            m_GirlCharacter.SetInteractable(false);

            if (graph.nodes.Count == 0)
            {
                m_BoyCharacter.CanMove = true;
                yield break;
            }

            if (graph.nodes[0] is BaseDialogueNode dialogueNode)
            {
                yield return ProcessDialogueNode(dialogueNode);
            }

            m_BoyCharacter.CanMove = true;
            m_GirlCharacter.SetInteractable(true);
            yield break;
        }

        private IEnumerator ProcessDialogueNode(BaseDialogueNode node)
        {
            if (node == null)
                yield break;

            switch (node)
            {
                case DialogueLineNode lineNode:
                    yield return Talk(lineNode.Character, lineNode.Text);
                    break;
                case DecisionNode decisionNode:
                    m_Decisions.SetData(decisionNode.Decisions);
                    m_Decisions.SetActive(true);

                    while (m_SelectedDecision < 0)
                        yield return null;

                    m_Decisions.SetActive(false);

                    var decOutput = decisionNode.GetOutputPort($"{nameof(DecisionNode.Decisions)} {m_SelectedDecision}");
                    m_SelectedDecision = -1;

                    if (decOutput != null && decOutput.Connection != null)
                    {
                        yield return ProcessDialogueNode(decOutput.Connection.node as BaseDialogueNode);
                        yield break;
                    }
                    break;
                case ChangeAtractivityNode changeAtractivityNode:
                    StartCoroutine(m_GirlCharacter.ChangeAttractivity(changeAtractivityNode.ChangedValue));
                    break;
                case AtractivityConditionNode conditionNode:
                    var selectedIndex = -1;

                    for (int idx = 0, count = conditionNode.Conditions.Length; idx < count; idx++)
                    {
                        var condition = conditionNode.Conditions[idx];
                        switch (condition.Type)
                        {
                            case EConditionType.Equals when m_GirlCharacter.Atractivity == condition.Atractivity:
                                selectedIndex = idx;
                                break;
                            case EConditionType.Greater when m_GirlCharacter.Atractivity > condition.Atractivity:
                                selectedIndex = idx;
                                break;
                            case EConditionType.GreaterEquals when m_GirlCharacter.Atractivity >= condition.Atractivity:
                                selectedIndex = idx;
                                break;
                            case EConditionType.Less when m_GirlCharacter.Atractivity < condition.Atractivity:
                                selectedIndex = idx;
                                break;
                            case EConditionType.LessEquals when m_GirlCharacter.Atractivity <= condition.Atractivity:
                                selectedIndex = idx;
                                break;
                        }

                        if (selectedIndex >= 0)
                            break;
                    }

                    if (selectedIndex >= 0)
                    {
                        var conditionOutput = conditionNode.GetOutputPort($"{nameof(AtractivityConditionNode.Conditions)} {selectedIndex}");
                        if (conditionOutput != null && conditionOutput.Connection != null)
                        {
                            yield return ProcessDialogueNode(conditionOutput.Connection.node as BaseDialogueNode);
                            yield break;
                        }
                    }

                    break;
            }

            var output = node.GetPort(nameof(DialogueLineNode.OutputNode))?.Connection;
            if (output == null)
                yield break;

            yield return ProcessDialogueNode(output.node as BaseDialogueNode);
        }

        private IEnumerator Talk(ECharacter character, string text)
        {
            m_Bubble.SetActive(true);
            m_Subtitles.gameObject.SetActive(true);
            switch (character)
            {
                case ECharacter.Boy:
                    m_Bubble.SetData(m_BoyCharacter.BubbleAnchor.position, m_BoyCharacter.Color);
                    m_Subtitles.text = string.Format("{0}: {1}", "Boy", text); // TODO: Translated name
                    yield return m_BoyCharacter.Talk(text);
                    m_Bubble.SetActive(false);
                    m_Subtitles.gameObject.SetActive(false);
                    break;

                case ECharacter.Girl:
                    m_Bubble.SetData(m_GirlCharacter.BubbleAnchor.position, m_GirlCharacter.Color);
                    m_Subtitles.text = string.Format("{0}: {1}", "Girl", text); // TODO: Translated name
                    yield return m_GirlCharacter.Talk(text);
                    break;
            }

            m_Subtitles.gameObject.SetActive(false);
            m_Bubble.SetActive(false);
        }

        private void OnDecisionSelected(int selection)
        {
            m_SelectedDecision = selection;
        }
    }
}
