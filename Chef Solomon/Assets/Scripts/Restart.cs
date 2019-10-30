using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject text;
    private CutController cutController;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        cutController = GameObject.FindGameObjectWithTag("Target").GetComponent<CutController>();
        scoreText.text = "Game Over / Score: " + cutController.foodValue;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(text);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
