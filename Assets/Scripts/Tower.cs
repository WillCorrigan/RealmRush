using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
        StartCoroutine("ShootAtEnemy");
    }

    IEnumerator ShootAtEnemy()
    {
        var spawn = transform.Find("Tower_A_Top");
        GameObject bullet = Instantiate(bulletPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        yield return new WaitForSeconds(3);
    }
}
