using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;
    int score = 0;

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }

}
