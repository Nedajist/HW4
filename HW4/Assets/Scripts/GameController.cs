using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static Bird;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public delegate void ScoreDelegate(int current_score, int high_score);
    public event ScoreDelegate ScoreUpdated;

    public Bird bird { get; private set; }

    [SerializeField] GameObject pipe;
    private float _timeUntilPipeSpawn = 0;
    private int current_score;
    private int high_score;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject birdObject = GameObject.FindWithTag("Bird");
        bird = birdObject.GetComponent<Bird>();
        bird.BirdPointAdded += _addScore;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        _timeUntilPipeSpawn -= Time.deltaTime;
        if (_timeUntilPipeSpawn <= 0)
        {
            GameObject new_pipe = Instantiate(pipe);
            new_pipe.transform.position = new Vector3(8.7f, Random.Range(-2.5f, 2.5f), 0.0f);
            _timeUntilPipeSpawn = Random.Range(1.5f, 3);
        }
    }

    public void ResetGame()
    {
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(pipe.gameObject);
            bird.transform.position = new Vector3(-1.2775f, 0.247f, 0);
        }
        current_score = 0;
        ScoreUpdated.Invoke(current_score, high_score);

    }

    public void _addScore()
    {
        current_score += 1;
        _updateScore();
    }

    public void _updateScore()
    {
        if (current_score > high_score)
        {
            high_score = current_score;
        }
        ScoreUpdated.Invoke(current_score, high_score);
    }

}
