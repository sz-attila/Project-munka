using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepState : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }
}
