using UnityEngine;
using Cinemachine;

public class CameraBahaviour : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public void SetLookAt(Transform newLookAt)
    {
        virtualCamera.LookAt = newLookAt;
    }
}
