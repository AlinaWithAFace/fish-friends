using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Camera _camera;
    public GameObject target;
    public Vector3 cameraOffset;
    public float positionSpeed = .02f;
    public float rotationSpeed = .01f;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, target.transform.position, positionSpeed);
        // transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, rotationSpeed);
        _camera.transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, positionSpeed);
        // _camera.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, rotationSpeed);
        // _camera.transform.position = target.transform.position + cameraOffset;
    }
}
