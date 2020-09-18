using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatVar : MonoBehaviour
{
    public static StatVar instance;//static 변수.
    public bool ColaSuc;
    public bool FrySuc;
    public bool BurSuc;
    public bool IceSuc;
    public bool Movable;
    public float time1;
    public bool soundplay;
    public bool TutCookSuccess;
    public bool TutCookFail;

    void Awake()
    {
        instance = this;
        time1 = 1f;
    }
}
