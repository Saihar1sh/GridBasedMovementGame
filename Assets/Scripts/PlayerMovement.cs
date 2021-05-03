using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform player;
    private Vector3 desiredPos, playerPos;
    private int x, y;
    private int rows, cols;

    private SwipeInput swipeInput;
    [SerializeField]
    private GridManager gridManager;

    private void Awake()
    {
        swipeInput = GetComponent<SwipeInput>();            //script is attached to player
        player = GetComponent<Transform>();
    }

    private void Start()
    {
        gridManager.GetParameters(ref rows, ref cols);
        gridManager.GetOrigin(ref x, ref y);
    }

    private void Update()
    {
        transform.position = gridManager.GetGridPosition(x, y);
        ApplyMovement();
    }
    private void ApplyMovement()                            //Applying movement as per Player Swipe Input
    {
        playerPos = player.transform.position;
        if (swipeInput.SwipeRight)
            desiredPos = playerPos + Vector3.right;
        if (swipeInput.SwipeLeft)
            desiredPos = playerPos + Vector3.left;
        if (swipeInput.SwipeUp)
            desiredPos = playerPos + Vector3.up;
        if (swipeInput.SwipeDown)
            desiredPos = playerPos + Vector3.down;
        player.transform.position = Vector3.MoveTowards(playerPos, desiredPos, Time.deltaTime);

    }
}
