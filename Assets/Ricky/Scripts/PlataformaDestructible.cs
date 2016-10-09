using UnityEngine;
using System.Collections;

public class PlataformaDestructible : MonoBehaviour {

    int life;
	// Use this for initialization
	void Start () {
        life = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(life <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hola");

            life -= 1;       
        }
    }
}
