using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bulletPref;
    public Transform spawnPoint;
    public float bulletSpeed = 0.15f;
    public Bullet[] bullets;
    private int bulletNumber = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    BulletSpawn(hit.point);
                }
            }
        }


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

        bullet.speed = bulletSpeed;
        bullet.transform.parent = gameObject.transform;
        bullet.transform.name = "bullet " + bulletNumber.ToString();

        bullet.transform.position = spawnPoint.position;
        bullet.SetDirection(target - spawnPoint.position);

        bulletNumber++;
        if (bulletNumber > bullets.Length - 1)
            bulletNumber = 0;

    }
}