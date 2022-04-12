using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float speed;
    private Vector3 direction;
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
