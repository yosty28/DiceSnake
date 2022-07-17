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
        currentCell = GridManager.gridCells[x][y];

        for (int i = 0; i < bodyLengthInit; i++)
        {
            AddSegment(Random.Range(0,6));
        }

        SetAllTargets();

        corps[0].GetComponent<MeshRenderer>().enabled = false;
    }

    public void AddSegment(int value)
    {
        PlayerMovement pm;

        pm = Instantiate(bodyCell, /*corps[corps.Count-1].*/transform.position, transform.rotation);

        pm.x = x;
        pm.y = y;

        pm.currentCell = currentCell;

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

        Collision();

        SetNextTarget(x,y);
    }

    public void SetAllTargets()
    {
        dir = nextDir;

        SetNextByDirection();

        corps[0].SetNextTarget(currentCell.x,currentCell.y);

        for (int i = 1; i < corps.Count - 1; i++)
        {
            corps[i].SetNextTarget(corps[i - 1].currentCell.x, corps[i - 1].currentCell.y);
        }
    }

    public void Collision()
    {
        GPE content = GridManager.gridCells[x][y].cellContent;

        if (content ==null)
        {
            return;
        }

        if (content.GetComponent<Pickup>())
        {
            content.PickupEffect();
        }
        else
        {
            GridManager.GameOver();
        }
    }
}