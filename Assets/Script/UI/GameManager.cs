using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GameManager : MonoBehaviour
{
    public bool plyrMovable = false;
    public float worldTime;

    void Start()
    {
        worldTime = 0f;
    }
}
