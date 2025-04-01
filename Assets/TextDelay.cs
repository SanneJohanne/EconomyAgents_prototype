using System.Collections;
using UnityEngine;
using TMPro;
public class TextDelay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EnableTextAfterTime(5f));
    }

    IEnumerator EnableTextAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject textObject = GameObject.Find("TextBehindCookie");
        if (textObject != null)
        {
            TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                text.enabled = true;
            }
        }
    }
}
