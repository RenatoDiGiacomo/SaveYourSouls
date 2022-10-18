using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("ScoreSystem")]
    public int score;

    private GameObject[] enemys;

    private void Start()
    {
      
        if (enemys == null)
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
    private void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        WaitingForEnding();
         
    }
    private void WaitingForEnding()
    {
        if (enemys != null)
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemys.Length);
        }
        if (enemys.Length <= 0)
        {

        }
    }
}

