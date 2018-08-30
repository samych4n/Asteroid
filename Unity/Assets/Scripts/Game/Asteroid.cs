using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField] int life = 1;
    [SerializeField] float speed = 1;
    [SerializeField] Asteroid[] miniAsteroids;
    [SerializeField] float margin = 1;
    [SerializeField] int pontos = 100;
    int currentLife;
    Animator anim;
    Vector2 direction;
    Rigidbody2D rb;


    private void Awake()
    {
        currentLife = life;
        anim = GetComponentInChildren<Animator>();
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        direction.Normalize();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed * 100);
    }
    private void Update()
    {
        //rb.velocity = rb.velocity.normalized * speed ;
        Vector3 pos = transform.position;
        if (transform.position.x - margin > GameBounds.instance.BoundX) pos.x = -GameBounds.instance.BoundX - margin;
        if (transform.position.y - margin > GameBounds.instance.BoundY) pos.y = -GameBounds.instance.BoundY - margin;
        if (transform.position.x + margin < -GameBounds.instance.BoundX) pos.x = GameBounds.instance.BoundX + margin;
        if (transform.position.y + margin < -GameBounds.instance.BoundY) pos.y = GameBounds.instance.BoundY + margin;
        transform.position = pos;
    }


    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        if(currentLife <= 0)
        {
            Score.AddScore(pontos);
            anim.SetBool("death", true);
            rb.simulated = false;
            foreach(Asteroid miniAsteroid in miniAsteroids)
            {
                Instantiate(miniAsteroid, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject,2f);
        }

    }

    
}
