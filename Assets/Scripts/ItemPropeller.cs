using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPropeller : MonoBehaviour
{
    public GameObject propellerPrefab;
    public GameObject propellerIndicator;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            RobotController robotController = collider.GetComponent<RobotController>();
            if (!robotController.hasPropeller)
            {
                robotController.hasPropeller = true;

                Instantiate(propellerPrefab, robotController.hands.transform);

                propellerIndicator.SetActive(true);

                Destroy(gameObject);
            }
        }
    }
}
