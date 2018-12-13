using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QuestKit
{
    public class QuestStage : QuestObject
    {
        public int Stage;

        internal Objective[] objectives;
        internal Quest quest;

        public override void Begin()
        {
            base.Begin();
            objectives = GetComponentsInChildren<Objective>();
            UpdateUI();
            foreach (var item in objectives)
            {
                item.stage = this;
                item.state = QuestState.ACTIVE;
                item.Begin();
            }

        }

        public override void Complete()
        {
         
            //foreach (var item in objectives)
            //{
            //    item.Complete();
            //}
            base.Complete();
            quest.NextStage();

            
        }
        public void CompleteObjective()
        {
            UpdateUI();
            foreach (var item in objectives)
            {
                if (item.state == QuestState.FAILED)
                {
                    Fail();
                    return;
                }
                if (item.state == QuestState.ACTIVE)
                    return;
            }

            Complete();

        }

        public override void Fail()
        {
            UpdateUI();
            base.Fail();
            quest.Fail();
        }

        public override void Focus()
        {
            UpdateUI();
            base.Focus();
            foreach (var item in objectives)
            {
                item.Focus();
            }
           
        }

        public override void UnFocus()
        {
            UpdateUI();
            base.UnFocus();
            foreach (var item in objectives)
            {
                item.UnFocus();
            }
        }
        public void UpdateUI()
        {
            Dictionary<string, int> ObjectiveDescriptions = new Dictionary<string, int>();
            Dictionary<string, int> ObjectivesCompleted = new Dictionary<string, int>();
            foreach (var item in objectives)
            {
                if (ObjectiveDescriptions.ContainsKey(item.ObjectiveDescription))
                {
                    ObjectiveDescriptions[item.ObjectiveDescription]++;

                }
                else
                {
                    ObjectiveDescriptions.Add(item.ObjectiveDescription, 1);
                }
                if (!ObjectivesCompleted.ContainsKey(item.ObjectiveDescription))
                    ObjectivesCompleted.Add(item.ObjectiveDescription, 0);
                if (item.state == QuestState.COMPLETED)
                    ObjectivesCompleted[item.ObjectiveDescription]++;
            }
            string ObjectivesString = "";
            foreach (var item in ObjectiveDescriptions.Keys)
            {
                if (ObjectiveDescriptions[item] > 1)
                    ObjectivesString += "<sprite=\"defaultquestmarker\" index=0>" + item + "(" + ObjectivesCompleted[item] + "/" + ObjectiveDescriptions[item] + ")" + Environment.NewLine;
                else
                    ObjectivesString += "<sprite=\"defaultquestmarker\" index=0>" + item + Environment.NewLine;
            }
            quest.UI.QuestObjective.text = ObjectivesString;
            if (quest.Focused)
                QuestManager.Instance.QuestObjectives.text = ObjectivesString;
        }

    }

}