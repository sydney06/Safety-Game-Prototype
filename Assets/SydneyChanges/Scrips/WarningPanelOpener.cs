using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanelOpener : MonoBehaviour
{
    public GameObject infoPanelCanvas;
    public GameObject panelControllerObjects;

    private void OnTriggerEnter(Collider other)
    {
        infoPanelCanvas.SetActive(true);
        panelControllerObjects.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        infoPanelCanvas.SetActive(false);
        panelControllerObjects.SetActive(false);
    }
}
