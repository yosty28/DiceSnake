using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public PlayerMovement player;
    public GridCell[][] gridCells;

    public void InitGrid(int size)
    {
        gridCells = new GridCell[size][];

        for (int i = 0; i < size; i++)
        {
            gridCells[i] = new GridCell[size];
        }
    }

    public void InitPlayer(int x, int y)
    {

    }
}
