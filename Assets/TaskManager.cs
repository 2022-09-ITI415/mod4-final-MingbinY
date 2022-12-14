using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [System.Serializable]
    public class Task
    {
        public string taskDescription;
    }

    public Text taskText;
    public List<string> tasks;
    int taskIndex;

    private void Start()
    {
        taskIndex = 0;
        taskText.text = tasks[taskIndex];
    }

    public void NextTask()
    {
        taskIndex++;
        Debug.Log(taskIndex);
        taskText.text = tasks[taskIndex];
    }

}
