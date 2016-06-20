using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UMA;

public class AvatarTest : MonoBehaviour
{

    UMAGenerator generator;
    GameObject UMAKit;
    RuntimeAnimatorController animController;
    GameObject playerContainer;

    Dropdown race;
    Dropdown body;
    Dropdown hand;
    Dropdown head;
    Dropdown leg;
    Dropdown foot;
    Dropdown hair;
    
    string[] bodies = new string[] { "malebody" };    
    string[] heads = new string[] { "malehead" };
    string[] hands = new string[] { "malehand" };
    string[] legs = new string[] { "maleleg" };

    string[] yies = new string[] { "tixuebody" };
    string[] hairs = new string[] { "tixuehead" };    
    string[] kus = new string[] { "tixueku" };            
    string[] foots = new string[] { "tixuexie", "malefoot" };

    void Start()
    {
        if (UMAKit == null)
        {
            UMAKit = GameObject.Instantiate(Resources.Load("Avatar/UMAKit")) as GameObject;
            GameObject.DontDestroyOnLoad(UMAKit);
            generator = UMAKit.transform.FindChild("UMAGenerator").gameObject.GetComponent<UMAGenerator>();
            animController = Resources.Load("Baller") as RuntimeAnimatorController;
            playerContainer = new GameObject("playercontainer");
        }

        race = GameObject.Find("AvatarChooser").transform.Find("Race").GetComponent<Dropdown>();
        body = GameObject.Find("AvatarChooser").transform.Find("Body").GetComponent<Dropdown>();
        head = GameObject.Find("AvatarChooser").transform.Find("Head").GetComponent<Dropdown>();
        leg = GameObject.Find("AvatarChooser").transform.Find("Leg").GetComponent<Dropdown>();
        foot = GameObject.Find("AvatarChooser").transform.Find("Foot").GetComponent<Dropdown>();
        hand = GameObject.Find("AvatarChooser").transform.Find("Hand").GetComponent<Dropdown>();
        hair = GameObject.Find("AvatarChooser").transform.Find("Hair").GetComponent<Dropdown>();

        initDropDown(body, bodies);
        initDropDown(hand, hands);
        initDropDown(head, heads);
        initDropDown(leg, legs);
        initDropDown(foot, foots);
        initDropDown(hair, hairs);
    }

    void initDropDown(Dropdown drop, string[] datalist)
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 0; i < datalist.Length; i++)
        {
            options.Add(new Dropdown.OptionData(datalist[i]));
        }
        drop.AddOptions(options);
    }

    GameObject playerGO;
    public void CreatePlayer(int playerId)
    {
        if (playerGO != null)
        {
            GameObject.DestroyImmediate(playerGO);
        }
        playerGO = new GameObject(playerId.ToString());
        GameObject container = playerContainer;
        playerGO.transform.parent = container.transform;
        playerGO.transform.localPosition = Vector3.zero;
        playerGO.transform.localRotation = Quaternion.identity;

        var umaDynamicAvatar = playerGO.AddComponent<UMADynamicAvatar>();
        umaDynamicAvatar.Initialize();
        var umaData = umaDynamicAvatar.umaData;

        umaDynamicAvatar.CharacterCreated = new UMA.UMADataEvent();
        umaDynamicAvatar.CharacterCreated.AddListener(OnAvatarCreated);

        umaData.umaRecipe = new UMAData.UMARecipe();
        umaData.umaRecipe.slotDataList = new SlotData[8];

        umaDynamicAvatar.umaGenerator = generator;
        umaData.umaGenerator = generator;

        RaceData race0 = Resources.Load("Avatar/Races/male") as RaceData;

        string bodystr = bodies[body.value];
        var bodyasset = Resources.Load("Avatar/Slots/" + bodystr + "/" + bodystr + "_Slot") as SlotDataAsset;
        SlotData body0 = new SlotData(bodyasset);

        string handstr = hands[hand.value];
        var handasset = Resources.Load("Avatar/Slots/" + handstr + "/" + handstr + "_Slot") as SlotDataAsset;
        SlotData hand0 = new SlotData(handasset);

        string headstr = heads[head.value];
        var headasset = Resources.Load("Avatar/Slots/" + headstr + "/" + headstr + "_Slot") as SlotDataAsset;
        SlotData head0 = new SlotData(headasset);

        string legstr = legs[leg.value];
        var legasset = Resources.Load("Avatar/Slots/" + legstr + "/" + legstr + "_Slot") as SlotDataAsset;
        SlotData leg0 = new SlotData(legasset);


        string hairstr = hairs[hair.value];
        var hairasset = Resources.Load("Avatar/Slots/" + hairstr + "/" + hairstr + "_Slot") as SlotDataAsset;
        SlotData hair0 = new SlotData(hairasset);

        string footstr = foots[foot.value];
        var footasset = Resources.Load("Avatar/Slots/" + footstr + "/" + footstr + "_Slot") as SlotDataAsset;
        SlotData foot0 = new SlotData(footasset);

        string kustr = kus[0];
        var kuasset = Resources.Load("Avatar/Slots/" + kustr + "/" + kustr + "_Slot") as SlotDataAsset;
        SlotData ku0 = new SlotData(kuasset);

        string yistr = yies[0];
        var yiasset = Resources.Load("Avatar/Slots/" + yistr + "/" + yistr + "_Slot") as SlotDataAsset;
        SlotData yi0 = new SlotData(yiasset);

        var bodyt = new OverlayData(Resources.Load("Avatar/Overlays/malebody") as OverlayDataAsset);
        var headt = new OverlayData(Resources.Load("Avatar/Overlays/malehead") as OverlayDataAsset);

        var ku = new OverlayData(Resources.Load("Avatar/Overlays/tixueku") as OverlayDataAsset);
        var toufa = new OverlayData(Resources.Load("Avatar/Overlays/tixuetoufa") as OverlayDataAsset);
        var xie = new OverlayData(Resources.Load("Avatar/Overlays/tixuexie") as OverlayDataAsset);
        var yi = new OverlayData(Resources.Load("Avatar/Overlays/tixueyi") as OverlayDataAsset);

       // head0.AddOverlay(headt);
       // body0.AddOverlay(bodyt);
       // hand0.AddOverlay(bodyt);
        //leg0.AddOverlay(bodyt);

        yi0.AddOverlay(yi);
        foot0.AddOverlay(xie);                        
        hair0.AddOverlay(toufa);
        //ku0.AddOverlay(ku);
        ku0.AddOverlay(bodyt);

        var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
        umaRecipe.SetRace(race0);
        //umaRecipe.slotDataList[0] = body0;        
        //umaRecipe.slotDataList[1] = hand0;
        //umaRecipe.slotDataList[2] = head0;
       // umaRecipe.slotDataList[3] = leg0;

        umaRecipe.slotDataList[4] = foot0;
        umaRecipe.slotDataList[5] = hair0;
        umaRecipe.slotDataList[6] = yi0;
        umaRecipe.slotDataList[7] = ku0;

        umaDynamicAvatar.animationController = animController;
        umaDynamicAvatar.UpdateNewRace();
    }

    void OnAvatarCreated(UMAData data)
    {
        if (race.value == 1)
            RaceBoneData.InitBigMale(data.skeleton);
        else if (race.value == 2)
            RaceBoneData.InitMiniMale(data.skeleton);
        else
            RaceBoneData.InitMale(data.skeleton);

        //playerGO.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().sharedMesh.Optimize();
    }        
}
