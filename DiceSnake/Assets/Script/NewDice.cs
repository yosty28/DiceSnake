using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDice : Pickup
{
    public int value;

    void Start()
    {
        value = Random.Range(1, 6);
    }

    public override void PickupEffect()
    {
        Debug.Log(value);

        Destroy(this.gameObject);
    }
}
