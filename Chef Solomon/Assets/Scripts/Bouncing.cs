using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    private CutController cutController;

    // Start is called before the first frame update
    void Start()
    {
        cutController = GameObject.FindGameObjectWithTag("Target").GetComponent<CutController>();
        StartCoroutine("WaitAndReturn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.position = (new Vector3(1f, 3f, 0f));
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.position = (new Vector3(1f, 2.5f, 0f));
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.position = (new Vector3(1f, 3.5f, 0f));
        StartCoroutine("WaitAndReturn");
    }
}
