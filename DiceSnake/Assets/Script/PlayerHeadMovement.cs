using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadMovement : PlayerMovement
{
    public int x = 5;
    public int y = 5;

    public int bodyLengthInit = 5;
    public PlayerMovement bodyCell;
    private List<PlayerMovement> corps = new List<PlayerMovement>();
    private Facing dir = Facing.East;
    protected float changeStamp = 0f;

    protected override void Start()
    {
        base.Start();

        transform.position = GridManager.gridCells[x][y].anchor.position;

        for (int i = 0; i < bodyLengthInit; i++)
        {
            corps.Add(Instantiate(bodyCell,transform.position,transform.rotation));
        }

        SetAllTargets();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (dir)
            {
                case Facing.North:
                    {
                        dir = Facing.West;
                        break;
                    }

                case Facing.East:
                    {
                        dir = Facing.North;
                        break;
                    }

                case Facing.South:
                    {
                        dir = Facing.East;
                        break;
                    }

                case Facing.West:
                    {
                        dir = Facing.South;
                        break;
                    }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            switch (dir)
            {
                case Facing.North:
                    {
                        dir = Facing.East;
                        break;
                    }

                case Facing.East:
                    {
                        dir = Facing.South;
                        break;
                    }

                case Facing.South:
                    {
                        dir = Facing.West;
                        break;
                    }

                case Facing.West:
                    {
                        dir = Facing.North;
                        break;
                    }
            }
        }
    }

    private void SetNextByDirection()
    {
        switch(dir)
        {
            case Facing.North:
                {
                    y++;
                    break;
                }

            case Facing.East:
                {
                    x++;
                    break;
                }

            case Facing.South:
                {
                    y--;
                    break;
                }

            case Facing.West:
                {
                    x--;
                    break;
                }
        }
        SetNextTarget(GridManager.gridCells[x][y].anchor);
    }

    public void LateUpdate()
    {
        if (Time.time - changeStamp >= timeToNextCell)
        {
            SetAllTargets();
        }
    }

    public void SetAllTargets()
    {
        ResetTime();

        SetNextByDirection();

        corps[0].SetNextTarget(from);

        for (int i = 1; i < corps.Count - 1; i++)
        {
            corps[i].SetNextTarget(corps[i - 1].from);
        }
    }

    protected void ResetTime()
    {
        changeStamp = Time.time;
    }
}