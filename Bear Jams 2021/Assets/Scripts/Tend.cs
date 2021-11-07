using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tend : MonoBehaviour
{

    [SerializeField] [Tooltip("dialogue delay")] 
    private float dialogueDelay;
    private GameObject dirs;
    private GameObject meter;

    private int count;
    private bool isPlaying;

    [SerializeField] [Tooltip("progress bars")] 
    private List<Sprite> pbs;
    [SerializeField] [Tooltip("progress bar")] 
    private GameObject pb;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        dirs = transform.Find("Directions").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 4 && isPlaying == false)
        {
            playDone();
            GameManager.Instance.gameState.CompletedTasks.Add(1); 
        }

        dialogueDelay -= Time.deltaTime;
        if (dialogueDelay <= 0)
        {
            dirs.SetActive(false);
        }
    }

    public void playDone()
    {
        isPlaying = true;
        AudioSource comp = GameObject.Find("completed").GetComponent<AudioSource>();
        comp.Play();
    }

    public void water()
    {
        count += 1;
        pb.GetComponent<Image>().sprite = pbs[count];
    }
}