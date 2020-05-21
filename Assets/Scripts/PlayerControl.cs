using UnityEngine;
using TVB.Core.Attributes;
using TVB.Game;
using TVB.Game.Characters;

[RequireComponent(typeof(Character))]
public class PlayerControl : MonoBehaviour
{
    // CONFIGURATION

    [SerializeField]
    private float               m_InteractivityDistance = 3f;
    [SerializeField]
    private bool                m_FacingRight = true;

    // PRIVATE MEMBERS

    [GetComponent(true), SerializeField, HideInInspector]
    private Character           m_Character;
    //[GetComponent(true), SerializeField, HideInInspector]
    [SerializeField]
    private Animator            m_Animator;


    private static int WalkingHash = Animator.StringToHash("Walking");
    private static int TurnHash    = Animator.StringToHash("Turn");

    void Update()
    {
        if (m_Character.CanMove == false)
            return;


        var horizontalAxis = Input.GetAxis("Horizontal");

        if (horizontalAxis > 0 && m_FacingRight == false)
        {
            m_Animator.SetTrigger(TurnHash);
            m_FacingRight = true;
        }
        else if (horizontalAxis < 0 && m_FacingRight == true)
        {
            m_Animator.SetTrigger(TurnHash);
            m_FacingRight = false;
        }

        var isWalking = Mathf.Approximately(horizontalAxis, 0) == false;
        m_Animator.SetBool(WalkingHash, isWalking);

       
        if (Input.GetButton("Use") == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, m_InteractivityDistance) == true)
            {
                var girl = hit.collider.GetComponent<GirlCharacter>();
                if (girl != null)
                {
                    StartCoroutine((m_Character as BoyCharacter).DialogueManager.StartDialogue(girl.DialogueGraph));
                    return;
                }

                var interactableObject = hit.collider.GetComponent<InteractableObject>();
                if (interactableObject != null)
                {
                    interactableObject.SetGUIActive(false);
                }
            }
        }
    }
}
