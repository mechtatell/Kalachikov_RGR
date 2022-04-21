using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public Camera cam;

    public float speed = 1, sensivity = 1;

    private Rigidbody rig;

    public TextMeshProUGUI text;

    private bool win = false;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensivity, 0);
        cam.transform.Rotate(-Input.GetAxis("Mouse Y") * sensivity, 0, 0);

        if(win && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rig.velocity = transform.TransformDirection(vec * speed * 2);
        }
        else
        {
            rig.velocity = transform.TransformDirection(vec * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "chest")
        {
            text.gameObject.SetActive(true);
            win = true;
        }
    }
}
