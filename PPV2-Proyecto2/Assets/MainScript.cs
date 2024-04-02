using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    static MainScript Instance;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;

        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }
}
