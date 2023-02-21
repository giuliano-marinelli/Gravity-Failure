using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotBateries : MonoBehaviour
{
    public const float MAX_BATERY = 100;

    [Range(0, 100)]
    public float bateryAmount = MAX_BATERY;
    public float consumeRate = 0.1f; //consumption by second
    public Image bar;
    public Gradient gradient;

    private float consumptionPeriod = 1f;
    private float consumptionTime = 0f;

    private void Start()
    {
        bar.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        bar.fillAmount = (bateryAmount / MAX_BATERY);
        bar.color = gradient.Evaluate(bar.fillAmount);

        if (Time.time > consumptionTime)
        {
            consumptionTime = Time.time + consumptionPeriod;
            Consume();
        }
    }

    public void Consume()
    {
        bateryAmount = (bateryAmount - consumeRate < 0 ? 0 : bateryAmount - consumeRate);
        if (bateryAmount < consumeRate) bateryAmount = 0;
    }

    public void Consume(float amount)
    {
        bateryAmount = (bateryAmount - amount < 0 ? 0 : bateryAmount - consumeRate);
    }

    public bool IsEmpty()
    {
        return bateryAmount <= consumeRate;
    }
}
