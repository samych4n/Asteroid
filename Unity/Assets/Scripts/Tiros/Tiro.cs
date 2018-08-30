using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tiro : MonoBehaviour {
    [SerializeField] float speed = 1;
    [SerializeField] int dano = 1;

    private void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed * 10, Space.World);
        if ((transform.position.x > GameBounds.instance.BoundX) ||
            (transform.position.y > GameBounds.instance.BoundY) ||
            (transform.position.x < -GameBounds.instance.BoundX) ||
            (transform.position.y < -GameBounds.instance.BoundY)) Destroy(this.gameObject);
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Asteroid>())
        {
            collision.GetComponent<Asteroid>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
        if (collision.GetComponent<Alien>())
        {
            collision.GetComponent<Alien>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
    }
}
