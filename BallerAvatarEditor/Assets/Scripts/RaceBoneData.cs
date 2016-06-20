using UnityEngine;
using System.Collections;
using UMA;

public class RaceBoneData {
    static protected int spine1AdjustHash = 0;
    static protected int spineAdjustHash;

    static protected int LCalfAdjustHash;
    static protected int RCalfAdjustHash;

    static protected int LThighAdjustHash;
    static protected int RThighAdjustHash;

    static protected int LClavicleAdjustHash;
    static protected int RClavicleAdjustHash;

    static protected int LForearmAdjustHash;
    static protected int RForearmAdjustHash;

    static protected int LUpperArmAdjustHash;
    static protected int RUpperArmAdjustHash;

    static protected int PositionAdjustHash;

    static RaceBoneData()
    {
        InitHash();
    }

    static void InitHash()
    {
        PositionAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[0]);

        spineAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[2]);
        spine1AdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[1]);        

        LCalfAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[3]);
        RCalfAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[4]);
        LThighAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[5]);
        RThighAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[6]);
        LClavicleAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[7]);
        RClavicleAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[8]);
        LForearmAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[9]);
        RForearmAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[10]);
        LUpperArmAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[11]);
        RUpperArmAdjustHash = UMAUtils.StringToHash(ExportBoneData.bones[12]);
    }

    static public void InitMale(UMASkeleton skeleton)
    {
        skeleton.SetScale(PositionAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(PositionAdjustHash, new Vector3(-0.841f, 0.000f, 0.016f));
        skeleton.SetScale(spine1AdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(spine1AdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(spineAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(spineAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LCalfAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(LCalfAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(RCalfAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(RCalfAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LThighAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(LThighAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(RThighAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(RThighAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LClavicleAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(LClavicleAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(RClavicleAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(RClavicleAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LForearmAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(LForearmAdjustHash, new Vector3(0.022f, 0.000f, 0.000f));
        skeleton.SetScale(RForearmAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(RForearmAdjustHash, new Vector3(0.022f, 0.000f, 0.000f));
        skeleton.SetScale(LUpperArmAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(LUpperArmAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(RUpperArmAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(RUpperArmAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));

    }

    static public void InitBigMale(UMASkeleton skeleton)
    {
        skeleton.SetScale(PositionAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(PositionAdjustHash, new Vector3(-0.935f, 0.000f, 0.016f));
        skeleton.SetScale(spine1AdjustHash, new Vector3(1.000f, 1.228f, 1.280f));
        skeleton.SetPosition(spine1AdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(spineAdjustHash, new Vector3(1.000f, 1.164f, 1.211f));
        skeleton.SetPosition(spineAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LCalfAdjustHash, new Vector3(1.000f, 1.040f, 1.300f));
        skeleton.SetPosition(LCalfAdjustHash, new Vector3(0.000f, 0.004f, 0.000f));
        skeleton.SetScale(RCalfAdjustHash, new Vector3(1.000f, 1.040f, 1.300f));
        skeleton.SetPosition(RCalfAdjustHash, new Vector3(0.000f, 0.004f, 0.000f));
        skeleton.SetScale(LThighAdjustHash, new Vector3(1.000f, 1.070f, 1.150f));
        skeleton.SetPosition(LThighAdjustHash, new Vector3(0.000f, 0.004f, -0.006f));
        skeleton.SetScale(RThighAdjustHash, new Vector3(1.000f, 1.070f, 1.150f));
        skeleton.SetPosition(RThighAdjustHash, new Vector3(0.000f, 0.004f, 0.006f));
        skeleton.SetScale(LClavicleAdjustHash, new Vector3(1.170f, 1.350f, 1.170f));
        skeleton.SetPosition(LClavicleAdjustHash, new Vector3(-0.054f, -0.013f, 0.014f));
        skeleton.SetScale(RClavicleAdjustHash, new Vector3(1.170f, 1.350f, 1.170f));
        skeleton.SetPosition(RClavicleAdjustHash, new Vector3(-0.054f, -0.013f, -0.014f));
        skeleton.SetScale(LForearmAdjustHash, new Vector3(1.000f, 1.100f, 1.110f));
        skeleton.SetPosition(LForearmAdjustHash, new Vector3(0.010f, 0.005f, 0.026f));
        skeleton.SetScale(RForearmAdjustHash, new Vector3(1.000f, 1.100f, 1.110f));
        skeleton.SetPosition(RForearmAdjustHash, new Vector3(0.010f, 0.005f, -0.026f));
        skeleton.SetScale(LUpperArmAdjustHash, new Vector3(1.000f, 1.080f, 1.230f));
        skeleton.SetPosition(LUpperArmAdjustHash, new Vector3(-0.021f, 0.008f, 0.027f));
        skeleton.SetScale(RUpperArmAdjustHash, new Vector3(1.000f, 1.080f, 1.230f));
        skeleton.SetPosition(RUpperArmAdjustHash, new Vector3(-0.021f, 0.008f, -0.027f));
    }

    static public void InitMiniMale(UMASkeleton skeleton)
    {
        skeleton.SetScale(PositionAdjustHash, new Vector3(1.000f, 1.000f, 1.000f));
        skeleton.SetPosition(PositionAdjustHash, new Vector3(-0.747f, 0.000f, 0.016f));
        skeleton.SetScale(spine1AdjustHash, new Vector3(1.000f, 0.914f, 0.815f));
        skeleton.SetPosition(spine1AdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(spineAdjustHash, new Vector3(1.000f, 0.933f, 0.891f));
        skeleton.SetPosition(spineAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LCalfAdjustHash, new Vector3(1.000f, 0.970f, 0.830f));
        skeleton.SetPosition(LCalfAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(RCalfAdjustHash, new Vector3(1.000f, 0.970f, 0.830f));
        skeleton.SetPosition(RCalfAdjustHash, new Vector3(0.000f, 0.000f, 0.000f));
        skeleton.SetScale(LThighAdjustHash, new Vector3(1.000f, 0.930f, 0.840f));
        skeleton.SetPosition(LThighAdjustHash, new Vector3(0.000f, 0.000f, 0.007f));
        skeleton.SetScale(RThighAdjustHash, new Vector3(1.000f, 0.930f, 0.840f));
        skeleton.SetPosition(RThighAdjustHash, new Vector3(0.001f, 0.000f, -0.007f));
        skeleton.SetScale(LClavicleAdjustHash, new Vector3(0.870f, 1.050f, 0.940f));
        skeleton.SetPosition(LClavicleAdjustHash, new Vector3(0.028f, 0.006f, -0.005f));
        skeleton.SetScale(RClavicleAdjustHash, new Vector3(0.870f, 1.050f, 0.940f));
        skeleton.SetPosition(RClavicleAdjustHash, new Vector3(0.028f, 0.006f, 0.005f));
        skeleton.SetScale(LForearmAdjustHash, new Vector3(0.980f, 0.730f, 0.760f));
        skeleton.SetPosition(LForearmAdjustHash, new Vector3(0.022f, 0.000f, -0.015f));
        skeleton.SetScale(RForearmAdjustHash, new Vector3(0.980f, 0.730f, 0.760f));
        skeleton.SetPosition(RForearmAdjustHash, new Vector3(0.022f, 0.000f, 0.015f));
        skeleton.SetScale(LUpperArmAdjustHash, new Vector3(1.000f, 0.830f, 0.780f));
        skeleton.SetPosition(LUpperArmAdjustHash, new Vector3(0.005f, -0.003f, -0.019f));
        skeleton.SetScale(RUpperArmAdjustHash, new Vector3(1.000f, 0.830f, 0.780f));
        skeleton.SetPosition(RUpperArmAdjustHash, new Vector3(0.005f, -0.003f, 0.019f));
    }
}
