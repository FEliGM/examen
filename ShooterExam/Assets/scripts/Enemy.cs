using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    public Vector3 bulletOffset = new Vector3(0, -0.5f, 0);
    public float timeBetweenShoots = 0.5f;
    public GameObject bulletPrefab;
        public Transform bulletOrigin;
        private float currentHP;
        private float timeOfLastShoot;

        private void Start()
        {
            currentHP = maxHP;
        }

        private void Update()
        {
            if (Time.time==2.0f)
            {
                if (Time.time > timeOfLastShoot + timeBetweenShoots)
                    Shoot();
            }
        }

        public void Damage(float amount)
        {
            currentHP -= amount;

            if (currentHP <= 0f)
            {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
        }


        private void Shoot()
        {
            Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
            timeOfLastShoot = Time.time;
        }
    }