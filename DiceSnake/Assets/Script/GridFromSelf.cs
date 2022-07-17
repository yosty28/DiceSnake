using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFromSelf : MonoBehaviour
{
    public int gridDim;
    public float spacing;

    public GameObject content;

    private void Awake()
    {
        GridManager.InitGrid(gridDim);

        var g = GridPos();

        for (int i = 0; i < gridDim; i++)
        {
            for (int j = 0; j < gridDim; j++)
            {
                GridManager.gridCells[i][j] = Instantiate(content, g[i][j], content.transform.rotation).GetComponent<GridCell>();
            }
        }

        Destroy(this.gameObject);
    }

    private Vector3[][] GridPos()
    {
        Vector3[][] grid = new Vector3[gridDim][];

        Vector3 t;

        for (int i = 0; i < gridDim; i++)
        {
            grid[i] = new Vector3[gridDim];
            for (int j = 0; j < gridDim; j++)
            {
                t = transform.position;

                t += new Vector3(i * spacing, 0f, j * spacing);

                grid[i][j] = t;
            }
        }

        return grid;
    }

    private void OnDrawGizmosSelected()
    {
        var g = GridPos();

        for (int i = 0; i < gridDim; i++)
        {
            for (int j = 0; j < gridDim; j++)
            {
                Vector3 t = g[i][j];
                Gizmos.DrawWireCube(t, Vector3.one);
            }
        }
    }
}
