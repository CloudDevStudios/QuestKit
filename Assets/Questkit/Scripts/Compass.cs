using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QuestKit
{


    public class Compass : MonoBehaviour {

        public RawImage CompassImage;
        public GameObject CompassMarkerPrefab;

        internal List<Marker> Markers;
        public void Awake()
        {
            Markers = new List<Marker>();
        }
        private void FixedUpdate()
        {
            var rect = CompassImage.uvRect;
            rect.x = (transform.rotation.eulerAngles.y / 360f);
            CompassImage.uvRect = rect;

            foreach (var item in Markers)
            {
                var targetDir = item.transform.position - transform.position;
                targetDir.y = 0;
                var angle = Quaternion.LookRotation(targetDir.normalized,Vector3.up).eulerAngles.y;
                var lookangle = (transform.rotation.eulerAngles.y + 90 + 360 - angle) % 360;
                var result = (1 - (lookangle/ 360f)*2f);
               
                item.UIMarker.rectTransform.anchorMin = new Vector2(result,.5f);
                item.UIMarker.rectTransform.anchorMax = new Vector2(result, .5f);
            }
        }

        internal void ShowMarker(Marker marker)
        {
            Markers.Add(marker);
        }

        internal void HideMarker(Marker marker)
        {
            Markers.Remove(marker);
        }
    }
}