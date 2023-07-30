using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float camOffsetX;
    [SerializeField] private float camOffsetZ;

    private void Update()
    {
        transform.position = new Vector3(playerPos.position.x + camOffsetX, transform.position.y, playerPos.position.z + camOffsetZ);
    }
}
