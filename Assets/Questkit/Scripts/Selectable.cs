using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{

    public event Action selectedActions;
    public event Action unselectedActions;
    public event Action triggeredActions;

    public bool isSelectable = true;

    public void OnSelected()
    {
        //if (selectedEvent != null)
        //{
        //    selectedEvent.Invoke();
        //}

        if (selectedActions != null)
        {
            selectedActions();
        }
    }

    public void OnTriggered()
    {
        //if (selectedEvent != null)
        //{
        //    selectedEvent.Invoke();
        //}

        if (triggeredActions != null)
        {
            triggeredActions();
        }
    }

    public void OnUnselected()
    {
        if (unselectedActions != null)
        {
            unselectedActions();
        }
    }
}
