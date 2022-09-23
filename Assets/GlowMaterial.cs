using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GlowMaterial : MonoBehaviour
{
    public Material baseMaterial;
    public Material glowMaterial;
    public MeshRenderer[] meshRenderers;
    public AudioSource audio;
    public GameObject fishParty;
    public Transform fishPartyEnd;
    public Boolean hasFishParty = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger with " + other);
        if (other.gameObject.tag == "Player")
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material = glowMaterial;
            }

            if (hasFishParty)
            {
                StartCoroutine(StartParty());
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("untrigger with " + other);
        if (other.gameObject.tag == "Player")
        {
            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material = baseMaterial;
            }
        }
    }

    IEnumerator StartParty()
    {
        fishParty.gameObject.SetActive(true);
        yield return null;
        // Debug.Log("Move Party Started");
        // float distance = Vector3.Distance(fishParty.transform.position, fishPartyEnd.transform.position);
        // Debug.Log("distance " + distance);
        // while (distance < 0)
        // {
        //     float speed = 10;
        //     float step = speed * Time.deltaTime;
        //     fishParty.transform.position =
        //         Vector3.MoveTowards(fishParty.transform.position, fishPartyEnd.transform.position, step);
        //     yield return null;
        // }
    }
}
