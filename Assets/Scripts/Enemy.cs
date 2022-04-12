using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Collider[] colliders;
    public Collider mainCollider;
    public Rigidbody mainRigid;

    public Animator animator;

    private bool isDead;

    private Platform platform;
    public bool IsDeadStatus()
    {
        return isDead;
    }

    private void Awake()
    {
        platform = GetComponentInParent<Platform>();
    }

    void Start()
    {
        mainCollider.enabled = true;
        animator.enabled = true;
        foreach (var c in colliders)
        {
            c.enabled = false;
        }
        foreach (var r in rigidbodies)
        {
            r.isKinematic = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet;
        if (collision.collider.TryGetComponent(out bullet))
        {
            isDead = true;
            RagDollActivate();
            platform.CompleteCheker();
        }
    }

    private void RagDollActivate()
    {
        Destroy(mainCollider);
        Destroy(mainRigid);
        animator.enabled = false;

        Vector3 force = (transform.position - Camera.main.transform.position).normalized;

        foreach (var c in colliders)
        {
            c.enabled = true;
        }
        foreach (var r in rigidbodies)
        {
            r.isKinematic = false;
            r.AddForce(force * 80, ForceMode.Impulse);
        }
    }
}
