using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverUI;

    public GameObject gameCompleteUI;
    public Text zombieCountText;
    public Text timeSpendText;

    public PlayableDirector playableDirector;
    public GameObject[] ingameUIs;
    float timer;
    string killCount;

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
        zombieCountText.text = killCount;
        timeSpendText.text = timer.ToString();
        Invoke("ReloadScene", 5f);
    }

    public void StartGameEndTimeline()
    {
        killCount = FindObjectOfType<ZombieKilledUI>().GetComponent<Text>().text;
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            spawner.gameObject.SetActive(false);
        }

        ZombieController[] zombies = FindObjectsOfType<ZombieController>();
        foreach (ZombieController zombie in zombies)
        {
            Destroy(zombie.gameObject);
        }

        FindObjectOfType<RaycastInteractor>().gameObject.SetActive(false);
        foreach (GameObject ui in ingameUIs)
        {
            ui.SetActive(false);
        }

        if (playableDirector.state != PlayState.Playing)
            playableDirector.Play();
    }
}
