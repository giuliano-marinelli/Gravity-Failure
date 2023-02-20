using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropellerFuel : MonoBehaviour
{
    public const float MAX_FUEL = 100;

    [Range(0, 100)]
    public float fuelAmount = MAX_FUEL;
    public float consumeAmount = 0.1f;
    public Image bar;

    private void Update()
    {
        bar.fillAmount = (fuelAmount / MAX_FUEL);
    }

    public void Consume()
    {
        fuelAmount = (fuelAmount - consumeAmount < 0 ? 0 : fuelAmount - consumeAmount);
        if (fuelAmount < consumeAmount) fuelAmount = 0;
    }

    public void Refill(float amount)
    {
        fuelAmount = (fuelAmount + amount > 100 ? 100 : fuelAmount + amount);
    }

    public bool IsEmpty()
    {
        return fuelAmount < consumeAmount;
    }
}
