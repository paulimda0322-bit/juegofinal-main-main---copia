using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public Transform spawnPoint;
    public GameObject player;
    public GameObject gameOverUI;

    public void PlayerFell()
    {
        lives--;
        if (lives > 0)
        {
            player.transform.position = spawnPoint.position;
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}