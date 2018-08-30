using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour {

    [SerializeField] float duracao = 3;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, duracao);
    }

    public void Coletado()
    {
        Destroy(gameObject);
    }

}
