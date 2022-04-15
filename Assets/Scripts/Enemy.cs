using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Rigidbody[] rigidbodies;

    public Animator animator;

    private bool isDead = false;

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
        animator.enabled = true;
        
        foreach (var r in rigidbodies)
        {
            r.isKinematic = true;
            r.gameObject.AddComponent<RagDollElement>().enemy = this;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Bullet bullet;
        //if (collision.collider.TryGetComponent(out bullet))
        //{
        //    isDead = true;
        //    RagDollActivate();
        //    platform.CompleteCheker();
        //}
    }

    public void RagDollActivate()
    {
        animator.enabled = false;

        foreach (var r in rigidbodies)
        {
            r.isKinematic = false;
        }
    }
}
