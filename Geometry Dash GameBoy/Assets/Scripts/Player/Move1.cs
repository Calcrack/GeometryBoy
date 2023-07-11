using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class Move1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed = 10.0f;
    public float JumpForce = 17.3f;
    public bool Salto = false;
    public bool Muerto = false;
    public int Vida = 0;
    public TextMeshProUGUI TXV;
    public bool Pause = false;
    public AudioSource musica;
    public SpriteRenderer SP;
    public AudioSource mue;

    public TextMeshProUGUI Resume;
    public TextMeshProUGUI Quit;
    public Button ResumeB;
    public Button QuitB;
    public bool vuelo = false;
    public bool portal = false;
    public Follow fw;
    public int score = 0;
    public TextMeshProUGUI scoret;
    public float timer = 0;
    float scoreIncrementInterval = 1f;
    float parpa = 0;
    float parpade = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ResumeB.interactable = false;
        QuitB.interactable = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= scoreIncrementInterval)
        {
            score--;
            timer = 0f; // Reiniciar el contador
        }
        parpa += 1f; // Suma 1 cada 2 segundos
        if (!vuelo)
        {
            if (parpa % 3 == 0)
            {
                parpa -= 2f; // Resta 2 cada 3 sumas
            }

            if (parpa % 2 == 0)
            {
                SP.sprite = Resources.Load<Sprite>("sprites/1"); // Cambia al sprite "ola"
            }
            else
            {
                SP.sprite = Resources.Load<Sprite>("sprites/2"); // Cambia al sprite "alo"
            }
        }
        else
        {
            if (parpa % 3 == 0)
            {
                parpa -= 2f; // Resta 2 cada 3 sumas
            }

            if (parpa % 2 == 0)
            {
                SP.sprite = Resources.Load<Sprite>("sprites/1"); // Cambia al sprite "ola"
            }
            else
            {
                SP.sprite = Resources.Load<Sprite>("sprites/0"); // Cambia al sprite "alo"
            }
        }
        scoret.text = "Score " + score.ToString();
        TXV.text = Vida.ToString();
        Movee();
        if (!vuelo)
        {
            if ((Input.touchCount > 0 || Input.GetKey("space") || Input.GetButton("Fire1")) && !Salto)
            {
                Jump();
            }
        }
        else
        {
            if ((Input.touchCount > 0 || Input.GetKey("space") || Input.GetButton("Fire1")))
            {
                JumpV();
            }
        }
        if (Muerto)
        {
            score -= 100;
            musica.Stop();
            musica.Play();
            Vector2 reset = new Vector2(-4, -1);
            transform.position = new Vector3(reset.x, reset.y, transform.position.z);
            Vida -= 1;
            portal = false;
            vuelo = false;
            Salto = false;
            rb.gravityScale = 7;
            JumpForce = 17.3f;
            Muerto = false;
            fw.minY = 3;
            fw.maxY = 3;
            MoveSpeed = 10;
        }
        if (portal)
        {
            if (!vuelo)
            {
                Salto = true;
            }
            if (vuelo)
            {
                Salto = false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {

            if (Pause)
                despausa();
            else
                pausa();
        }
    }
    private void pausa()
    {
        ResumeB.interactable = true;
        QuitB.interactable = true;
        Resume.color = new Color(Resume.color.r, Resume.color.g, Resume.color.b, 1f);
        Quit.color = new Color(Quit.color.r, Quit.color.g, Quit.color.b, 1f);
        Time.timeScale = 0f;
        Pause = true;
        musica.Pause();
    }
    public void despausa()
    {
        ResumeB.interactable = false;
        QuitB.interactable = false;
        Resume.color = new Color(Resume.color.r, Resume.color.g, Resume.color.b, 0f);
        Quit.color = new Color(Quit.color.r, Quit.color.g, Quit.color.b, 0f);
        Time.timeScale = 1f;
        Pause = false;
        musica.Play();
    }
    private void Movee()
    {
        rb.position += Vector2.right * MoveSpeed * Time.deltaTime;

    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        Salto = true;
    }
    private void JumpV()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);
        Salto = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Salto = false;
        }

        if (collision.gameObject.CompareTag("Pincho"))
        {
            mue.Play();
            Muerto = true;
        }

        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("WIN");
        }

    }
    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Portal"))
        {
            SP.sprite = Resources.Load<Sprite>("sprites/2");
            portal = true;
            vuelo = true;
            rb.gravityScale = 1.7f;
            JumpForce = 35;
        }
        if (Other.gameObject.CompareTag("PortalS"))
        {
            SP.sprite = Resources.Load<Sprite>("sprites/1");
            portal = false;
            vuelo = false;
            rb.gravityScale = 7;
            JumpForce = 17.3f;
            MoveSpeed = 10;
        }
        if (Other.gameObject.CompareTag("cam"))
        {
            fw.minY = 7;
            fw.maxY = 7;
            MoveSpeed = 8;
        }

    }
    public void quit()
    {
        Time.timeScale = 1f;
        Vector2 reset = new Vector2(-7, -1);
        transform.position = new Vector3(reset.x, reset.y, transform.position.z);
        Vida = 3;
        SceneManager.LoadScene("Menu");
    }
}
