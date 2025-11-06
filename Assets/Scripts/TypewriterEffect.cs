using System.Collections;
using UnityEngine;
using TMPro; 

public class TypewriterEffect : MonoBehaviour
{
    public float textSpeed = 0.05f;

    private TextMeshProUGUI textMeshPro;
    private string fullText;

    void Awake()
    { 
        textMeshPro = GetComponent<TextMeshProUGUI>();

        if (textMeshPro != null)
        {

            fullText = textMeshPro.text;

            textMeshPro.text = "";

            StartCoroutine(ShowText());
        }
    }
    IEnumerator ShowText()
    {
        foreach (char c in fullText)
        {
            textMeshPro.text += c;

          
            yield return new WaitForSeconds(textSpeed);
        }
    }
}