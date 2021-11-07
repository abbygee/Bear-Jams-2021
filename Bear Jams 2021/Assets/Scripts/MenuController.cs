using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Enter()
    {
        GameManager.Instance.Enter();   
    }

    public void EnterThink()
    {
        GameManager.Instance.EnterThink();
    }

    public void BackToMenu()
    {
        GameManager.Instance.Menu();   
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame(); 
    }

    public void TimerScene()
    {
        GameManager.Instance.Timer(); 
    }

    public void Credits()
    {
        GameManager.Instance.Credits();   
    }

    public void Tutorial1()
    {
        GameManager.Instance.Tutorial1();   
    }

    public void Tutorial2()
    {
        GameManager.Instance.Tutorial2();   
    }

    public void Tutorial3()
    {
        GameManager.Instance.Tutorial3();   
    }
    public void CleanUp()
    {
        GameManager.Instance.CleanUp();   
    }
    public void Tend()
    {
        GameManager.Instance.TendPlants();   
    }
    public void Check()
    {
        GameManager.Instance.CheckOrder();   
    }
    
}
