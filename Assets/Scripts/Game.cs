using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bulletPref;
    private Bullet bullet;
    public Transform spawnPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit))
            {
                bullet = Instantiate(bulletPref, spawnPoint.position, Quaternion.identity);
                bullet.SetDirection(hit.point - spawnPoint.position);
            }
        }
    }
}
