using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed;
    public float dZone;
    public ScoreScript score;
    public AudioSource audioPlayer;
    public AudioClip clip;
    public HitScript hit;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * movementSpeed) * Time.deltaTime;
        if (transform.position.x < dZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(hit, transform.position, transform.rotation);
        Destroy(gameObject, (float)0.8);
        movementSpeed = 0;
        audioPlayer.PlayOneShot(clip);
        score.addScore();
    }
}
