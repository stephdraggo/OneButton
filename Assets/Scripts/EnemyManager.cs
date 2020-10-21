using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Variables
    [Header("Spawning Variables")]
    [SerializeField, Range(0f, 2f)] float timer = 0;
    #endregion
    #region Start
    void Start()
    {
        timer = 0;
    }
    #endregion
    #region Update
    void Update()
    {
        if (timer <= 0)
        {
            AddEnemy();
        }
    }
    #endregion
    #region Functions
    private void AddEnemy()
    {


        timer = Random.Range(0f, 2f); //give timer for next 
    }
    #endregion
}
