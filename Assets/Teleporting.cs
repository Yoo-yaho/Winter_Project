using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporting : MonoBehaviour
{
    public void Interact()
    {
        LoadingScene.LoadScene("NextScene");
    }
}
