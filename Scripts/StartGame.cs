using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startPanel.SetActive(false);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
