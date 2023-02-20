using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    public Interactuable[] interactuables;

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

            gameObject.transform.localScale -= new Vector3(0, gameObject.transform.localScale.y / 2, 0);

            Debug.Log("Activate button");
            foreach (Interactuable interactuable in interactuables)
            {
                interactuable.Activate();
            }
        }
    }
}
