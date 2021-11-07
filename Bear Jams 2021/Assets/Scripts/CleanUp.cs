using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanUp : MonoBehaviour
{
    private int messes;
    private GameObject[] messObjects;

    [SerializeField] [Tooltip("hint background")] 
    private Sprite hintBack;
    [SerializeField] [Tooltip("normal background")] 
    private Sprite normBack;
    private bool hintToggled;

    private bool isPlaying;
    [SerializeField] [Tooltip("dialogue delay")] 
    private float dialogueDelay;
    private GameObject dirs;


    // Start is called before the first frame update
    void Start()
    {
        hintToggled = false;
        isPlaying = false;
        messes = 3;
        messObjects = GameObject.FindGameObjectsWithTag("mess");

        dirs = transform.Find("directions").gameObject;
        dirs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dialogueDelay -= Time.deltaTime;
        if (dialogueDelay <= 0)
        {
            dirs.SetActive(true);
            transform.Find("dialogue").gameObject.SetActive(false);
        }

        if(messes == 0 && isPlaying == false) {
            // go back to task list, play audio
            GameManager.Instance.gameState.CompletedTasks.Add(2); // 2 - clean up task
            playDone();
            GameManager.Instance.StartGame();
        }
    }

    public void playDone()
    {
        isPlaying = true;
        AudioSource comp = GameObject.Find("completed").GetComponent<AudioSource>();
        comp.Play();
    }

    public void DestroyThisCat()
    {
        messes--;
        Destroy(transform.Find("cat").gameObject);
    }

    public void CleanPuddle()
    {
        messes--;
        Destroy(transform.Find("puddle").gameObject);
    }

    public void CleanSpill()
    {
        messes--;
        Destroy(transform.Find("coffee").gameObject);
    }

    public void Hint()
    {
        hintToggled = !hintToggled;
        GameObject background = transform.Find("Background").gameObject;
        if(hintToggled == true)
        {
            background.GetComponent<Image>().sprite = hintBack;
            foreach (GameObject obj in messObjects)
            {
                if(obj != null)
                {
                    obj.SetActive(false);
                }
            }
        } else {
            background.GetComponent<Image>().sprite = normBack;
            foreach (GameObject obj in messObjects)
            {
                if(obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
