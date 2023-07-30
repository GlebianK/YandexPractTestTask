using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private float moveStep;
    [SerializeField] private float maxCoordY;
    [SerializeField] private float minCoordY;

    private bool moveUp;

    private void Start()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            moveUp = false;
        }
        else
        {
            moveUp = true;
        }

    }

    private void Update()
    {
        Vector3 direction;
        if (moveUp)
        {
            direction = Vector3.up * moveStep * Time.deltaTime;
        }
        else
        {
            direction = Vector3.down * moveStep * Time.deltaTime;
        }

        transform.Translate(direction, Space.World);

        CheckDirection();
    }

    private void CheckDirection()
    {
        if ((transform.position.y <= minCoordY) || (transform.position.y >= maxCoordY))
        {
            moveUp = !moveUp;
        }
    }
}
