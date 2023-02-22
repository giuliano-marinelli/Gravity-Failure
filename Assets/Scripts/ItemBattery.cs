using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBattery : MonoBehaviour
{
    public float refillAmount = 50f;

   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            RobotBateries robotBateries = collider.GetComponent<RobotBateries>();
            robotBateries.Refill(refillAmount);

            Destroy(gameObject);
        }
    }
}
