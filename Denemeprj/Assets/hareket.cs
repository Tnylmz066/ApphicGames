using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public Transform Silah_govde, Silah_namlu, mermi,nokta;
    Transform klon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Silah_govde.Rotate(0, Input.GetAxis("Horizontal"), 0);
        Silah_namlu.Rotate(Input.GetAxis("Vertical"), 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            klon= Instantiate(mermi, nokta.position, Silah_namlu.rotation);
            klon.GetComponent<Rigidbody>().AddForce(klon.forward * 500);
        }

    }
}
