using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GridManager
{
    public static GridCell[][] gridCells;

    public static void InitGrid(int size)
    {
        gridCells = new GridCell[size][];

        for (int i = 0; i < size; i++)
        {
            gridCells[i] = new GridCell[size];
        }
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
