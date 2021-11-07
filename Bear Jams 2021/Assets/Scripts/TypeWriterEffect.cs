using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] [Tooltip("speed of text typing")]
    public float delay = 0.1f;

    [SerializeField] [Tooltip("full message")]
    public string fullText;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
