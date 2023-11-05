using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject loseScreen;
    public float jumpForce;
    public int score, hiScore;
    public Text scoreUI, hiScoreUI;
    string HISCORE = "HISCORE";


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        playerJump();
    }
    void playerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    void Playerlose()
    {
        AudioManager.singleton.PlaySound(1);
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        hiScoreUI.text = "HiScore: " + hiScore.ToString();    
    
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "score: " + score.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            //mati
            Playerlose();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            AddScore();
        }
    }
}
