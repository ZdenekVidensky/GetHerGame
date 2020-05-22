using UnityEngine;
using TVB.Core.Attributes;
using TVB.Game;
using TVB.Game.Characters;

[RequireComponent(typeof(Character))]
public class PlayerControl : MonoBehaviour
{
    // CONSTANTS

    private const string WALKING_FRONT = "Walking";

    // CONFIGURATION

    [SerializeField]
    private float               m_InteractivityDistance = 3f;
    [SerializeField]
    private float               m_Speed                 = 10f;
    [SerializeField]
    private Transform           m_InteractableRay;

    // PRIVATE MEMBERS

    [GetComponent(true), SerializeField, HideInInspector]
    private Character           m_Character;
    [GetComponent(true), SerializeField, HideInInspector]
    private Animator            m_Animator;
    [GetComponent(true), SerializeField, HideInInspector]
    private CharacterController m_CharacterController;

    private Vector3 m_Motion = Vector3.zero;

    private static int WalkingHash = Animator.StringToHash("Walking");
    private static int SpeedHash   = Animator.StringToHash("Speed");

    void Update()
    {
        if (m_Character.CanMove == false)
        {
            m_Animator.SetBool(WalkingHash, false);
            m_Animator.SetFloat(SpeedHash, 0f);
            return;
        }

        var horizontalAxis = Input.GetAxis("Horizontal");

        var isWalking = Mathf.Approximately(horizontalAxis, 0) == false;
        m_Animator.SetBool(WalkingHash, isWalking);
        m_Animator.SetFloat(SpeedHash, horizontalAxis);

        var animatorState = m_Animator.GetCurrentAnimatorStateInfo(0);

        if (animatorState.IsName("WalkingFront") == true || animatorState.IsName("WalkingBack") == true)
        {
            m_Motion.x = horizontalAxis * m_Speed * Time.deltaTime;
            m_CharacterController.Move(m_Motion);
        }
       
        if (Input.GetButton("Use") == true)
        {
            if (Physics.Raycast(m_InteractableRay.position, m_InteractableRay.forward, out var hit, m_InteractivityDistance) == true)
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
