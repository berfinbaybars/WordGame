using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDictionary : MonoBehaviour
{
    public static Dictionary<int, Text> TextObjs = new Dictionary<int, Text>();
    [SerializeField] Text Text1;
    [SerializeField] Text Text2;
    [SerializeField] Text Text3;
    [SerializeField] Text Text4;
    [SerializeField] Text Text5;
    [SerializeField] Text Text6;
    [SerializeField] Text Text7;
    [SerializeField] Text Text8;
    [SerializeField] Text Text9;
    [SerializeField] Text Text10;
    [SerializeField] Text Text11;
    [SerializeField] Text Text12;
    [SerializeField] Text Text13;
    [SerializeField] Text Text14;
    [SerializeField] Text Text15;
    [SerializeField] Text Text16;
    [SerializeField] Text Text17;
    [SerializeField] Text Text18;
    [SerializeField] Text Text19;
    [SerializeField] Text Text20;
    [SerializeField] Text Text21;
    [SerializeField] Text Text22;
    [SerializeField] Text Text23;
    [SerializeField] Text Text24;
    [SerializeField] Text Text25;
    [SerializeField] Text Text26;
    [SerializeField] Text Text27;
    [SerializeField] Text Text28;
    [SerializeField] Text Text29;
    [SerializeField] Text Text30;

    void Start()
    {
        if (TextObjs.Count == 0)
        {
            TextObjs.Add(1, Text1);
            TextObjs.Add(2, Text2);
            TextObjs.Add(3, Text3);
            TextObjs.Add(4, Text4);
            TextObjs.Add(5, Text5);
            TextObjs.Add(6, Text6);
            TextObjs.Add(7, Text7);
            TextObjs.Add(8, Text8);
            TextObjs.Add(9, Text9);
            TextObjs.Add(10, Text10);
            TextObjs.Add(11, Text11);
            TextObjs.Add(12, Text12);
            TextObjs.Add(13, Text13);
            TextObjs.Add(14, Text14);
            TextObjs.Add(15, Text15);
            TextObjs.Add(16, Text16);
            TextObjs.Add(17, Text17);
            TextObjs.Add(18, Text18);
            TextObjs.Add(19, Text19);
            TextObjs.Add(20, Text20);
            TextObjs.Add(21, Text21);
            TextObjs.Add(22, Text22);
            TextObjs.Add(23, Text23);
            TextObjs.Add(24, Text24);
            TextObjs.Add(25, Text25);
            TextObjs.Add(26, Text26);
            TextObjs.Add(27, Text27);
            TextObjs.Add(28, Text28);
            TextObjs.Add(29, Text29);
            TextObjs.Add(30, Text30);
        }
    }
}
