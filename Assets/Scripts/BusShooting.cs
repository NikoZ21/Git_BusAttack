using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusShooting : MonoBehaviour
{

    [Header("Gun Settings")]

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletShootPointOne;
    [SerializeField] Transform bulletShootPointTwo;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] float bulletFireRate = 0.2f;
    [SerializeField] float bulletDamage;
    private float bulletTimeToShoot;


    [Header("MissileLauncher Settings")]

    [SerializeField] Transform missileShootPoint;
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float missileForce = 25f;
    [SerializeField] public float missileFireRate = 5f;
    [SerializeField] float missileDamage;
    private float missileTimeToShoot;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetDefaultShootingSettings();
        }
        else
        {
            SetShootingSettings();
        }
    }

    private void SetDefaultShootingSettings()
    {
        UpgradePlayerPrefs.SetMissileRechargeTime(10f);
        missileFireRate = UpgradePlayerPrefs.GetMissileRechargeTime();

        UpgradePlayerPrefs.SetGunFireRate(0.5f);
        bulletFireRate = UpgradePlayerPrefs.GetGunFireRate();

        UpgradePlayerPrefs.SetMissileDamage(100f);
        missileDamage = UpgradePlayerPrefs.GetMissileDamage();

        UpgradePlayerPrefs.SetGunDamage(25f);
        bulletDamage = UpgradePlayerPrefs.GetGunDamage();

    }

    private void SetShootingSettings()
    {
        missileFireRate = UpgradePlayerPrefs.GetMissileRechargeTime();
        bulletFireRate = UpgradePlayerPrefs.GetGunFireRate();
        missileDamage = UpgradePlayerPrefs.GetMissileDamage();
        bulletDamage = UpgradePlayerPrefs.GetGunDamage();
    }

    void Update()
    {
        var bus = FindObjectOfType<BusHealth>();
        if (bus.isAlive == false) return;

        if (Input.GetButton("Fire1") && Time.time > bulletTimeToShoot)
        {
            ShootWithGuns();
        }
        else if (Input.GetKeyDown(KeyCode.F) && Time.time > missileTimeToShoot)
        {
            UnleashBeast();
        }
    }

    void ShootWithGuns()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletShootPointOne.position, transform.rotation);
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, bulletForce), ForceMode2D.Impulse);

        GameObject bulletTwo = Instantiate(bulletPrefab, bulletShootPointTwo.position, transform.rotation);
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        var rbTwo = bulletTwo.GetComponent<Rigidbody2D>();
        rbTwo.AddForce(new Vector2(0, bulletForce), ForceMode2D.Impulse);

        bulletTimeToShoot = Time.time + bulletFireRate;
    }

    void UnleashBeast()
    {
        GameObject missile = Instantiate(missilePrefab, missileShootPoint.position, transform.rotation);
        missile.GetComponent<Missile>().missileDamage = missileDamage;
        var rb = missile.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, missileForce), ForceMode2D.Impulse);
        FindObjectOfType<ChargingMIssileUi>().SetLowAlphaValue();
        missileTimeToShoot = Time.time + missileFireRate;
    }


}
