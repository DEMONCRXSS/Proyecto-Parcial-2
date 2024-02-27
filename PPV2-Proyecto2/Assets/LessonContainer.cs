using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessions = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuraction")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    // Start is called before the first frame update
    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObjec lessonContainer");
        }
        
    }


    public void OnUpdateUI()
    {
        if (StageTitle != null || LessonStage != null)
        {
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de" + TotalLessions;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    //Este método activa/desactiva la ventana de lessonContainer

    public void EnableWindow()
    {
        if (lessonContainer.activeSelf)
        {
            //Desactiva el Objeto si está activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //Active el objeto si está desactivado
            lessonContainer.SetActive(true);
        }
    }

}
