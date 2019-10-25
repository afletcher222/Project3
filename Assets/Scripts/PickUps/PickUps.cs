using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Player")
            return;

        PickUp(collider.transform);
    }

    public virtual void OnPickUp(Transform item)
    {

    }

    void PickUp(Transform item)
    {
        OnPickUp(item);
    }

}
