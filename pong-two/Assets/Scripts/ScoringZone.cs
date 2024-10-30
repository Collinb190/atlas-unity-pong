using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Puck puck = collision.gameObject.GetComponent<Puck>();

        if (puck != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
        }
    }
}
