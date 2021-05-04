using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [Tooltip("Rows and Column input")]
    public int rows = 12, cols = 6;
    [Tooltip("Width and Height as per the requirement")]
    public int width, height;
    [Tooltip("Reference prefab for tile sprite")]
    public GameObject tile;

    public bool gridDone = false;

    private Transform[] transforms;

    private int k = 1;

    //height and width of each cell in grid
    private float rowHeight, colWidth;
    //2 dimensional array to store positions as vector2
    private Vector2[,] grid;

    private GridLayoutGroup gridLayoutGroup;

    private static GridManager instance;
    public static GridManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is another Singleton in the class ", instance);
            Destroy(this);
        }
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    void Start()
    {
        SizeCorrection();
        rowHeight = height / rows;
        colWidth = width / cols;
        InstantiateTiles();
        StartGrid();
    }

    private void StartGrid()
    {
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

        yield return new WaitForEndOfFrame();           //For gridlayout to arrange tiles

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = transforms[k].transform.position;
                Debug.Log("(" + i + "," + j + "): " + grid[i, j], transforms[k]);
                k++;
            }
        }
        gridDone = true;

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
    void InstantiateTiles()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject _tile = Instantiate(tile, transform);                //tile gameobjects are instantiated as child to this gameobject

            }
        }
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = cols;

    }
    //changes input indexes to that of cell acting as center 
    public void GetOrigin(ref int i, ref int j)
    {
        float x;
        float y;
        if (IsOdd(rows))
        {
            x = (rows + 1) / 2;
            x -= 1;
        }
        else
        {
            x = (rows / 2);
        }
        if (IsOdd(cols))
        {
            y = (cols + 1) / 2;
            y -= 1;
        }
        else
        {
            y = (cols / 2);
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