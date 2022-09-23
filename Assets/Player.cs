using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float x_axis;
    public float z_axis;
    public float y_val;
    public Transform cam;
    public float yModifier = 10;
    public Vector3 direction;
    bool lowering = false;
    bool rising = false;
    public float ySpeed = 10;
    public float swimForce = 3;
    public float gravity = -9.81f;
    public float velocity;

    public float groundedDistanceToCheck = .5f;
    public bool isGrounded;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + direction, .5f);
        Gizmos.DrawLine(transform.position, transform.position + direction);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundedDistanceToCheck);
    }

    void Update()
    {
        velocity += gravity * Time.deltaTime;

        x_axis = Input.GetAxis("Horizontal");
        z_axis = Input.GetAxis("Vertical");
        bool lowering = false;
        bool rising = false;
        y_val = 0f;


        if (Physics.Raycast(this.transform.position, Vector3.down, groundedDistanceToCheck))
        {
            isGrounded = true;
        }

        if (isGrounded && velocity <0)
        {
            velocity = 0;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            velocity = swimForce;
            rising = true;
        }

        if (Input.GetButtonDown("Fire3"))
        {
            velocity = -swimForce;
            lowering = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            rising = false;
        }

        if (Input.GetButtonUp("Fire3"))
        {
            lowering = false;
        }
        
        if (rising)
        {
            y_val = Vector3.up.y * yModifier;
        }

        if (lowering)
        {
            y_val = Vector3.down.y * yModifier;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        this.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        direction = new Vector3(x_axis, 0, z_axis);
        // print(direction);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 targetPos = transform.position + moveDir;
            // print("TargetPos" + targetPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        }

        // transform.Translate(
        //     new Vector3(transform.position.x + 0, transform.position.y + y_val, transform.position.z + 0) *
        //     Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, ,
        //     Time.deltaTime * ySpeed);
    }
}