using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Tooltip("Rows and Column input")]
    public int rows = 12, cols = 6;
    [Tooltip("Width and Height as per the requirement")]
    public int width, height;
    [Tooltip("Reference prefab for tile sprite")]
    public GameObject tile;

    private Transform[] transforms;

    private int k = 1;

    //height and width of each cell in grid
    private float rowHeight, colWidth;
    //grid : 2 dimensional array to store positions as vector2
    private Vector2[,] grid;

    void Start()
    {
        SizeCorrection();
        rowHeight = height / rows;
        colWidth = width / cols;
        DrawGrid();
        StartCoroutine(GridImplementation());
    }


    //function for checking odd or even
    bool IsOdd(int x)
    {
        if (x % 2 != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //calculating each cell of grid with vector2 positions
    IEnumerator GridImplementation()
    {
        grid = new Vector2[rows, cols];                 //creating grid
        transforms = GetComponentsInChildren<Transform>();

        yield return new WaitForEndOfFrame();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = transforms[k].transform.position;
                Debug.Log(grid[i, j], transforms[k]);
                k++;
            }
        }
    }
    //to correct the width and height of screen
    void SizeCorrection()
    {
        if (width % 2 != 0)
        {
            width = width + 1;
        }
        if (height % 2 != 0)
        {
            height = height + 1;
        }
    }
    //draw tiles at each node to visualise the grid positions
    void DrawGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject _tile = Instantiate(tile, transform);                //tile gameobjects are instantiated as child to this gameobject

                //    _tile.transform.position = new Vector3(grid[i, j].x, grid[i, j].y, 0f);
            }
        }
    }
    //changes input indexes to that of cell acting as center 
    public void GetOrigin(ref int i, ref int j)
    {
        float x;
        float y;
        if (IsOdd(cols))
        {
            x = (cols + 1) / 2;
        }
        else
        {
            x = (cols / 2) + 1;
        }
        if (IsOdd(rows))
        {
            y = (rows + 1) / 2;
        }
        else
        {
            y = (rows / 2) + 1;
        }
        i = (int)x;
        j = (int)y;
    }
    //return value of array. that is positions stored in given indexes
    public Vector3 GetGridPosition(int i, int j)
    {
        return new Vector3(grid[i, j].x, grid[i, j].y, 0f);
    }
    //returns number of rows and columns
    public void GetParameters(ref int row_count, ref int col_count)
    {
        row_count = rows;
        col_count = cols;
    }
}
