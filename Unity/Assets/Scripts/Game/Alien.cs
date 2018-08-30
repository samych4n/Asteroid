using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    // Update is called once per frame
    [SerializeField] float margin = 2;
    [SerializeField] float speed = 1;
    [SerializeField] int pontos = 1000;
    bool isDeath = false;
    Vector2 direction;
    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        if (transform.position.x > GameBounds.instance.BoundX)
        {
            direction = -Vector2.right;
        }
        else
        {
            direction = Vector2.right;
        }
    }

    void Update () {
        if(!isDeath) transform.Translate(direction * speed * Time.deltaTime * 3);
        if (transform.position.x - margin > GameBounds.instance.BoundX) Destroy(gameObject);
        if (transform.position.x + margin < -GameBounds.instance.BoundX) Destroy(gameObject);
    }

    public void TakeDamage(int dano)
    {
        Score.AddScore(pontos);
        anim.SetBool("death", true);
        rb.simulated = false;
        Destroy(this.gameObject, 2f);
        isDeath = true;
    }
}
