using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerPosition;

    public static Action platformClear;
    private Enemy[] enemies;

    private void Start()
    {
        enemies = GetComponentsInChildren<Enemy>();
    }

    public Vector3 GetPlatformPlayerPoint()
    {
        return playerPosition.position;
    }
    public void CompleteChecked()
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (!enemies[i].IsDeadStatus())
            {
                return;
            }
        }

        platformClear?.Invoke();
    }
}
