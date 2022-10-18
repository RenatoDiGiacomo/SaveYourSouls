using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UISystem : MonoBehaviour
{
    [Header("ScoreText")]
    [SerializeField] TMP_Text scoreText;
    GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        scoreText.text = _gameManager.score.ToString();
    }
}
