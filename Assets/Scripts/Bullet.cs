using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float speed;
    private Vector3 direction;
    private Rigidbody rigidbody;
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        gameObject.SetActive(false);
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void Deactivate()
    {
        rigidbody.velocity = Vector3.zero;
        direction = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name + " who: " + collision.transform.root.name);

        RagDollElement rde;
        if (collision.transform.TryGetComponent(out rde))
        {
            rde.enemy.RagDollActivate();
            rde.rigidbody.AddForce(direction * 300, ForceMode.Impulse);
        }

        Deactivate();
    }
}
