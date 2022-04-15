using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Rigidbody[] rigidbodies;

    public Animator animator;

    [HideInInspector] public bool isDead { get; private set; }

    private Platform platform;

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

    public void RagDollActivate()
    {
        animator.enabled = false;

        foreach (var r in rigidbodies)
        {
            r.isKinematic = false;
        }

        isDead = true;
        platform.CompleteCheker();
    }
}
