using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadMovement : PlayerMovement
{
    public int bodyLengthInit = 5;
    public PlayerMovement bodyCell;
    private List<PlayerMovement> corps = new List<PlayerMovement>();
    private Facing dir = Facing.East;
    private Facing nextDir = Facing.East;

    protected override void Start()
    {
        x = 5;
        y = 5;

        base.Start();

        transform.position = GridManager.gridCells[x][y].anchor.position;

        for (int i = 0; i < bodyLengthInit; i++)
        {
            AddSegment(Random.Range(0,6));
        }

        SetAllTargets();
    }

    public void AddSegment(int value)
    {
        PlayerMovement pm;

        pm = Instantiate(bodyCell, transform.position, transform.rotation);

        pm.x = x;
        pm.y = y;

        pm.value = value;

        corps.Add(pm);
    }

    protected override void Update()
    {
        if (Time.time - changeStamp >= timeToNextCell)
        {
            ResetTime();

            SetAllTargets();

            if (Input.GetKey(KeyCode.C)) Debug.Break();
        }

        transform.rotation = Quaternion.LookRotation((target.position-from.position).normalized);

        base.Update();

        switch (dir)
        {
            case Facing.North:
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        nextDir = Facing.West;
                    } 
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        nextDir = Facing.East;
                    }
                    break;
                }

            case Facing.East:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        nextDir = Facing.North;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        nextDir = Facing.South;
                    }
                    break;
                }

            case Facing.South:
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        nextDir = Facing.West;
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        nextDir = Facing.East;
                    }
                    break;
                }

            case Facing.West:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        nextDir = Facing.North;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        nextDir = Facing.South;
                    }
                    break;
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

    public void SetAllTargets()
    {
        dir = nextDir;

        SetNextByDirection();

        corps[0].SetNextTarget(from);

        for (int i = 1; i < corps.Count - 1; i++)
        {
            corps[i].SetNextTarget(corps[i - 1].from);
        }
    }

    public void Collision()
    {
        GPE content = GridManager.gridCells[x][y].cellContent;

        if (content.GetType() == typeof(Pickup))
        {
            content.PickupEffect();
        }
        else
        {
            GridManager.GameOver();
        }
    }
}