using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestKit
{
    public class Marker : MonoBehaviour
    {
        private Camera mCamera;

        internal Image UIMarker;

        // Use this for initialization
        void Start()
        {
            mCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        void FixedUpdate()
        {
            transform.LookAt(mCamera.transform);
        }

        public void ShowMarker()
        {

            Debug.Log("Showing Marker");
            GetComponent<MeshRenderer>().enabled = true;
            var compass = QuestManager.Instance.compass;
            compass.ShowMarker(this);
            UIMarker = GameObject.Instantiate(compass.CompassMarkerPrefab, compass.CompassImage.transform).GetComponent<Image>();
            
        }
        public void HideMarker()
        {
            Debug.Log("Marker Hid");
            GetComponent<MeshRenderer>().enabled = false;
            QuestManager.Instance.compass.HideMarker(this);
            GameObject.Destroy(UIMarker);
            
        }

    }
}