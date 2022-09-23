using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnglerAttack : MonoBehaviour
{
    public GameObject Blackout;
    public bool triggered;
    public AudioSource audio;
    public GameObject tpPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!triggered)
            {
                triggered = true;
                StartCoroutine(Attack(other.GameObject()));
            }
        }
        
    }

    public IEnumerator Attack(GameObject player)
    {
        Blackout.GetComponent<Blackout>().StartFade();
        audio.Play();
        player.transform.position = tpPoint.transform.position;
        player.transform.rotation = tpPoint.transform.rotation;
        
        yield return new WaitForSeconds(1);
        Blackout.GetComponent<Blackout>().ReverseFade();
    }
}
