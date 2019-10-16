using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    //private FoodController foodController;
    //private int foodValue;

    private void Awake()
    {
        //foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        //foodValue = foodController.scoreVal;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DebugFunctionality();
        //scoreText.text = "Score: " + foodController.AddScore(foodValue);
    }

    public void DebugFunctionality()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
