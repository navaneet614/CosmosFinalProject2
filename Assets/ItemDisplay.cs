﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{

    private string[] names;
    public int counter;
    private int timeCounter;
    public int numItems = 4;
    public Texture inventory;
    public Texture wood;
    public Texture treeSap;
    public Texture fishingLine;
    public Texture matchBox;
    public Texture empty;
    public float imageSize = 50;
    public float offset = 10;
    private inspect script;


    // Use this for initialization
    void Start()
    {
        names = new string[4];
        counter = 0;
        timeCounter = 0;
        script = GameObject.Find("fireworksBoxAsset").GetComponent<inspect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 4)
        {
            script.itemsCollected = true;
        }
    }

    private void OnGUI()
    {
        if (timeCounter > 0)
        {
            float sWidth = Screen.currentResolution.width;
            float sHeight = Screen.currentResolution.height;
            float imageW = sWidth / 1920f * imageSize;
            float imageH = sHeight / 1080f * imageSize;
            GUIStyle style = new GUIStyle();
            GUI.DrawTexture(new Rect(0, 0, imageW * 2, imageH), inventory, ScaleMode.StretchToFill);
            //GUI.Label(new Rect(), "Inventory:", style);
            for (int index = 0; index < numItems; index++)
            {
                //GUILayout.Label(names[index]);
                Texture t = null;
                switch (names[index]) {
                    case "Tree Sap":
                        t = treeSap;
                        break;
                    case "Wood":
                        t = wood;
                        break;
                    case "Fishing Line":
                        t = fishingLine;
                        break;
                    case "Matchbox":
                        t = matchBox;
                        break;
                    default:
                        t = empty;
                        break;
                }

                GUI.DrawTexture(new Rect(index*imageW + offset*(index+1) + imageH*2,0,imageW,imageH), t, ScaleMode.StretchToFill);
            }
            timeCounter--;
        }
    }

    public void AddItem(string name)
    {
        names[counter++] = name;
        timeCounter = 500;
    }
}
