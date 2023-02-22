using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Dialogues dialogues;
    public Sprite image;
    public float duration = 0f;
    public bool wasShowed = false;
    public bool isShowing = false;

    private float timeDialogue = 0f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !wasShowed)
        {
            dialogues.SetImage(image);
            dialogues.Show();
            if (duration > 0) timeDialogue = Time.time + duration;
            wasShowed = true;
            isShowing = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && wasShowed)
        {
            dialogues.Close();
            isShowing = false;
        }
    }

    private void Update()
    {
        if (duration > 0 && isShowing && Time.time > timeDialogue)
        {
            dialogues.Close();
            isShowing = false;
        }
    }
}
