using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardDictionary : MonoBehaviour
{
    public static Dictionary<char, Button> KeyboardObjs = new Dictionary<char, Button>();
    [SerializeField] Button Button1;
    [SerializeField] Button Button2;
    [SerializeField] Button Button3;
    [SerializeField] Button Button4;
    [SerializeField] Button Button5;
    [SerializeField] Button Button6;
    [SerializeField] Button Button7;
    [SerializeField] Button Button8;
    [SerializeField] Button Button9;
    [SerializeField] Button Button10;
    [SerializeField] Button Button11;
    [SerializeField] Button Button12;
    [SerializeField] Button Button13;
    [SerializeField] Button Button14;
    [SerializeField] Button Button15;
    [SerializeField] Button Button16;
    [SerializeField] Button Button17;
    [SerializeField] Button Button18;
    [SerializeField] Button Button19;
    [SerializeField] Button Button20;
    [SerializeField] Button Button21;
    [SerializeField] Button Button22;
    [SerializeField] Button Button23;
    [SerializeField] Button Button24;
    [SerializeField] Button Button25;
    [SerializeField] Button Button26;
    [SerializeField] Button Button27;
    [SerializeField] Button Button28;
    [SerializeField] Button Button29;
    [SerializeField] Button Button30;
    [SerializeField] Button Button31;
    [SerializeField] Button Button32;

    bool isReady = false;
    void Start()
    {
        if (KeyboardObjs.Count == 0)
        {
            KeyboardObjs.Add('Q', Button1);
            KeyboardObjs.Add('W', Button2);
            KeyboardObjs.Add('E', Button3);
            KeyboardObjs.Add('R', Button4);
            KeyboardObjs.Add('T', Button5);
            KeyboardObjs.Add('Y', Button6);
            KeyboardObjs.Add('U', Button7);
            KeyboardObjs.Add('I', Button8);
            KeyboardObjs.Add('O', Button9);
            KeyboardObjs.Add('P', Button10);
            KeyboardObjs.Add('Ğ', Button11);
            KeyboardObjs.Add('Ü', Button12);
            KeyboardObjs.Add('A', Button13);
            KeyboardObjs.Add('S', Button14);
            KeyboardObjs.Add('D', Button15);
            KeyboardObjs.Add('F', Button16);
            KeyboardObjs.Add('G', Button17);
            KeyboardObjs.Add('H', Button18);
            KeyboardObjs.Add('J', Button19);
            KeyboardObjs.Add('K', Button20);
            KeyboardObjs.Add('L', Button21);
            KeyboardObjs.Add('Ş', Button22);
            KeyboardObjs.Add('İ', Button23);
            KeyboardObjs.Add('Z', Button24);
            KeyboardObjs.Add('X', Button25);
            KeyboardObjs.Add('C', Button26);
            KeyboardObjs.Add('V', Button27);
            KeyboardObjs.Add('B', Button28);
            KeyboardObjs.Add('N', Button29);
            KeyboardObjs.Add('M', Button30);
            KeyboardObjs.Add('Ö', Button31);
            KeyboardObjs.Add('Ç', Button32);
        }
        isReady = true;
    }

    private void Update()
    {
        if (isReady)
        {
            AddEvents();
            isReady = false;
        }
    }
    void AddEvents()
    {
        List<char> keyList = new List<char>(KeyboardObjs.Keys);
        for (int i = 0; i < keyList.Count; i++)
        {
            char ch = keyList[i];
            Button keyboard = KeyboardObjs[ch];
            keyboard.onClick.AddListener(() => Game.AddChar(ch));
        }
    }
}
