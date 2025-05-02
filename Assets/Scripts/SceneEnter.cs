using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SceneEnter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject box;
    [SerializeField] Material targetMaterial;
    [SerializeField] AudioSource[] source;
    public float duration = 1.0f;

    private Color startColor = new Color(1f, 1f, 1f, 1f);
    private Color endColor = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        box.SetActive(true);
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        float elapsedTime = 0;

        box.SetActive(true);

        targetMaterial.color = startColor;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float lerp = Mathf.Clamp01(elapsedTime / duration);

            targetMaterial.color = Color.Lerp(startColor, endColor, lerp);

            for (int i = 0; i < source.Length; i++)
            {
                source[i].volume = lerp;
            }
            yield return null;
        }

        targetMaterial.color = endColor;
        box.SetActive(false);
        yield return null;

    }
}
