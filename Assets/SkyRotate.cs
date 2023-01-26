using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotate : MonoBehaviour
{
    RenderSettings renderSettings;
    Rigidbody rigidbody;

    public void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1f);
    }
}
