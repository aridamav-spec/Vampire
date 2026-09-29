using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public bool PauseActive = false;
    private void Start()
    {
        PauseMenuCanvas.SetActive(false);
    }
    private void Update()
    {
       if (PauseActive == false && Input.GetKey(KeyCode.Escape))
        {
            PauseActive = true;
        }
       if (PauseActive == true && Input.GetKey(KeyCode.Escape))
        {
            PauseActive = false;
        }
    }
}
