using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    //parameters
    public float deactivateInTime = 0f;
    public Interactuable[] interactuables;
    public FMODUnity.EventReference buttonSound;
    public FMODUnity.EventReference timeSound;

    private FMOD.Studio.EventInstance timeEvent;

    //internal
    private Animator animator;
    private float deactivateTime = 0f;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        timeEvent = FMODUnity.RuntimeManager.CreateInstance(timeSound);
    }

    private void Update()
    {
        if (activated && deactivateInTime > 0 && Time.time > deactivateTime)
        {
            Deactivate();
            timeEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Throwable")
        {
            Activate();
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(timeEvent, GameObject.FindGameObjectWithTag("Player").transform);
        }
    }

    public override void Activate()
    {
        if (!activated)
        {
            base.Activate();

            FMODUnity.RuntimeManager.PlayOneShotAttached(buttonSound, gameObject);

            if (deactivateInTime > 0)
            {
                deactivateTime = Time.time + deactivateInTime;
                timeEvent.start();
            }

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
