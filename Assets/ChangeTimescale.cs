using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimescale : MonoBehaviour
{
    [Range(1,20)]
    [SerializeField] private float TimeScalse = 1;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = TimeScalse;
    }
}
