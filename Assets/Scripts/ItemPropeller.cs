using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPropeller : MonoBehaviour
{
    public GameObject propellerPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            RobotController robotController = collision.collider.GetComponent<RobotController>();
            robotController.hasPropeller = true;

            Instantiate(propellerPrefab, robotController.hands.transform);


            Destroy(gameObject);
        }
    }
}
