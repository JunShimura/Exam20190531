#define debug_DetermineNumber_answer
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DetermineNumber : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    [SerializeField] Text answerText;
    [SerializeField] NumValueManager numValueManager1;
    [SerializeField] NumValueManager numValueManager2;
    delegate string DetermineNumberQuiz(int n1, int n2);
    List<DetermineNumberQuiz> determineNumberQuiz = new List<DetermineNumberQuiz>();

    // Random 
    int r1;
    [SerializeField] int randomMin = 1;
    [SerializeField] int randomMax = 10;

    //　回数
    int answerdTimes = 0;

    //
    private void Awake()
    {
        determineNumberQuiz.Add(Quiz0);
        determineNumberQuiz.Add(Quiz1);
        determineNumberQuiz.Add(Quiz2);
        determineNumberQuiz.Add(Quiz3);
    }

    // Use this for initialization
    void Start()
    {
        //ランダムを引く
        r1 = Random.Range(randomMin, randomMax + 1);
#if debug_DetermineNumber_answer
        Debug.Log("r1=" + r1.ToString());
#endif
    }

    public void Exec()
    {
        //処理
        int n1 = numValueManager1.Value;
        int n2 = numValueManager2.Value;
        int selected = dropdown.value;
        if (selected < determineNumberQuiz.Count)
        {
            answerText.text = determineNumberQuiz[selected](n1, n2);
        }
        else
        {
            Debug.LogError("Not Defined Detelgae for selected ID");
        }

    }
    string Quiz0(int n1, int n2)
    {
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ
        if (r1 == n1)
        {
            answer += "当たり！";
        }
        else
        {
            answer += "ハズレ";
        }
        return answer;
    }
    string Quiz1(int n1, int n2)
    {
        string answer = "まだやってません1";
        return answer;
    }
    string Quiz2(int n1, int n2)
    {
        string answer = "まだやってません2";
        return answer;
    }
    string Quiz3(int n1, int n2)
    {
        string answer = "";
        return answer;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
