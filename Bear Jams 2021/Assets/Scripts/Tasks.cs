using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    private GameObject taskOne; //1
    private GameObject taskTwo; //2
    private GameObject taskThree; //3

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
        if(GameManager.Instance.gameState.CompletedTasks != null)
        {
            if(GameManager.Instance.gameState.CompletedTasks.Contains(1)) //tend
            {
                taskOne = expandedList.transform.Find("tend").gameObject;
                taskOne.transform.Find("crossout1").gameObject.SetActive(true);
                taskOne.GetComponent<Button>().interactable = false;
            }

            if(GameManager.Instance.gameState.CompletedTasks.Contains(2)) //clean up
            {
                //"cross out" clean up
                taskTwo = expandedList.transform.Find("clean").gameObject;
                taskTwo.transform.Find("crossout2").gameObject.SetActive(true);
                taskTwo.GetComponent<Button>().interactable = false;
            }

            if(GameManager.Instance.gameState.CompletedTasks.Contains(3)) //chck order
            {
                taskThree = expandedList.transform.Find("check").gameObject;
                taskThree.transform.Find("crossout3").gameObject.SetActive(true);
                taskThree.GetComponent<Button>().interactable = false;
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
