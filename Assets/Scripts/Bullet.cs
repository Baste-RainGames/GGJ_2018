﻿using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    private Rigidbody2D rb;
    public int Damage = 1;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator Start() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void Fire(Vector2 direction) {
        rb.velocity = direction.normalized * bulletSpeed;
        rb.angularVelocity = 1500f;
    }

    public void OnDamagedObject() {
        GetComponent<SpriteRenderer>().color = Color.red;
        Destroy(GetComponent<Collider>());
        Destroy(gameObject, .5f);
    }
}