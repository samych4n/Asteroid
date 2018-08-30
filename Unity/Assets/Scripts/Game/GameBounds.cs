using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour {

    public static GameBounds instance;
    

    [SerializeField] float _boundX = 9;
    [SerializeField] float _boundY = 5;
    public float BoundX { get { return _boundX ; } }
    public float BoundY { get { return _boundY ; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
