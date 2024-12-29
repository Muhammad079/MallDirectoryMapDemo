using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public AppScreem[] appScreems;

    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

}
