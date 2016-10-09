using UnityEngine;
using System.Collections;

public class PlataformaMovil : MonoBehaviour {

    public float moveSpeed = 10;

    bool goRight;
	// Use this for initialization
	void Start () {
        goRight = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (goRight == true)
            GetComponent<Rigidbody>().AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.Impulse);
           // transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        else
            GetComponent<Rigidbody>().AddForce(new Vector3(-moveSpeed, 0, 0), ForceMode.Impulse);

        // transform.Translate(Vector3.right * Time.deltaTime * -moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "InvisibleWall")
        {
            goRight = !goRight;
        }
    }
}
