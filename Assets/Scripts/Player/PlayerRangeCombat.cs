using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeCombat : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    
    public float shootRate = 2f;
    private float nextShootTime = 0f;

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Shoot();
                nextShootTime = Time.time + 1f / shootRate;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
