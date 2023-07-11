using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class mini : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed = 10.0f;
    public float JumpForce = 17.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movee();
    }
    private void Movee()
    {
        rb.position += Vector2.right * MoveSpeed * Time.deltaTime;

    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cam"))
        {
            Vector2 reset = new Vector2(-14, -2.5f);
            transform.position = new Vector3(reset.x, reset.y, transform.position.z);

            float randomScale = UnityEngine.Random.Range(0.2f, 5f);
            transform.localScale = new Vector3(randomScale, randomScale, 1f);
        }
    }
}
