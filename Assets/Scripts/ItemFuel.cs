using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFuel : MonoBehaviour
{
    public float refillAmount = 100f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PropellerFuel propellerFuel = collider.GetComponent<PropellerFuel>();
            propellerFuel.Refill(refillAmount);

            Destroy(gameObject);
        }
    }
}
