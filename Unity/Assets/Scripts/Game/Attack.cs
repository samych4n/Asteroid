using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    [SerializeField] Tiro tiroEspecial;
    [SerializeField] float duracao = 3;
    [SerializeField] float duracaoEfeito = 3;
    public Tiro TiroEspecial { get { return tiroEspecial; } }
    public float DuracaoEfeito { get { return duracaoEfeito; } }

    // Use this for initialization
    void Start () {
        Destroy(gameObject, duracao);	
	}
    public void Coletado()
    {
        Destroy(gameObject);
    }
}
