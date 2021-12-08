using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BirdEntityBase3 : MonoBehaviour
{
    [SerializeField] protected GameObject birdObj;
    [SerializeField] protected MovementController MovementCtrl;
    [SerializeField] private AudioClip birdAudioClip;
    [SerializeField] private AudioSource birdAudioSrc;

    public abstract void AppearBird();
    public abstract void DisableBehave();

    public MovementController movementCtrl => MovementCtrl;

    public void MakeSound()
    {
        birdAudioSrc.PlayOneShot(birdAudioClip);
    }
}