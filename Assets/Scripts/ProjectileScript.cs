using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float dZone = 31;
    public float projectileSpeed;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * projectileSpeed;
        if (transform.position.x > dZone)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
