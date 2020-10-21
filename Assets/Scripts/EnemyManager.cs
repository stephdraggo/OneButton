using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Variables
    [Header("Spawning Variables")]
    [SerializeField, Range(0f, 2f)] float timer = 0;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform parentObject;
    [SerializeField] private Vector3 whereToSpawn;
    [SerializeField] private float screenTenth,screenTop;
    #endregion
    #region Start
    void Start()
    {
        timer = 0; //set timer to 0

        screenTenth = Screen.width / 10;
        screenTop = Screen.height;
    }
    #endregion
    #region Update
    void Update()
    {
        timer -= Time.deltaTime; //decrease timer

        if (timer <= 0) //if timer ran out
        {
            AddEnemy(); //spawn new enemy
        }
    }
    #endregion
    #region Functions
    /// <summary>
    /// spawn new enemy and reset timer
    /// </summary>
    private void AddEnemy()
    {
        whereToSpawn = new Vector3(Random.Range(screenTenth, screenTenth*9), screenTop, 0); //random x position for spawn, y position above screen
        Instantiate(enemyPrefab, whereToSpawn, Quaternion.identity, parentObject); //spawn enemy as child of game panel

        timer = Random.Range(0f, 2f); //give timer for next enemy
    }
    #endregion
}
