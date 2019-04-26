using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static UIManager _instance;

    public static UIManager Instance

    {
        get
        {
            if (_instance == null)
            {
                //UIManager is null
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public GameObject gameEndScreen;
    public Text winnerText;
    public Text diamondText;

    public void DisplayGameEndScreen(string text)
    {
        winnerText.text = text;
        gameEndScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
