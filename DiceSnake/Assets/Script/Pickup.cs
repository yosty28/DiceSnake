using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : GPE
{
    public override void PickupEffect()
    {
        base.PickupEffect();

        Destroy(this.gameObject);
    }
}