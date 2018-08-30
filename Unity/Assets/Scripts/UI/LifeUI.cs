using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeUI : MonoBehaviour {
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Nave player;
    [SerializeField] TextMeshProUGUI gameOver;

    // Update is called once per frame
    void Update () {
        int life = player.CurrentLife;
        switch (life)
        {
            case 1:
                heart1.fillAmount = 0.5f;
                heart2.fillAmount = 0f;
                break;
            case 2:
                heart1.fillAmount = 1f;
                heart2.fillAmount = 0f;
                break;
            case 3:
                heart1.fillAmount = 1f;
                heart2.fillAmount = 0.5f;
                break;
            case 4:
                heart1.fillAmount = 1f;
                heart2.fillAmount = 1f;
                break;
            default:
                heart1.fillAmount = 0f;
                heart2.fillAmount = 0f;
                gameOver.gameObject.SetActive(true);
                break;
        }
	}
}
