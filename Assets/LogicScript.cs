using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject menuScreen;
    public AudioSource pointSFX;
    public AudioSource gameOverSFX;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }

        highScoreText.text = $"Highscore:{PlayerPrefs.GetInt("highScore")}";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuScreen.activeSelf)
                menuScreen.SetActive(true);
            else
                menuScreen.SetActive(false);

        }

    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        pointSFX.Play();
        playerScore += 1;
        scoreText.text = playerScore.ToString();

        if (PlayerPrefs.GetInt("highScore") < playerScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }

        highScoreText.text = $"Highscore:{PlayerPrefs.GetInt("highScore")}";
    }

    [ContextMenu("Restart Game")]
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverSFX.Play();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    //void OnApplicationFocus(bool hasFocus)
    //{
    //    if (!hasFocus)
    //    {
    //        Debug.Log("Jogo minimizado ou gesto de sair detectado!");
    //        // Pode abrir um menu de pausa ou salvar progresso
    //    }
    //}

}
