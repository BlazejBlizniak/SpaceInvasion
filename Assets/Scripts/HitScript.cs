using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class HitScript : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, (float)0.8);
    }
}
