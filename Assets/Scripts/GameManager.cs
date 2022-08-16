using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance{ get; set;}

    public TextMeshProUGUI coinsCollected; 
    public TextMeshProUGUI coinsHighscore;

    [SerializeField]
    private int CoinsCollected = 0;
    private int HighestCoinsCollected = 0;
    private void Awake(){
        if(Instance!=null)
        {
            Destroy(Instance);
        }
       Instance = this;
       DontDestroyOnLoad(Instance);
    }
    private void Start(){
        UpdateCoinUIText();
        UpdateHighestScoreCoinUIText();
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.T)){
            SceneManager.LoadScene("Level 2");
        }
        if (Input.GetKeyDown(KeyCode.Y))
            SceneManager.LoadScene("Level 1");
    }
    public void CollectCoin()
    {
        CoinsCollected++;
        //computing the highscore
        int highScore = PlayerPrefs.GetInt("highScore",0);
        if (CoinsCollected> highScore){
            PlayerPrefs.SetInt("highScore", CoinsCollected);
        }
        UpdateCoinUIText();
        UpdateHighestScoreCoinUIText();
    }
    public void ResetCoins(){
        CoinsCollected = 0;
        UpdateCoinUIText();
        UpdateHighestScoreCoinUIText();
    }
    public void UpdateCoinUIText(){
        int numberOfCoins = GetCoinsCollected();
        coinsCollected.text = numberOfCoins.ToString();
    }
    public void UpdateHighestScoreCoinUIText(){
        int highScore = PlayerPrefs.GetInt("highScore",0);
        coinsHighscore.text = highScore.ToString();
    }
    public int GetCoinsCollected()
    {
        return CoinsCollected;
    }
}

