using UnityEngine;
using System.Collections;

public class TestBone : MonoBehaviour {
    public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnAnimatorMove()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
