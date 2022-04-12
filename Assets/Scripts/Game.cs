using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bulletPref;
    public Transform spawnPoint;

    public Bullet[] bullets;
    private int bulletNumber = 0;
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
            if (Physics.Raycast(ray, out hit))
            {
                BulletSpawn(hit.point);
            }
        }
    }


    private void BulletSpawn(Vector3 target)
    {
        Bullet bullet = bullets[bulletNumber];

        if (!bullet.gameObject.activeInHierarchy)
            bullet.gameObject.SetActive(true);

        bullet.transform.parent = gameObject.transform;
        bullet.transform.name = "bullet " + bulletNumber.ToString();

        bullet.transform.position = spawnPoint.position;
        bullet.SetDirection(target - spawnPoint.position);

        bulletNumber++;
        if (bulletNumber > bullets.Length - 1)
            bulletNumber = 0;

    }
}
