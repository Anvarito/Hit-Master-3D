using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody[] rigidbodies;
    void Start()
    {
        foreach(var i in rigidbodies)
        {
            i.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().enabled = false;
            foreach (var i in rigidbodies)
            {
                i.isKinematic = false;
            }
        }
    }
}
