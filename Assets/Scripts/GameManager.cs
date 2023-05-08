using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

     public List<GameObject> targets;
     public TextMeshProUGUI scoreText;
     public GameOverScreen GameOverScreen;
     private int score;
     private float spawnRate = 1.0f;
     bool gameHasEnded = false;
     bool spwanThings = false;
    // Start is called before the first frame update
    void Start()
    {
        spwanThings = true;
        if(spwanThings)
        {
            StartCoroutine(SpawnTarget());
            score = 0;
            UpdateScore(0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            spwanThings = false;
            Debug.Log("Game Over");
            GameOverScreen.SetUp();
        }
    }
}
