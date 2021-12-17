using UnityEngine;
using TMPro;
public class Gamemaneger : MonoBehaviour
{
    private int score = 0;
    public GameObject gameoverPanel;
    public TextMeshProUGUI scoreText;
    public void increaseScore(int s)
    {

        score += s;
    }

    private void Awake()
    {
        gameoverPanel.SetActive(false);
    }
    public int getScore() => score;

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void gameover()
    {
        scoreText.text = score.ToString();
        pauseGame();
        gameoverPanel.SetActive(true);
    }
}
