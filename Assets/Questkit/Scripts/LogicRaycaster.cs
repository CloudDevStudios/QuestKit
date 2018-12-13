using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GMPointerLoader))]
public class LogicRaycaster : MonoBehaviour {

    public float triggerRaycastHit = 10;

    public LayerMask triggerRaycastLayerMask;

    GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GetComponent<GMPointerLoader>().gameManagerPointer.gameManager;
    }
	
	// Update is called once per frame
	void Update () {
        
        // check for objects in front of the camera.
        RaycastHit triggerHit;

        //Debug.DrawRay(transform.position, transform.forward, Color.red, triggerRaycastHit);

        if(Physics.Raycast(transform.position, transform.forward, out triggerHit, triggerRaycastHit, triggerRaycastLayerMask) )
        {
            var sb = triggerHit.transform.GetComponent<Selectable>();

            if (sb.isSelectable)
            {
                gameManager.PressEToTrigger.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    sb.OnTriggered();
                }
            }
            else{
                gameManager.PressEToTrigger.SetActive(false);
            }
        }
        else{
            gameManager.PressEToTrigger.SetActive(false);
        }
	}
}
