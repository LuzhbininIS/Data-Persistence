using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreText;
    public TMP_InputField NameText;
    
    public void Start()
    {
        ScoreText.text = "Best Score: " + MenuManager.Instance.BestName + " - " + MenuManager.Instance.BestScore;
    }
    public void Exit()
    {
        MenuManager.Instance.SaveValue();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void NameChanged()
    {
        MenuManager.Instance.CurrName = NameText.text;

        if (MenuManager.Instance.BestScore == 0)
        {
            MenuManager.Instance.BestName = NameText.text;
            ScoreText.text = "Best Score: " + MenuManager.Instance.BestName + " - " + MenuManager.Instance.BestScore;
        }
    }
    public void StartNew(int scene) 
    {
        SceneManager.LoadScene(scene);
    }
    
}
