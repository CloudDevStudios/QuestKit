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
        public Transform Marker;
        public UnityEvent OnObjectiveComplete;
        public UnityEvent OnObjectiveStart;
        public string ObjectiveString;

        public void ObjectiveComplete()
        {
            OnObjectiveComplete.Invoke();
        }
        public void ObjectiveStart()
        {
            OnObjectiveStart.Invoke();
        }

    }

}