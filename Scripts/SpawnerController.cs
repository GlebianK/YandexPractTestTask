using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private float xOffset;
    [SerializeField] private float maxPrefabOffsetY;
    [SerializeField] private float minPrefabOffsetY;
    [SerializeField] private float secondsBetweenInstantiating;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;

    private bool isAllowedToSpawn;

    private void Start()
    {
        isAllowedToSpawn = true;
    }

    private void Update()
    {
        Vector3 offset = new Vector3(xOffset, 0f, -mainCam.transform.position.z);
        transform.position = mainCam.transform.position + Vector3.right * mainCam.orthographicSize * 2 + offset;

        if (isAllowedToSpawn)
        {
            isAllowedToSpawn = false;
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        int randType = Random.Range(0, 2);

        yield return new WaitForEndOfFrame();

        int randNum = Random.Range(1, 3);

        if (randNum == 1)
        {
            InstantiatePrefabs(randType);
        }
        else
        {
            for (int i = 1; i <= randNum; i++)
            {
                InstantiatePrefabs(randType);
                yield return new WaitForSeconds(secondsBetweenInstantiating);
            }
        }

        isAllowedToSpawn = true;
        yield return null;
    }

    private void InstantiatePrefabs(int type)
    {
        float temp = Random.Range(minPrefabOffsetY, maxPrefabOffsetY + 0.01f);
        Vector3 tempV;

        if (temp >= 0)
        {
            tempV = new Vector3(temp, temp, 0f);
        }
        else
        {
            tempV = new Vector3(-temp, temp, 0f);
        }

        if (type == 0)
        {
            Instantiate(prefab1, transform.position + tempV, Quaternion.identity);
        }
        else
        {
            Instantiate(prefab2, transform.position + tempV, Quaternion.identity);
        }
    }
}
