using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverUI;

    public GameObject gameCompleteUI;
    public Text zombieCountText;
    public Text timeSpendText;

    float timer;

    private void Awake()
    {
        timer = 0f;
    }

    public void GameOver()
    {
        gameoverUI.SetActive(true);
        Invoke("ReloadScene", 5f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameComplete()
    {
        gameCompleteUI.SetActive(true);
        zombieCountText.text = FindObjectOfType<ZombieKilledUI>().GetComponent<Text>().text;
        timeSpendText.text = timer.ToString();
        Invoke("ReloadScene", 5f);
    }
}
