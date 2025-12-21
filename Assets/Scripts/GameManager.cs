using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameStartPanel;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStartPanel.SetActive(true);
        scoreText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        gameStartPanel.SetActive(false);
        scoreText.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Score()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}
