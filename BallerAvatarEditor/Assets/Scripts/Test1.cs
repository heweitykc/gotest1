using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var obj = new GameObject("TestActive");
        obj.hideFlags = HideFlags.HideInHierarchy;
        gameObject.SetActive(true);
        RunCoroutine(test1());
	}

    void RunCoroutine(IEnumerator func)
    {
        if (!gameObject.activeInHierarchy)
            return;
        StartCoroutine(func);
    }

    IEnumerator test1()
    {
        yield return null;
        print("test123");
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
