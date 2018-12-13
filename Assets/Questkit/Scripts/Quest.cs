using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace QuestKit
{
    public class Quest : QuestObject
    {
        public String Title;
        public Sprite QuestImage;

        private QuestStage[] Stages;
        private int currentStage = 0;

        internal bool Focused;
        internal QuestUI UI;

        public override void Begin()
        {
            UI = QuestManager.Instance.CreateQuestUI();
            UI.QuestTitle.text = Title;
            UI.quest = this;
            UI.Display.sprite = QuestImage;
            base.Begin();
            Stages = GetComponentsInChildren<QuestStage>();
            foreach (var item in Stages)
            {
                item.quest = this;
            }
            Stages.OrderBy(x => x.Stage);
            Stages[currentStage].Begin();

            
        }

        public void NextStage()
        {
            currentStage++;

            Stages[currentStage].Begin();
        }

        public override void Complete()
        {
            base.Complete();
        }

        public override void Fail()
        {
            base.Fail();
        }

        public override void Focus()
        {

            QuestManager.Instance.changeFocus(this);
            Focused = true;
            base.Focus();
            QuestManager.Instance.QuestTitle.text = Title;
            Stages[currentStage].Focus();
        }

        public override void UnFocus()
        {
            Focused = true;
            base.UnFocus();
            Stages[currentStage].UnFocus();
        }
    }
}