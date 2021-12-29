using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float RotSpeed = 100f;
    private bool dragging = false;
    Rigidbody _rb;
    private Transform CameraPos;
    public float offset;





    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        CameraPos = GameObject.Find("Camera").GetComponent<Transform>();
        CameraPos.rotation = Quaternion.Euler(35, 45, 0);
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(dragging == true)
        {
            float x = Input.GetAxis("Mouse X") * RotSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * RotSpeed * Time.fixedDeltaTime;

            _rb.AddTorque(Vector3.down * x);
            _rb.AddTorque(Vector3.right * y);
        }


        transform.position = CameraPos.position - new Vector3(-offset, offset, -offset);



    }
}
