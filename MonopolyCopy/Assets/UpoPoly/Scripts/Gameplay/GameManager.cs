using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Start()
    {
        if (instance) return;
        instance = this;
    }

    void Update()
    {

    }
}