using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameManagerPointer gameManagerPointer;

    public Camera mainCamera;

    public Canvas mainUI;

    public GameObject PressEToTrigger;


    // This thing needs to initalize first!!!
    private void Awake()
    {
        gameManagerPointer.gameManager = this;
    }

    // Use this for initialization
    void Start () {
		
	}
}
