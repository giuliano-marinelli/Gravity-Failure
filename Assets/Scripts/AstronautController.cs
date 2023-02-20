using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AstronautController : MonoBehaviour
{
    public GameObject rightLegCollider;
    public GameObject leftLegCollider;

    private float jetpackForce = 100f;
    private float kickForce = 200f;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }

    private void UseJetpack()
    {
        Debug.Log("use jetpack");
        rb.AddForce(transform.up * jetpackForce);
    }

    private void Kick(int direction)
    {
        Debug.Log("use kick " + (direction == 1 ? "left" : "right"));
        if (Physics.CheckSphere(transform.position + transform.forward * direction, 1, LayerMask.NameToLayer("Spaceship")))
        {
            Debug.Log("kick collides");
            rb.AddForce((-1) * direction * transform.forward * kickForce);
        }
    }

    public void OnJetpack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseJetpack();
        }
    }

    public void OnLeftKick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Kick(-1);
        }
    }

    public void OnRightKick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Kick(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Physics.CheckSphere(transform.position + transform.forward * (-1), 1, LayerMask.NameToLayer("Spaceship")))
            Gizmos.DrawSphere(transform.position + transform.forward * (-1), 1);
        else
            Gizmos.DrawWireSphere(transform.position + transform.forward * (-1), 1);

        Gizmos.color = Color.blue;
        if (Physics.CheckSphere(transform.position + transform.forward * 1, 1, LayerMask.NameToLayer("Spaceship")))
            Gizmos.DrawSphere(transform.position + transform.forward, 1);
        else
            Gizmos.DrawWireSphere(transform.position + transform.forward, 1);
    }
}
