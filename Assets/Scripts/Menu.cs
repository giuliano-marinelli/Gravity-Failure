using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuCamera;
    public GameObject gameCamera;
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public GameObject music;
    public GameObject player;

    public FMODUnity.EventReference startSound;
    public FMODUnity.EventReference quitSound;

    public void OnStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot(startSound);

        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        music.SetActive(true);
        player.SetActive(true);
        //Camera.main.GetComponent<CameraFollow>().target = player.transform;
        gameObject.SetActive(false);

        menuCamera.SetActive(false);
        gameCamera.SetActive(true);
    }

    public void OnQuit()
    {
        FMODUnity.RuntimeManager.PlayOneShot(quitSound);

        Application.Quit();
    }
}
