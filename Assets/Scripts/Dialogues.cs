using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    public GameObject textImage;
    public GameObject closeButton;

    public void Close()
    {
        textImage.SetActive(false);
        closeButton.SetActive(false);
    }

    public void Show()
    {
        textImage.SetActive(true);
        closeButton.SetActive(true);
    }

    public void SetImage(Sprite image)
    {
        textImage.GetComponent<Image>().sprite = image;
    }
}
