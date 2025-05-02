using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    // Start is called before the first frame update
    [SerializeField] GameObject box;
    [SerializeField] Material targetMaterial;
    [SerializeField] AudioSource source;
    private float duration = 1.0f;

    private Color startColor = new Color(1f, 1f, 1f, 0f);
    private Color endColor = new Color(1f, 1f, 1f, 1f);

    void Start()
    {
        box.SetActive(false);
    }

    public void fadeIn()
    {
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

            float inv = 1f - Mathf.Clamp01(elapsedTime / duration);
            source.volume = inv;

            yield return null;
        }

        targetMaterial.color = endColor;
        yield return null;

        GameStart();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("EnterLobby");
    }

    public void GameQuit() 
    { 
        Application.Quit();
    }
}
