using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactuable
{
    public float openForce = 2f;
    public float openDelay = 1f;
    public bool openToRight = true;

    private float openTime = 0f;

    private void Update()
    {
        if (Time.time < openTime)
        {
            if (activated)
                transform.Translate(0, (openToRight ? 1 : -1) * openForce * Time.deltaTime, 0);
            else
                transform.Translate(0, (-1) * (openToRight ? 1 : -1) * openForce * Time.deltaTime, 0);
        }
    }

    public override void Activate()
    {
        if (!activated)
        {
            base.Activate();

            openTime = Time.time + openDelay;
        }
    }

    public override void Deactivate()
    {
        if (activated)
        {
            base.Deactivate();

            openTime = Time.time + openDelay;
        }

    }
}
