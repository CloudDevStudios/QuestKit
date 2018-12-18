using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DisplayAndLockControls : MonoBehaviour {

    public FirstPersonController fpsController;
    public GameObject UI;
    public bool ShowingUI = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ShowingUI)
            {
                UI.SetActive(false);

                if(fpsController)fpsController.enabled = (true);
                
                Cursor.visible = false;
                ShowingUI = false;
            }
            else
            {
                UI.SetActive(true);

                if (fpsController) fpsController.enabled = (false);

                Cursor.visible = true;
                ShowingUI = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
