using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GPE
{
    public int x;
    public int y;

    public int value;

    public Transform from;
    public Transform target;
    protected float timeToNextCell = 0.5f;
    protected float changeStamp = 0f;

    public GridCell currentCell;

    protected virtual void Start()
    {
        from = transform;
        target = transform;
    }

    protected virtual void Update()
    {
        transform.position = Vector3.Lerp(from.position, target.position, (Time.time - changeStamp) / timeToNextCell);
    }

    public void SetNextTarget(int _x, int _y)
    {
        ResetTime();

        currentCell.EmptyCell();

        GridManager.gridCells[x][y].changeContent(this);
        currentCell = GridManager.gridCells[x][y];


        x = _x;
        y = _y;

        Transform t = GridManager.gridCells[x][y].anchor;

        from = target;
        target = t;
    }


    protected void ResetTime()
    {
        changeStamp = Time.time;
    }

}