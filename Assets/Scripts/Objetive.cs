using TMPro;
using UnityEngine;

public class Objetive : MonoBehaviour
{
    public int crystalsAmount = 0;
    public TextMeshProUGUI text;

    public void AddCrystal()
    {
        crystalsAmount++;
        text.text = "" + crystalsAmount;
    }
}
