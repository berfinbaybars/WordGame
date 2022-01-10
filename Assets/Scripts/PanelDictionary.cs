using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDictionary : MonoBehaviour
{
    public static Dictionary<int, GameObject> PanelObjs = new Dictionary<int, GameObject>();
    [SerializeField] GameObject Image1;
    [SerializeField] GameObject Image2;
    [SerializeField] GameObject Image3;
    [SerializeField] GameObject Image4;
    [SerializeField] GameObject Image5;
    [SerializeField] GameObject Image6;
    [SerializeField] GameObject Image7;
    [SerializeField] GameObject Image8;
    [SerializeField] GameObject Image9;
    [SerializeField] GameObject Image10;
    [SerializeField] GameObject Image11;
    [SerializeField] GameObject Image12;
    [SerializeField] GameObject Image13;
    [SerializeField] GameObject Image14;
    [SerializeField] GameObject Image15;
    [SerializeField] GameObject Image16;
    [SerializeField] GameObject Image17;
    [SerializeField] GameObject Image18;
    [SerializeField] GameObject Image19;
    [SerializeField] GameObject Image20;
    [SerializeField] GameObject Image21;
    [SerializeField] GameObject Image22;
    [SerializeField] GameObject Image23;
    [SerializeField] GameObject Image24;
    [SerializeField] GameObject Image25;
    [SerializeField] GameObject Image26;
    [SerializeField] GameObject Image27;
    [SerializeField] GameObject Image28;
    [SerializeField] GameObject Image29;
    [SerializeField] GameObject Image30;

    void Start()
    {
        if (PanelObjs.Count == 0)
        {
            PanelObjs.Add(1, Image1);
            PanelObjs.Add(2, Image2);
            PanelObjs.Add(3, Image3);
            PanelObjs.Add(4, Image4);
            PanelObjs.Add(5, Image5);
            PanelObjs.Add(6, Image6);
            PanelObjs.Add(7, Image7);
            PanelObjs.Add(8, Image8);
            PanelObjs.Add(9, Image9);
            PanelObjs.Add(10, Image10);
            PanelObjs.Add(11, Image11);
            PanelObjs.Add(12, Image12);
            PanelObjs.Add(13, Image13);
            PanelObjs.Add(14, Image14);
            PanelObjs.Add(15, Image15);
            PanelObjs.Add(16, Image16);
            PanelObjs.Add(17, Image17);
            PanelObjs.Add(18, Image18);
            PanelObjs.Add(19, Image19);
            PanelObjs.Add(20, Image20);
            PanelObjs.Add(21, Image21);
            PanelObjs.Add(22, Image22);
            PanelObjs.Add(23, Image23);
            PanelObjs.Add(24, Image24);
            PanelObjs.Add(25, Image25);
            PanelObjs.Add(26, Image26);
            PanelObjs.Add(27, Image27);
            PanelObjs.Add(28, Image28);
            PanelObjs.Add(29, Image29);
            PanelObjs.Add(30, Image30);
        }
    }
}
