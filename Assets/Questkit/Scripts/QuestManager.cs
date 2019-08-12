
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
        public float MarkerRange;
        public Sprite MarkerImage;
        public GameObject MarkerPrefab;
        public GameObject QuestUIPrefab;
        public Transform QuestUIDisplay;
        internal Compass compass;
        internal Quest ActiveQuest;
        public TextMeshProUGUI QuestTitle;
        public TextMeshProUGUI QuestObjectives;
        public Quest focusOnStart;
        public Quest focused;
        public bool StartAllQuests;

        void Awake()
        {
            Instance = this;

        }

        private void Start()
        {
            compass = GameObject.FindObjectOfType<Compass>();
            if (StartAllQuests)
            {
                foreach (var item in GameObject.FindObjectsOfType<Quest>())
                {
                    item.Begin();
                }
            }
            else
                focusOnStart.Begin();
            focusOnStart.Focus();
        }

        public QuestUI CreateQuestUI()
        {
            return GameObject.Instantiate(QuestUIPrefab, QuestUIDisplay).GetComponent<QuestUI>();
          
        }
        
        public void changeFocus(Quest quest)
        {
            if (focused != null)
                focused.UnFocus();
            focused = quest;
        }
    }
}