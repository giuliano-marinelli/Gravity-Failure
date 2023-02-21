using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    //parameters
    public float deactivateInTime = 0f;
    public Interactuable[] interactuables;
    
    //internal
    private Animator animator;
    private float deactivateTime = 0f;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (activated && deactivateInTime > 0 && Time.time > deactivateTime)
        {
            Deactivate();
        }
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

            if (deactivateInTime > 0) deactivateTime = Time.time + deactivateInTime;

            animator.SetBool("pushed", true);
            //gameObject.transform.localScale -= new Vector3(0, gameObject.transform.localScale.y / 2, 0);

            Debug.Log("Activate button");
            foreach (Interactuable interactuable in interactuables)
            {
                interactuable.Activate();
            }
        }
    }

    public override void Deactivate()
    {
        if (activated)
        {
            base.Deactivate();

            animator.SetBool("pushed", false);

            Debug.Log("Deactivate button");
            foreach (Interactuable interactuable in interactuables)
            {
                interactuable.Deactivate();
            }
        }
    }
}
