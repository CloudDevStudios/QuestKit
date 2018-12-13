using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuestKit
{

    public abstract class QuestObject : MonoBehaviour
    {
        public UnityEvent OnBegin;
        public UnityEvent OnFail;
        public UnityEvent OnComplete;
        public UnityEvent Onfocus;
        public UnityEvent OnUnfocus;


        public virtual void Begin()
        {
            OnBegin.Invoke();
        }

        public virtual void Fail()
        {
            OnFail.Invoke();
        }

        public virtual void Complete()
        {
            OnComplete.Invoke();
        }

        public virtual void Focus()
        {
            Onfocus.Invoke();
        }

        public virtual void UnFocus()
        {
            Onfocus.Invoke();
        }
    }
}