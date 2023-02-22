using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuCamera;
    public GameObject gameCamera;
    public GameObject menuCanvas;
    public GameObject music;
    public GameObject player;

    private void Start()
    {

    }

    public void OnStart()
    {
        menuCanvas.SetActive(false);
        music.SetActive(true);
        player.SetActive(true);
        //Camera.main.GetComponent<CameraFollow>().target = player.transform;
        gameObject.SetActive(false);

        menuCamera.SetActive(false);
        gameCamera.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
