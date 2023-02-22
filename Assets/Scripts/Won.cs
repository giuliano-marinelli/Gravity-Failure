using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour
{
    public bool won;
    public GameObject wonMessage;
    public GameObject wonDialogue;
    public GameObject stillNotWonDialogue;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !won)
        {
            if (collider.GetComponent<Objetive>().crystalsAmount >= 4)
            {
                wonMessage.SetActive(true);
                wonDialogue.SetActive(true);
                won = true;
            }
            else
            {
                stillNotWonDialogue.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && !won)
        {
            //stillNotWonDialogue.GetComponent<Dialogue>().wasShowed = false;
        }
    }
}
