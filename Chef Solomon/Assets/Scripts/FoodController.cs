using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    public int scoreVal;
    public int totalScore;

    private float speed = 10f;
    private bool outOfBounds;


    Vector3 xMovement = (Vector3.right);

    // Start is called before the first frame update
    void Start()
    {
        outOfBounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }

    public void Movement()
    {
        transform.Translate(xMovement * speed * Time.deltaTime);
    }

    public void OutOfBounds()
    {
        if (!outOfBounds && transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    public int AddScore(int scoreVal)
    {
        totalScore = scoreVal;

        return totalScore;
    }
}
