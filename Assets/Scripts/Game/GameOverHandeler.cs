using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandeler : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    private GameObject _player;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        _player = FindObjectOfType<RotPlayer>().gameObject;
    }
    
    public void GameOver(int score)
    {
        FindObjectOfType<AnswerSpawner>().StopSpawn();
        scoreText.SetText("Nice try :)\n" +
                          $"You scored {score} points");
        gameOverPanel.SetActive(true);
        _player.SetActive(false);
    }

    public void ClickExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClickRetry()
    {
        SceneManager.LoadScene(0);
    }
}
