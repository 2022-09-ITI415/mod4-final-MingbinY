using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipTable : MonoBehaviour
{
    Inventory inventory;
    public GameObject ship;
    public Text countDownText;
    float timer;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        timer = -1f;
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            countDownText.gameObject.SetActive(true);
        }else
        {
            countDownText.gameObject.SetActive(false);
        }

        countDownText.text = timer.ToString();
    }

    public void OnInteraction()
    {
        if (inventory != null)
        {
            if (inventory.SpendComponent(10))
            {
                StartCoroutine(SurvivalPhase());
                GetComponent<Interactable>().enabled = false;
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator SurvivalPhase()
    {
        FindObjectOfType<TaskManager>().NextTask();
        timer = 60f;
        yield return new WaitForSeconds(60f);
        FindObjectOfType<TaskManager>().NextTask();
        ship.GetComponent<Ship>().shipFixed = true;
    }
}

