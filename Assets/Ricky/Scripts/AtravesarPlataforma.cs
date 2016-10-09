using UnityEngine;
using System.Collections;

public class AtravesarPlataforma : MonoBehaviour {

    CapsuleCollider[] cColliders;
	// Use this for initialization
	void Start () {
        cColliders = transform.parent.GetComponents<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Platform")
        {
            foreach(CapsuleCollider collider in cColliders)
            Physics.IgnoreCollision(collider, col.transform.GetComponent<BoxCollider>(), true);

            Physics.IgnoreCollision(transform.parent.GetComponent<SphereCollider>(), col.transform.GetComponent<BoxCollider>(),true);
        }
    }


}
