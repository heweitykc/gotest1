using UnityEngine;
using System.Collections;

public class ExportBoneData : MonoBehaviour {

   static public string[] bones = 
        {
            "Position",
            "Bip001 Spine1 Adjust",
            "Bip001 Spine Adjust",
            "Bip001 L Calf Adjust",
            "Bip001 R Calf Adjust",
            "Bip001 L Thigh Adjust",
            "Bip001 R Thigh Adjust",
            "Bip001 L Clavicle Adjust",
            "Bip001 R Clavicle Adjust",
            "Bip001 L Forearm Adjust",
            "Bip001 R Forearm Adjust",
            "Bip001 L UpperArm Adjust",
            "Bip001 R UpperArm Adjust"
        };

    static public string[] boneHashs =
        {
            "PositionAdjustHash",
            "spine1AdjustHash",
            "spineAdjustHash",
            "LCalfAdjustHash",
            "RCalfAdjustHash",
            "LThighAdjustHash",
            "RThighAdjustHash",
            "LClavicleAdjustHash",
            "RClavicleAdjustHash",
            "LForearmAdjustHash",
            "RForearmAdjustHash",
            "LUpperArmAdjustHash",
            "RUpperArmAdjustHash"
        };

    string lineTemplate =
@"skeleton.SetScale({hash}, new Vector3({0}f, {1}f, {2}f));
skeleton.SetPosition({hash}, new Vector3({3}f, {4}f, {5}f));
";

    void Start () {
        Debug.Log(gameObject.name);
        string s = "";
        for(int i=0;i< bones.Length;i++)        
        {
            var bone = bones[i];
            Transform t = GameObject.Find(bone).transform;
            string line = lineTemplate
                .Replace("{hash}", boneHashs[i])
                .Replace("{0}", t.localScale.x.ToString("f3"))
                .Replace("{1}", t.localScale.y.ToString("f3"))
                .Replace("{2}", t.localScale.z.ToString("f3"))
                .Replace("{3}", t.localPosition.x.ToString("f3"))
                .Replace("{4}", t.localPosition.y.ToString("f3"))
                .Replace("{5}", t.localPosition.z.ToString("f3"));

            s += line;
        }
        Debug.Log(s);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
