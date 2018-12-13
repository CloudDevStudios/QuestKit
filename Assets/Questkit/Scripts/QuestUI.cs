using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
namespace QuestKit {
    public class QuestUI : MonoBehaviour {

        public TextMeshProUGUI QuestTitle;
        public TextMeshProUGUI QuestObjective;
        public Image Display;
        public Quest quest;
        internal Button focus;

        private void Start()
        {
            focus = GetComponent<Button>();
            focus.onClick.AddListener(FocusQuest);
        }

        void FocusQuest()
        {
            quest.Focus();
        }
    }
}