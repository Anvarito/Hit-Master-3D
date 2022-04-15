using UnityEngine;
using Cinemachine;

public class CameraBahaviour : MonoBehaviour
{
    public Camera camera;
    public CinemachineVirtualCamera virtualCamera;
    public void SetLookAt(Transform newLookAt)
    {
        virtualCamera.LookAt = newLookAt;
    }

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    private int qwe = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(qwe ==0)
                virtualCamera.LookAt = pos1;
            if (qwe == 1)
                virtualCamera.LookAt = pos2;
            if (qwe == 2)
                virtualCamera.LookAt = pos3;

            qwe++;
            if (qwe > 2)
                qwe = 0;
        }
    }
}
