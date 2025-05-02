using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class MaterialFader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject box;
    [SerializeField] Material targetMaterial;
    
    public bool fade = true; 
    public float duration = 3.0f;

    private Color inColor = new Color(1f, 1f, 1f, 1f); 
    private Color outColor = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        box.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeIn()
    {
        fade = true; 
        StartCoroutine(FadeRoutine());
    }

    public void fadeOut()
    {
        fade = false;
        StartCoroutine(FadeRoutine());
    }


    private IEnumerator FadeRoutine()
    {
        float elapsedTime = 0;

        if(fade)
        {
            box.SetActive(true);
        }

        Color startColor = fade ? outColor : inColor;
        Color endColor = fade ? inColor : outColor;
        targetMaterial.color = startColor;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float lerp = Mathf.Clamp01(elapsedTime / duration);

            targetMaterial.color = Color.Lerp(startColor, endColor, lerp);
            

            yield return null;
        }

        targetMaterial.color = endColor;

        if (!fade)
        {
            box.SetActive(false);
        }
    }
}
