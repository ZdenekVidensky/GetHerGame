using UnityEngine;
using TVB.Core.Attributes;
using TVB.Game;
using TVB.Game.Characters;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Character))]
public class PlayerControl : MonoBehaviour
{
    // CONFIGURATION

    [SerializeField]
    private float               m_Speed = 3f;
    [SerializeField]
    private float               m_InteractivityDistance = 3f;

    // PRIVATE MEMBERS

    [GetComponent(true), SerializeField, HideInInspector]
    private CharacterController m_CharacterController;
    [GetComponent(true), SerializeField, HideInInspector]
    private Character           m_Character;

    void Update()
    {
        if (m_Character.CanMove == false)
            return;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            m_CharacterController.Move(Vector3.left * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            m_CharacterController.Move(Vector3.right * m_Speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) == true)
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
                    // TODO
                    Debug.LogError("Hitted object!");
                    return;
                }
            }
        }
    }
}
