using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent meshAgent;

    private Vector3 point;

    private Animator animator;

    private int IsRunID;
    private int IsShootID;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        IsRunID = Animator.StringToHash("isRun");
        IsShootID = Animator.StringToHash("IsShoot");

        meshAgent = GetComponent<NavMeshAgent>();
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    public void SetNewWayPoint(Vector3 wayPoint)
    {
        point = wayPoint;

        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, wayPoint, NavMesh.AllAreas, path);
        bool noWay = (path.status == NavMeshPathStatus.PathInvalid);

        if (noWay)
        {
            Debug.LogError("Not correctly way!");
            meshAgent.SetDestination(transform.position);
            animator.SetBool(IsRunID, false);
        }
        else
        {
            animator.SetBool(IsRunID, true);
            meshAgent.SetDestination(wayPoint);
        }
    }

    public void RotateToShootDirect(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.normalized.x, 0, direction.normalized.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1);

        animator.SetTrigger(IsShootID);
    }



    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GetComponent<Animator>().enabled = false;
        //    foreach (var i in rigidbodies)
        //    {
        //        i.isKinematic = false;
        //    }
        //}

        if (!meshAgent.pathPending)
        {
            if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
            {
                //if (!meshAgent.hasPath || meshAgent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool(IsRunID, false);
                }
            }
        }
    }
}
