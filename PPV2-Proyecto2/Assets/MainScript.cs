using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public static MainScript Instance;
    public string SelectedLesson = "dummy";

    private void Awake()
    {
        //Creamos la instancia
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        //Recurso que se utiliza para guardar datos por medio de una llave identificadora
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }
}
