using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed;
    public ProjectileScript projectilePrefab;
    public Transform launchOffset;
    public float fireRate;
    float nextFire;
    public ScoreScript hp;
    public AudioSource audioPlayer;
    public AudioClip clip;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.velocity = Vector2.up * speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            myRigidbody.velocity = Vector2.up * 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidbody.velocity = Vector2.down * speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            myRigidbody.velocity = Vector2.down * 0;
        }

        if(transform.position.y < -9)
        {
            myRigidbody.velocity = Vector2.down * 0;
            myRigidbody.velocity = Vector2.up * speed;
        }

        if (transform.position.y > 13)
        {
            myRigidbody.velocity = Vector2.up * 0;
            myRigidbody.velocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time +fireRate;
                audioPlayer.PlayOneShot(clip);
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp.Health();
        }
    }
}
