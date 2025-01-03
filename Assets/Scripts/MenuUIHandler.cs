using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public TextMeshProUGUI highScore;
    public GameObject errorText;
    void Start()
    {
        PersistenceManager.Instance.LoadData();
        if (PersistenceManager.Instance.playerName != "" && PersistenceManager.Instance.highScore != 0)
        {
            inputField.text = PersistenceManager.Instance.playerName;
            highScore.text = $"Best Score:{PersistenceManager.Instance.playerName}({PersistenceManager.Instance.highScore})";
        }
    }
    public void StartGame()
    {

        if (inputField.text != "")
        {
            PersistenceManager.Instance.currentPlayer = inputField.text;
            errorText.SetActive(false);
            SceneManager.LoadScene(1);
        }
        else
        {
            errorText.SetActive(true);
        }
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    // Update is called once per frame
    void Update()
    {

    }

}
