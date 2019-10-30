using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private PlayerController totalFails;

    private GameObject gameOverScreen;

    private int fails;

    //private FoodController foodController;
    //private int foodValue;

    private void Awake()
    {
        Time.timeScale = 1;
        //foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        //foodValue = foodController.scoreVal;
        totalFails = GameObject.FindGameObjectWithTag("Cleaver").GetComponent<PlayerController>();
        gameOverScreen = GameObject.Find("GameOver Screen");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fails = totalFails.totalFails;
        DebugFunctionality();
        GameOver();
        Debug.Log("Total fails are: " + fails);
       //scoreText.text = "Score: " + foodController.AddScore(foodValue);
    }

    public void DebugFunctionality()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        if(fails >= 3)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
