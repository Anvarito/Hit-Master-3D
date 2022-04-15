using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollElement : MonoBehaviour
{
    public Enemy enemy;
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
