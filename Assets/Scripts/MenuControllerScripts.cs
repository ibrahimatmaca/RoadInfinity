using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerScripts : MonoBehaviour
{
    private int arrayIndex = 0;
    private float bestScore;
    private int totalCoin;
    public Sprite[] spriteArrayBall;

    public Text bestScoreText;
    public Text totalText;
    public Transform changeObject;
    //public GameObject panelBallMarket; 

    private void Start()
    {
        //panelBallMarket.SetActive(false);
        changeObject.transform.GetComponent<SpriteRenderer>().sprite = spriteArrayBall[arrayIndex];

        TextFunctionMenu();
    }


    private void TextFunctionMenu()
    {
        totalCoin = PlayerPrefs.GetInt("Coin");
        //totalCoin += PlayerPrefs.GetInt("Coin");
        totalText.text = totalCoin.ToString() + " C";

        bestScore = PlayerPrefs.GetFloat("Score");  /*PlayerPrefs.GetInt();*/
        bestScoreText.text = "Best Score: " + bestScore.ToString("0");

    }

    public void LoadStartScene()
    {
        PlayerPrefs.SetInt("Ball", arrayIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextBallButton()
    {
        arrayIndex++;
        if (arrayIndex > spriteArrayBall.Length-1)
        {
           arrayIndex = spriteArrayBall.Length - 1;
        }
        changeObject.transform.GetComponent<SpriteRenderer>().sprite = spriteArrayBall[arrayIndex];
    }

    public void PrevBallButton()
    {
        arrayIndex--;
        if (arrayIndex < 0)
        {
            arrayIndex = 0;
        }
        changeObject.transform.GetComponent<SpriteRenderer>().sprite = spriteArrayBall[arrayIndex];
    }

    //public void OpenBallMarketPanel()
    //{
    //    panelBallMarket.SetActive(true);
    //}

    //Marketing system code block
    public void MarketBall(string valueMarket)
    {
        string[] deneme = valueMarket.Split(char.Parse(":"));
        Debug.Log("0. indis elemanı: " + deneme[0]);
        Debug.Log("1. indis elemanı: " + deneme[1]);
    }
}
