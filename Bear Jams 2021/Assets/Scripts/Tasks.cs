using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    private int taskOne; //1
    private int taskTwo; //2
    private int taskThree; //3

    private GameObject expandedList;
    private GameObject cornerList;
    private bool expanded;
    List<int> taskList;

    // Start is called before the first frame update
    void Start()
    {
        expandedList = transform.Find("Expanded Task List").gameObject;
        cornerList = transform.Find("Task List").gameObject;
        expanded = false;
    }

    // Update is called once per frame
    void Update()
    {
        taskList = GameManager.Instance.gameState.CompletedTasks;
        Debug.Log(taskList);
        foreach (int task in taskList)
        {
            if(task == 2) //clean up
            {
                //"cross out" clean up
            }
        }
    }

    public void Expand()
    {
        expanded = !expanded;
        if (expanded) 
        {
            expandedList.SetActive(true);
            cornerList.SetActive(false);
        }
        
    }
}
