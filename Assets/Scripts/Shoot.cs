using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bulletPref;
    public Transform spawnPoint;
    public float bulletSpeed = 0.15f;
    public Bullet[] bullets;

    private int bulletNumber = 0;
    private Player player;

    private float cooldownTime = 0;
    [SerializeField] private float cooldown = 1;


    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsRun)
            return;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastScreen(touch.position);
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastScreen(Input.mousePosition);
        }
    }


    private void RaycastScreen(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        Vector3 aimPoint;
        if (Physics.Raycast(ray, out hit))
        {
            aimPoint = hit.point;
        }
        else
        {
            aimPoint = ray.origin + ray.direction * 1000;
        }

        if (Time.time >= cooldownTime)
        {
            player.RotateToShootDirect(aimPoint - transform.position);
            BulletSpawn(aimPoint);

            cooldownTime = Time.time + cooldown;
        }
    }

    private void BulletSpawn(Vector3 target)
    {
        Bullet bullet = bullets[bulletNumber];

        bullet.speed = bulletSpeed;
        bullet.transform.name = "bullet " + bulletNumber.ToString();
        bullet.transform.position = spawnPoint.position;
        bullet.SetDirection(target - spawnPoint.position);

        bullet.Activate();

        bulletNumber++;
        if (bulletNumber > bullets.Length - 1)
            bulletNumber = 0;
    }
}
