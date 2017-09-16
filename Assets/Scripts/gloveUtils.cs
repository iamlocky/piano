using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FDTGloveUltraCSharpWrapper;

public class gloveUtils : MonoBehaviour {
    public static CfdGlove glove;
    private static int timer = 0;
    private static string gloveInfomation;



    // Use this for initialization
    void Start () {
		glove = new CfdGlove();
        try
        {
            glove.Open("USB0");
            print("连接到驱动");
            print(getGloveType());

        }
        catch
        {
            print("连接失败");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}




    public string getGloveType()
    {
        int type = 0;
        string gloveType;
        type=glove.GetGloveType();
        switch (type)
        {
            case (int)EGloveTypes.FD_GLOVE14UW: gloveType = "Data Glove 14 Ultra Wireless"; break;
            case (int)EGloveTypes.FD_GLOVE14U_USB: gloveType = "Data Glove 14 Ultra USB"; break;
            case (int)EGloveTypes.FD_GLOVE14U: gloveType = "Data Glove 14 Ultra"; break;
            case (int)EGloveTypes.FD_GLOVE16: gloveType = "Data Glove 16-sensor"; break;
            case (int)EGloveTypes.FD_GLOVE16W: gloveType = "Data Glove 16-sensor Wireless"; break;
            case (int)EGloveTypes.FD_GLOVE5U: gloveType = "Data Glove 5 Ultra"; break;
            case (int)EGloveTypes.FD_GLOVE5U_USB: gloveType = "Data Glove 5 Ultra USB"; break;
            case (int)EGloveTypes.FD_GLOVE5UW: gloveType = "Data Glove 5 Ultra Wireless"; break;
            case (int)EGloveTypes.FD_GLOVE7: gloveType = "Data Glove 7-sensor"; break;
            case (int)EGloveTypes.FD_GLOVE7W: gloveType = "Data Glove 7-sensor Wireless"; break;
            case (int)EGloveTypes.FD_GLOVENONE: gloveType = "No Glove"; break;
            default: gloveType = "Unknown"; break;
        }
        return gloveType;
    }

    public string getHand()
    {
        int hand = 0;
        string whichHand;
        hand =glove.GetGloveHand();
        switch (hand)
        {
            case (int)EGloveHand.FD_HAND_RIGHT: whichHand = "RIGHT"; break;
            case (int)EGloveHand.FD_HAND_LEFT: whichHand = "LEFT"; break;
            default: whichHand = "Unknown"; break;
        }
        return whichHand;
    }

    public static float[] getGloveData()
    {
        float[] data = new float[5];
        switch (glove.GetGloveHand())
        {
            case 0:
                {
                    data[0] = glove.GetSensorScaled(1);
                    data[1] = glove.GetSensorScaled(4);
                    data[2] = glove.GetSensorScaled(7);
                    data[3] = glove.GetSensorScaled(10);
                    data[4] = glove.GetSensorScaled(13);
                    break;
                }
            case 1:
                {
                    data[0] = glove.GetSensorScaled(1);
                    data[1] = glove.GetSensorScaled(4);
                    data[2] = glove.GetSensorScaled(7);
                    data[3] = glove.GetSensorScaled(10);
                    data[4] = glove.GetSensorScaled(13);
                    break;
                }
        }
        return data;
    }
}
