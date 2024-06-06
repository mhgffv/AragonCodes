using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    [SerializeField] float Destroytime = 3;
    void Start()
    {
        Destroy(gameObject, Destroytime);
    }
}
