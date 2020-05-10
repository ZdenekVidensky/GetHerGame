using TVB.Core.Attributes;
using TVB.Game;
using TVB.Game.Characters;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // CONFIGURATION

    [SerializeField]
    private float m_Speed = 3f;
    [SerializeField]
    private float m_InteractivityDistance = 3f;

    // PRIVATE MEMBERS

    [GetComponent(true), SerializeField, HideInInspector]
    private CharacterController m_CharacterController;

    void Start()
    {
        
    }

    void Update()
    {
        var deltaTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            m_CharacterController.Move(Vector3.left * m_Speed * deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            m_CharacterController.Move(Vector3.right * m_Speed * deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, m_InteractivityDistance) == true)
            {
                var girl = hit.collider.GetComponent<GirlCharacter>();
                if (girl != null)
                {
                    // TODO
                    Debug.LogError("Hitted girl!");
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

            //if (Physics.SphereCast(position, m_InteractivityRadius, transform.right, out var hit, 50f) == true)
            //{
            //    var girl = hit.collider.GetComponent<GirlCharacter>();
            //    if (girl != null)
            //    {
            //        // TODO
            //        Debug.LogError("Hitted girl!");
            //        Debug.DrawRay(position, transform.right, Color.red, 2f);
            //        return;
            //    }

            //    var interactableObject = hit.collider.GetComponent<InteractableObject>();
            //    if (interactableObject != null)
            //    {
            //        // TODO
            //        Debug.LogError("Hitted object!");
            //        return;
            //    }
            //}
        }
    }
}
