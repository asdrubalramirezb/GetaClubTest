using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleEntity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;

    public Rigidbody destructibleRb => rb;
    public Collider destructibleCOllider => col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }
}
