using TVB.Core.Attributes;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // CONFIGURATION

    [SerializeField]
    private float m_Speed = 3f;

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
    }
}
