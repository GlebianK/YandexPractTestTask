using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDrag : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            DragCollectable(transform.position, col.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.transform.position.x > transform.position.x)
            {
                Destroy(gameObject);
            }
        }
    }

    private void DragCollectable(Vector3 obj1, Vector3 obj2)
    {
        Vector3 direction = obj2 - obj1;
        float distance = direction.magnitude;

        Vector3 normalizedVector = direction / distance;

        transform.Translate(normalizedVector * Time.deltaTime);
    }
}
