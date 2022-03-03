using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI titleText;
    private GameObject difficultyButtons;

    int spawnTarget;
    public float spawnRate = 2;
    private int score;
    public bool isGameActive = false;

    void Start()
    {
        difficultyButtons = GameObject.Find("Diffculty Buttons");
        difficultyButtons.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGameActive);
    }

    IEnumerator TargetSpawnTimer()
    {

        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnTarget = Random.Range(0, 6);
            Instantiate(targets[spawnTarget]);
        }

       
    }

    public void ScoreUpdate(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(TargetSpawnTimer());
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        difficultyButtons.gameObject.SetActive(false);

        spawnRate /= difficulty;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }
}
