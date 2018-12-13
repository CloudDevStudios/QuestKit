using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DisplayAndLockControls : MonoBehaviour {

    public FirstPersonController controller;
    public GameObject UI;
    public bool ShowingUI = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ShowingUI)
            {
                UI.SetActive(false);
                controller.enabled = (true);
                Cursor.visible = false;
                ShowingUI = false;
            }
            else
            {
                UI.SetActive(true);
                controller.enabled = (false);
                Cursor.visible = true;
                ShowingUI = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
