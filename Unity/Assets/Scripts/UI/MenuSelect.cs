using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSelect : MonoBehaviour {
    [SerializeField] RectTransform selector;
    [SerializeField] RectTransform[] menu;
    int count = 0;
    int lastVertical = 0;
    

    private void Update()
    {
        var vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        if(lastVertical != vertical)
        {
            lastVertical = vertical;
            count -= Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
            count = Mathf.Clamp(count, 0, menu.Length - 1);

            selector.anchoredPosition = new Vector2(selector.anchoredPosition.x, menu[count].anchoredPosition.y);
            //selector.anchorMin = new Vector2(selector.anchorMin.x, menu[count].anchorMin.y);
        }
        if(count == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Score.ResetScore();
            SceneManager.LoadScene("Jogo");
        }



    }

}
