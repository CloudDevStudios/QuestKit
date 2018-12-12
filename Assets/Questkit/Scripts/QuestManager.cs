using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestKit
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance;
        public Sprite MarkerImage;
        public float MarkerRange;

        void Start()
        {
            Instance = this;
        }
    }
}