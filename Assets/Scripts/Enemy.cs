using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Variables
    [Header("UI References")]
    [SerializeField] private ScoreKeeper scoreKeeper;

    [Header("Movement Variables")]
    [SerializeField, Range(10, 200)] private int speed = 10;
    [SerializeField] private Vector3 endPos;
    #endregion
    #region Start
    void Start()
    {
        speed = Random.Range(1, 20) * (Screen.width / 50);//random speed calculated by screen size
        endPos = new Vector3(gameObject.transform.position.x, -100); //assign direction
        scoreKeeper = GameObject.Find("Script Holder").GetComponent<ScoreKeeper>(); //connect to main script

        gameObject.GetComponent<Button>().onClick.AddListener(Clicked); //add listener for click function
    }
    #endregion
    #region Update
    void Update()
    {
        //move downwards
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, Time.deltaTime * speed);

        if (gameObject.transform.position.y <= -10) //if at bottom
        {
            HitBottom(); //hit bottom
        }
    }
    #endregion
    #region Functions
    /// <summary>
    /// when clicked, add score and delete this enemy
    /// </summary>
    private void Clicked()
    {
        scoreKeeper.AddScore();
        Destroy(gameObject);
    }
    /// <summary>
    /// take life from the player and delete this enemy
    /// </summary>
    private void HitBottom()
    {
        scoreKeeper.LoseLife();
        Destroy(gameObject);
    }
    #endregion
}
