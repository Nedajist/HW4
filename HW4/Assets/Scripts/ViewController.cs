using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    [SerializeField] AudioSource jump_source;
    [SerializeField] AudioSource second_source;

    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip collide;
    [SerializeField] AudioClip restart;
    [SerializeField] AudioClip collect;

    [SerializeField] TextMeshProUGUI current_score_text;
    [SerializeField] TextMeshProUGUI high_score_text;
    [SerializeField] Button restart_button;

    public delegate void ViewDelegate();



    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.bird.BirdDied += _playCollide;
        GameController.Instance.bird.BirdJumped += _playJump;
        GameController.Instance.bird.BirdPointAdded += _playCollect;
        GameController.Instance.ScoreUpdated += _updateScoreText;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void _playJump()
    {
        jump_source.clip = jump;
        jump_source.Play();

    }

    public void _playCollide()
    {
        second_source.clip = collide;
        second_source.Play();
        restart_button.gameObject.SetActive(true); 
        print(restart_button.enabled);

        Time.timeScale = 0;
    }

    public void _playRestart()
    {
        Time.timeScale = 1;
        second_source.clip = restart;
        second_source.Play();
        restart_button.gameObject.SetActive(false);
    }

    public void _playCollect()
    {
        second_source.clip = collect;
        second_source.Play();
            
    }

    public void _updateScoreText(int current_score, int high_score)
    {

        current_score_text.text = current_score.ToString();
        high_score_text.text = "Hi-score: " + high_score.ToString();
    }

}
