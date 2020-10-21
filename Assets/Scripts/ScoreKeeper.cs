using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    #region Variables
    [Header("UI References")]
    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject losePanel, winPanel;
    [SerializeField] private Text loseText, winText;

    [Header("Game Variables")]
    [SerializeField, Range(0, 100)] private int lives;
    [SerializeField, Range(10, 100)] private int maxLives;
    [SerializeField] private int score;
    [SerializeField] private int winScore = 100;
    #endregion
    #region Start
    void Start()
    {
        Time.timeScale = 1;

        lives = maxLives; //reset lives
        score = 0; //reset score

        UpdateUI(); //update the ui
    }
    #endregion
    #region Update
    void FixedUpdate()
    {
        if (lives <= 0) //if no lives left
        {
            EndGame(losePanel); //die
        }
        else if (score >= winScore) //if reached win score
        {
            EndGame(winPanel); //win
        }
    }
    #endregion
    #region Functions
    /// <summary>
    /// add one to score
    /// </summary>
    public void AddScore()
    {
        score++;
        UpdateUI();
    }
    /// <summary>
    /// take one life
    /// </summary>
    public void LoseLife()
    {
        lives--;
        UpdateUI();
    }
    /// <summary>
    /// reload the scene
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// quit the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// Update the UI elements to reflect current game state
    /// </summary>
    private void UpdateUI()
    {
        livesText.text = "Current lives: " + lives.ToString() + " / " + maxLives.ToString();
        scoreText.text = "Current Score: " + score.ToString();
    }
    /// <summary>
    /// stop time and end game
    /// </summary>
    /// <param name="panel">win or lose panel</param>
    private void EndGame(GameObject panel)
    {
        Time.timeScale = 0; //stop time
        panel.SetActive(true); //bring up panel

        //choose end text
        loseText.text = "Too bad, you ran out of lives with a score of " + score.ToString() + "...";
        winText.text = "Congrats!! You achieved a score of " + score.ToString() + " and won!";
    }
    #endregion
}
