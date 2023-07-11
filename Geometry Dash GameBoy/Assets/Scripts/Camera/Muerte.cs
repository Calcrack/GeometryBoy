using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Muerte : MonoBehaviour
{
    float timer = 0f;
    float scoreIncrementInterval = 3f;
    public float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= scoreIncrementInterval)
        {
            score++;
            timer = 0f; // Reiniciar el contador
        }
        if(score == 2)
        {
            SceneManager.LoadScene(3);
        }
    }
}
