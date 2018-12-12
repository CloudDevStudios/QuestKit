using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace QuestKit
{
    public class Objective : MonoBehaviour
    {
        public bool ObjectiveEnabled;
        public bool ObjectiveDisplayed;
        public Transform Target;
        private Marker marker;
        public UnityEvent OnObjectiveComplete;
        public UnityEvent OnObjectiveStart;
        public string ObjectiveString;

        private void Start()
        {
            var mark = GameObject.Instantiate(QuestManager.Instance.MarkerPrefab,Target);
            mark.GetComponent<MeshRenderer>().enabled = false;
            marker = mark.GetComponent<Marker>();

            if (ObjectiveEnabled)
                ObjectiveStart();
        }

        public void ObjectiveComplete()
        {

            ObjectiveEnabled = true;
            ObjectiveDisplayed = true;
            marker.EndDisplay();
            OnObjectiveComplete.Invoke();
        }
        public void ObjectiveStart()
        {
            ObjectiveEnabled = true;
            ObjectiveDisplayed = true;
            marker.BeginDisplay();
            OnObjectiveStart.Invoke();
        }

    }

}