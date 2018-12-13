using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace QuestKit
{
    public class Objective : QuestObject
    {
        public string ObjectiveDescription;
        public Transform Target;

        internal QuestState state = QuestState.INACTIVE;
        internal QuestStage stage;

        private Marker marker;

        public override void Begin()
        {
            base.Begin();
            var mark = GameObject.Instantiate(QuestManager.Instance.MarkerPrefab, Target);
            marker = mark.GetComponent<Marker>();
        }

        public override void Complete()
        {
            state = QuestState.COMPLETED;
            base.Complete();
            marker.HideMarker();
            GameObject.Destroy(marker);
        }

        public override void Focus()
        {
            base.Focus();
            marker.ShowMarker();
        }

        public override void UnFocus()
        {
            base.UnFocus();
            marker.HideMarker();
        }


    }

}