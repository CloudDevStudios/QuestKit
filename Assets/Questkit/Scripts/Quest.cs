using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace QuestKit
{
    public class Quest : MonoBehaviour
    {
        [Serializable]
        public struct QuestStage
        {
            public int Stage;
            public Objective[] Objectives;
        }

        public QuestStage[] Stages;
    }
}