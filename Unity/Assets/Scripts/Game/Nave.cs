using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour {

    [SerializeField] Transform[] weapons;
    [SerializeField] Tiro defaultShoot;
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float shootSpeed = 1;
    [SerializeField] float maxSpeed = 2;
    [SerializeField] Image tiroEspecialUI;
    [SerializeField] Image tiroEspecialTimerUI;
    Tiro shoot;
    bool isTiroEspecial = false;
    float tiroEspecialDuracao;
    float tiroEspecialTempoAtual;
    public int CurrentLife { get { return _currentLife; } }
    bool shootReady = true;
    bool invencible = false;
    int _maxLife = 4;
    int _currentLife;
    Rigidbody2D rb;
    Animator anim;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentLife = _maxLife;
        anim = GetComponent<Animator>();
        shoot = defaultShoot;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentLife <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("HighScore");
            return;
        }
        else
        {
            transform.Rotate(transform.forward * -Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotateSpeed * 100);
            rb.AddForce(transform.up * Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed * 100);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity,maxSpeed);
            if (shootReady && Input.GetKeyDown(KeyCode.Space))
            {
                foreach(Transform weapon in weapons)
                {
                    shootReady = false;
                    Instantiate(shoot, weapon.position,weapon.rotation);
                    StartCoroutine(ShootAwait());
                }

            }
            Vector3 pos = transform.position;
            if (transform.position.x > GameBounds.instance.BoundX) pos.x = -GameBounds.instance.BoundX;
            if (transform.position.y > GameBounds.instance.BoundY) pos.y = -GameBounds.instance.BoundY;
            if (transform.position.x < -GameBounds.instance.BoundX) pos.x = GameBounds.instance.BoundX;
            if (transform.position.y < -GameBounds.instance.BoundY) pos.y = GameBounds.instance.BoundY;
            transform.position = pos;
        }
        if (isTiroEspecial)
        {
            if (tiroEspecialTempoAtual <= 0)
            {
                isTiroEspecial = false;
                tiroEspecialUI.gameObject.SetActive(false);
                shoot = defaultShoot;
            }
            else
            {
                tiroEspecialTempoAtual -= Time.deltaTime;
                tiroEspecialTimerUI.fillAmount = 1f - (tiroEspecialTempoAtual / tiroEspecialDuracao);
            }
        }
        
        

    }
    IEnumerator ShootAwait()
    {
        yield return new WaitForSeconds(1 / shootSpeed);
        shootReady = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!invencible && collision.GetComponent<Asteroid>())
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attack>())
        {
            shoot = collision.GetComponent<Attack>().TiroEspecial;
            tiroEspecialDuracao = collision.GetComponent<Attack>().DuracaoEfeito;
            tiroEspecialTempoAtual = tiroEspecialDuracao;
            tiroEspecialTimerUI.fillAmount = 0;
            tiroEspecialUI.gameObject.SetActive(true);
            isTiroEspecial = true;
            collision.GetComponent<Attack>().Coletado();
        }
        if (collision.GetComponent<Poison>())
        {
            TakeDamage();
            collision.GetComponent<Poison>().Coletado();
        }
    }

    private void TakeDamage()
    {
        _currentLife -= 1;
        if(_currentLife <= 0)
        {
            anim.SetBool("death", true);
            rb.simulated = false;
        }
        else
        {
            invencible = true;
            anim.SetBool("invencible", invencible);
            StartCoroutine(EndInvencible());
        }
        
    }
    IEnumerator EndInvencible()
    {
        yield return new WaitForSeconds(1);
        invencible = false;
        anim.SetBool("invencible", invencible);
    }
    
}
