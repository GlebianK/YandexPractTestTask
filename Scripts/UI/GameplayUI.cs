using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    static public GameplayUI Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void UpdateScoreUI(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }
}
