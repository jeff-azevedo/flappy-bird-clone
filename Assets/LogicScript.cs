using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject menuScreen;

    private void Start()
    {
        Debug.Log("start");
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
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Restart Game")]
    public void restartGame()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
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
