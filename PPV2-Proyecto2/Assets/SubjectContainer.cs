using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    //Definimos el numero de nuestra Leccion
    [SerializeField]
    public int Lesson = 0;

    [Header("Lession Quest Configuration")]
    [SerializeField]
    //Para definir cuantas preguntas tendra nuestra leccion
    public List<Lección> LeccionList;
}
