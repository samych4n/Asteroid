using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Highscore : MonoBehaviour {
    [SerializeField] TextMeshProUGUI[] scoreUI;
    int[] placar;
    int? idx = null;
    private void Awake()
    {

        placar = new int[]{
                PlayerPrefs.GetInt("Score1", 50000),
                PlayerPrefs.GetInt("Score2", 10000),
                PlayerPrefs.GetInt("Score3", 5000),
                PlayerPrefs.GetInt("Score4", 3000),
                PlayerPrefs.GetInt("Score5", 1000)
        };
        for(int i = 0; i< placar.Length; i++)
        {
            if(placar[i] < Score.CurrentScore)
            {
                ChangeScore(i);
                break;
            }
        }
        LoadScore();
    }
    private void LoadScore()
    {
        for (int i = 0; i < placar.Length; i++)
        { 
            scoreUI[i].text = (i + 1).ToString() + " - " + ((float)placar[i] / 1000f).ToString("#0.000");
        }
        if (idx != null)
        {
            scoreUI[(int)idx].gameObject.GetComponent<Animator>().SetBool("isHighScore", true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }   
    }

    private void ChangeScore(int idxPos)
    {
        idx = idxPos;
        for(int i = placar.Length - 1; i > idxPos; i--)
        {
            placar[i] = placar[i - 1];
        }
        placar[idxPos] = Score.CurrentScore;
        PlayerPrefs.SetInt("Score1", placar[0]);
        PlayerPrefs.SetInt("Score2", placar[1]);
        PlayerPrefs.SetInt("Score3", placar[2]);
        PlayerPrefs.SetInt("Score4", placar[3]);
        PlayerPrefs.SetInt("Score5", placar[4]);
    }
}
