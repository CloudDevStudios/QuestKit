using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace QuestKit
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance;
        public Sprite MarkerImage;
        public GameObject MarkerPrefab;
        public float MarkerRange;
        public TextMeshProUGUI QuestTitle;
        public TextMeshProUGUI QuestObjectives;
        public Compass compass;
        public Quest ActiveQuest;
            
        void Awake()
        {
            Instance = this;
        }

        
    }
}