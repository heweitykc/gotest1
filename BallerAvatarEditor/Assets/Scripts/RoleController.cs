using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class RoleController : MonoBehaviour {
    public Text txtmsg;
    bool uselocal = false;
    Text switchBtn;

	void Start () {
        SwitchControl();
    }

    public void SwitchControl()
    {
        uselocal = !uselocal;
        txtmsg.text = "切换->" + ( uselocal ? "网络" : "本地");
    }
		
	void Update () {

        string axis;
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        axis = h.ToString() + "," + v.ToString();
        if (uselocal)
        {
            UpdateControl(axis);
        }
        else
        {
            GetComponent<clienttest>().SendPing(axis);
        }
    }

    public void UpdateControl(string axis)
    {
        string[] arr = axis.Split(',');

        transform.position += new Vector3(float.Parse(arr[0]), 0, 0) * 0.1f;
        transform.position += new Vector3(0f, float.Parse(arr[1]), 0) * 0.1f;
    }
}
