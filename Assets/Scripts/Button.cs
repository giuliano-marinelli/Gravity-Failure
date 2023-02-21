using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    //parameters
    public Interactuable[] interactuables;
    
    //internal
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Throwable")
        {
            Activate();
        }
    }

    public override void Activate()
    {
        if (!activated)
        {
            base.Activate();

            animator.SetBool("pushed", true);
            //gameObject.transform.localScale -= new Vector3(0, gameObject.transform.localScale.y / 2, 0);

            Debug.Log("Activate button");
            foreach (Interactuable interactuable in interactuables)
            {
                interactuable.Activate();
            }
        }
    }

    public void Deactivate()
    {
        if (activated)
        {
            animator.SetBool("pushed", false);
        }
    }
}
