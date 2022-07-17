using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GPE
{
    public Transform from;
    public Transform target;
    protected float timeToNextCell = 1f;

    protected virtual void Start()
    {
        from = transform;
        target = transform;
    }

    protected virtual void Update()
    {
        transform.position = Vector3.Lerp(from.position, target.position, (Time.time % timeToNextCell) / timeToNextCell);
    }

    public void SetNextTarget(Transform t)
    {
        if(target.GetComponent<GridCell>())
        {
            target.GetComponent<GridCell>().changeContent(this);
        }

        from = target;
        target = t;
    }
}
