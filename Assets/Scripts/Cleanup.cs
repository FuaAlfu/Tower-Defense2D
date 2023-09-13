using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.10
/// </summary>

public class Cleanup : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
