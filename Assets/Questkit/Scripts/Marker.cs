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

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.LookAt(mCamera.transform);
        }
        public void BeginDisplay()
        {
            GetComponent<MeshRenderer>().enabled = true;
            var compass = QuestManager.Instance.compass;
            compass.BeginMarker(this);
            UIMarker = GameObject.Instantiate(compass.MarkerPrefab, compass.CompassImage.transform).GetComponent<Image>();
            
        }
        public void EndDisplay()
        {
            GetComponent<MeshRenderer>().enabled = false;
            QuestManager.Instance.compass.EndMarker(this);
            GameObject.Destroy(UIMarker);
            
        }

    }
}