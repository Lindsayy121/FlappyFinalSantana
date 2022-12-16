using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text scoreText;
    public GameObject gameOvertext;

    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameOver && Input.getMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdDied()
    {
        if (gameOver)
            return;

        score++;

        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }
}
