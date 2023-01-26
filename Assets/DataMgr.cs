using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            return;

        DontDestroyOnLoad(gameObject);
    }
}