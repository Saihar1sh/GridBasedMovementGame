using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Destination for player as per input")]
    private Vector3 desiredPos;
    [SerializeField]
    [Tooltip("Speed at which player travels to next cell")]
    private float speed;
    [Tooltip("Indexes of grid")]
    private int x, y;
    private int rows, cols;

    //directions in normalized form:  -1, 0, 1
    private int verticalDirection, horizontalDirection;

    //If the grid is fully rendered and positions are recorded
    private bool gridRendered;

    private SwipeInput swipeInput;
    [SerializeField]
    private GridManager gridManager;


    private void Awake()
    {
        swipeInput = GetComponent<SwipeInput>();            //script is attached to player
    }

    private void Start()
    {
        gridManager.GetParameters(ref rows, ref cols);     //sets rows and columns count from Gridmanager
        gridManager.GetOrigin(ref x, ref y);               //sets origin tile index according to rows and columns to x and y
    }

    private void Update()
    {
        gridRendered = gridManager.gridDone;
        if (!gridRendered)
            return;

        if (swipeInput.IsDragging)
        {
            UpdateDirection();

        }
        ApplyMovement();


    }
    void UpdateDirection()
    {
        if (swipeInput.SwipeLeft)
        {
            horizontalDirection = -1;
            verticalDirection = 0;
        }
        if (swipeInput.SwipeRight)
        {
            horizontalDirection = 1;
            verticalDirection = 0;
        }
        if (swipeInput.SwipeUp)
        {
            horizontalDirection = 0;
            verticalDirection = -1;
        }
        if (swipeInput.SwipeDown)
        {
            horizontalDirection = 0;
            verticalDirection = 1;
        }
    }

    private void ApplyMovement()                            //Applying movement as per Player Swipe Input
    {
        if (x < 0 || y < 0 || x >= rows || y >= cols)       //If co-ordinates are out of grid
        {
            Teleport();
            Movement();
            return;
        }
        desiredPos = gridManager.GetGridPosition(x, y);         //sets the destination for player based on swipes
        Movement();
        if (transform.position == desiredPos)
        {
            x += verticalDirection;
            y += horizontalDirection;
        }

    }
    //travelling to the destination for player 
    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, desiredPos, speed * Time.deltaTime);
    }

    private void Teleport()                 //teleporting to another side of screen when reached end of this side
    {
        //checking right side
        if (x >= rows)
        {
            x = 0;
            transform.position = gridManager.GetGridPosition(x, y);
            Debug.Log("From above");
        }
        //checking left side
        if (x < 0)
        {
            x = rows - 1;
            transform.position = gridManager.GetGridPosition(x, y);
            Debug.Log("From below");

        }
        //checking top
        if (y >= cols)
        {
            y = 0;
            transform.position = gridManager.GetGridPosition(x, y);
            Debug.Log("From left");

        }
        //checking bottom
        if (y < 0)
        {
            y = cols - 1;
            transform.position = gridManager.GetGridPosition(x, y);
            Debug.Log("From right");

        }
    }

}
