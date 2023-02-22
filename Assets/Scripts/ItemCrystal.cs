using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrystal : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Objetive objetive = collider.GetComponent<Objetive>();
            objetive.AddCrystal();

            Destroy(gameObject);
        }
    }
}
