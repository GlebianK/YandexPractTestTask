using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float moveUpStep = 1f;
    [SerializeField] private float maxCoordY;
    [SerializeField] private float minCoordY;

    private Vector2 moveUpVector;

    private void Start()
    {
        moveUpVector = new Vector2(0, moveUpStep);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity += moveUpVector;
        }

        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);

        CheckFall();
    }

    private void CheckFall()
    {
        if ((transform.position.y <= minCoordY) || (transform.position.y >= maxCoordY))
        {
            GameManager.Instance.Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.Restart();
        }

        else if (col.gameObject.CompareTag("Collectable"))
        {
            GameManager.Instance.UpdateScore();
            Destroy(col.gameObject);
        }
    }
}
