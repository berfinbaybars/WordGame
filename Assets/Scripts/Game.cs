using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    static int count = 0;
    static int currentRow = 1;
    static bool addChar = true;
    static bool playable = true;
    [SerializeField] TextAsset textAsset;
    List<string> WordList;
    string answer;
    int score = 0;
    [SerializeField] Text ScoreText;
    [SerializeField] Text ErrorText;
    [SerializeField] Text AnswerText;
    [SerializeField] Button NextButton;
    [SerializeField] Button RestartButton;
    [SerializeField] Button EnterButton;
    [SerializeField] Button DeleteButton;
    [SerializeField] GameObject GameOver;

    void Start()
    {
        GameOver.SetActive(false);
        ErrorText.gameObject.SetActive(false);
        var fileContent = textAsset.text;
        var words = fileContent.Split('\n');
        WordList = new List<string>(words);
        NextButton.onClick.AddListener(NextWord);
        RestartButton.onClick.AddListener(RestartGame);
        EnterButton.onClick.AddListener(KeyboardEnter);
        DeleteButton.onClick.AddListener(KeyboardDelete);
        NextButton.gameObject.SetActive(false);
        ChooseWord();
        playable = true;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.anyKeyDown && playable)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                if (count > ((currentRow * 5) - 5) && count <= (currentRow * 5))
                {
                    TextDictionary.TextObjs[count].text = "";
                    count--;
                    ErrorText.gameObject.SetActive(false);
                }
                return;
            }
            else if (Input.GetKey(KeyCode.Return) && count == (currentRow * 5))
            {
                string enteredWord = "";
                int firstIndex = count - 4;
                for (int i = firstIndex; i <= count; i++)
                {
                    string temp = TextDictionary.TextObjs[i].text;
                    if (temp == "I")
                    {
                        temp = "ı";
                    }
                    else
                    {
                        temp = temp.ToLower();
                    }
                    enteredWord += temp;
                }

                bool exist = false;
                WordList.ForEach(word =>
                {
                    if (word.Contains(enteredWord))
                    {
                        exist = true;
                    }
                });

                if (!exist)
                {
                    ErrorText.gameObject.SetActive(true);
                    return;
                }

                char[] charArray = enteredWord.ToCharArray();

                for (int k = 0; k < charArray.Length; k++)
                {
                    char ch = charArray[k];

                    CheckChar(ch, k, (firstIndex + k), enteredWord);

                }

                if (answer.Equals(enteredWord))
                {
                    Win();
                }
                else if (currentRow < 6)
                {
                    currentRow++;
                }
                else
                {
                    SetAnswerText(answer);
                    playable = false;
                    GameOver.SetActive(true);
                }
            }

            if (count > 0 && count % 5 == 0 && count == currentRow * 5)
            {
                addChar = false;
            }
            else
            {
                addChar = true;
            }

            if (addChar && count < 30)
            {
                string str = Input.inputString;
                if (str == "") return;
                char input = str[str.Length - 1];
                if (char.IsLetter(input))
                {
                    count++;
                    if (input == 'i')
                    {
                        input = 'İ';
                        TextDictionary.TextObjs[count].text = input.ToString();
                        return;
                    }
                    TextDictionary.TextObjs[count].text = input.ToString().ToUpper();
                }
            }
        }
    }

    public static void AddChar(char ch)
    {
        if (count > 0 && count % 5 == 0 && count == currentRow * 5)
        {
            addChar = false;
        }
        else
        {
            addChar = true;
        }

        if (addChar && count < 30)
        {
            count++;
            TextDictionary.TextObjs[count].text = ch.ToString();
        }
    }

    void KeyboardDelete()
    {
        if (count > ((currentRow * 5) - 5) && count <= (currentRow * 5))
        {
            TextDictionary.TextObjs[count].text = "";
            count--;
            ErrorText.gameObject.SetActive(false);
        }
    }

    void KeyboardEnter()
    {
        if(count != (currentRow * 5))
        {
            return;
        }
        string enteredWord = "";
        int firstIndex = count - 4;
        for (int i = firstIndex; i <= count; i++)
        {
            string temp = TextDictionary.TextObjs[i].text;
            if (temp == "I")
            {
                temp = "ı";
            }
            else
            {
                temp = temp.ToLower();
            }
            enteredWord += temp;
        }

        bool exist = false;
        WordList.ForEach(word =>
        {
            if (word.Contains(enteredWord))
            {
                exist = true;
            }
        });

        if (!exist)
        {
            ErrorText.gameObject.SetActive(true);
            return;
        }

        char[] charArray = enteredWord.ToCharArray();

        for (int k = 0; k < charArray.Length; k++)
        {
            char ch = charArray[k];

            CheckChar(ch, k, (firstIndex + k), enteredWord);

        }

        if (answer.Equals(enteredWord))
        {
            Win();
        }
        else if (currentRow < 6)
        {
            currentRow++;
        }
        else
        {
            SetAnswerText(answer);
            playable = false;
            GameOver.SetActive(true);
        }
    }


    void ChooseWord()
    {
        int chosenId = Random.Range(0, WordList.Count - 1);
        answer = WordList[chosenId].Remove(5);
    }

    void CheckChar(char ch, int checkIndex, int panelIndex, string enteredWord)
    {
        char answerChar = answer.ToCharArray()[checkIndex];
        GameObject panel = PanelDictionary.PanelObjs[panelIndex];

        char getKeyboard;
        if(ch == 'i')
        {
            getKeyboard = 'İ';
        }
        else
        {
            getKeyboard = char.ToUpper(ch);
        }
        
        Button keyboard = KeyboardDictionary.KeyboardObjs[getKeyboard];
        Color color = keyboard.GetComponent<Image>().color;
        string colorName = CheckColor(color);
        
        if (answerChar == ch)
        {
            panel.GetComponent<Image>().color = new Color(0, 255, 0); // Green
            keyboard.GetComponent<Image>().color = new Color(0, 255, 0); // Green
        }
        else if (answer.Contains(ch.ToString()))
        {
            if (answer.IndexOf(ch) == answer.LastIndexOf(ch))
            {
                if (enteredWord.ToCharArray()[answer.IndexOf(ch)] == ch)
                {
                    panel.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
                    if(colorName != "yellow" && colorName != "green")
                    {
                        keyboard.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
                    }
                    return;
                }
                panel.GetComponent<Image>().color = new Color(255, 255, 0); // Yellow
                if (colorName != "green")
                {
                    keyboard.GetComponent<Image>().color = new Color(255, 255, 0); // Yellow
                }
            }
            else
            {
                if (ControlIndex(answer, enteredWord, ch))
                {
                    panel.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
                    if (colorName != "yellow" && colorName != "green")
                    {
                        keyboard.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
                    }
                }
                else
                {
                    panel.GetComponent<Image>().color = new Color(255, 255, 0); // Yellow
                    if (colorName != "green")
                    {
                        keyboard.GetComponent<Image>().color = new Color(255, 255, 0); // Yellow
                    }
                }
            }
        }
        else
        {
            panel.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
            if (colorName != "yellow" && colorName != "green")
            {
                keyboard.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f); // Gray
            }
        }
    }

    bool ControlIndex(string answer, string enteredWord, char ch)
    {
        int falseCount = 0;
        char[] answerArray = answer.ToCharArray();
        char[] enteredArray = enteredWord.ToCharArray();

        for (int i = 0; i < 5; i++)
        {
            if (answerArray[i] == ch)
            {
                if (enteredArray[i] != ch)
                {
                    falseCount++;
                }
            }
        }

        return falseCount == 0;
    }

    void NextWord()
    {
        NextButton.gameObject.SetActive(false);
        ResetTable();
        ResetKeyboard();
        count = 0;
        currentRow = 1;
        addChar = true;
        ChooseWord();
        playable = true;
    }

    void RestartGame()
    {
        ResetTable();
        ResetKeyboard();
        count = 0;
        currentRow = 1;
        score = 0;
        SetScoreText(score);
        addChar = true;
        playable = true;
        ErrorText.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);
        ChooseWord();
        GameOver.SetActive(false);
        Time.timeScale = 1;
    }

    void ResetTable()
    {
        for (int i = 1; i <= 30; i++)
        {
            TextDictionary.TextObjs[i].text = "";
            GameObject panel = PanelDictionary.PanelObjs[i];
            panel.GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }

    void Win()
    {
        playable = false;
        score++;
        ScoreText.text = $"Skor: {score}";
        NextButton.gameObject.SetActive(true);
    }

    void SetScoreText(int score)
    {
        ScoreText.text = $"Skor: {score}";
    }

    void SetAnswerText(string text)
    {
        char[] charArray = text.ToCharArray();
        AnswerText.text = "";
        for(int i = 0; i < 5; i++)
        {
            if(charArray[i] == 'i')
            {
                AnswerText.text += 'İ';
            }
            else
            {
                string temp = charArray[i].ToString();
                AnswerText.text += temp.ToUpper();
            }
        }
    }

    void ResetKeyboard()
    {
        List<char> keyList = new List<char>(KeyboardDictionary.KeyboardObjs.Keys);
        for(int i = 0; i < keyList.Count; i++)
        {
            char ch = keyList[i];
            Button keyboard = KeyboardDictionary.KeyboardObjs[ch];
            keyboard.GetComponent<Image>().color = new Color(255, 255, 255);
        }

    }

    string CheckColor(Color color)
    {
        int hashCode = color.GetHashCode();
        switch (hashCode)
        {
            case -778043392:
                return "white";
            case -754974720:
                return "gray";
            case 1363345408:
                return "yellow";
            case 305922048:
                return "green";
            default:
                return "white";
        }
    }
}
