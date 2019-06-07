#define debug_DetermineNumber_answer
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DetermineNumber : MonoBehaviour
{
    #region Set in Editor
    [SerializeField] Dropdown dropdown;
    [SerializeField] Text answerText;
    [SerializeField] NumValueManager numValueManager1;
    [SerializeField] NumValueManager numValueManager2;
    #endregion

    #region DelegateTable
    // Dalegate list for the selected procedure
    delegate string DetermineNumberQuiz(int n1, int n2);
    List<DetermineNumberQuiz> determineNumberQuiz = new List<DetermineNumberQuiz>();
    #endregion

    // Random 
    int r1, r2;
    [SerializeField] int randomMin = 1;
    [SerializeField] int randomMax = 10;

    //　回数
    int answerdTimes = 0;

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
        int rangeMax = randomMax - randomMin + 1;
        r1 = UnityEngine.Random.Range(0, rangeMax);
        r2 = (r1 + UnityEngine.Random.Range(1, rangeMax)) % rangeMax + randomMin;
        r1 += randomMin;
        if (r1 > r2)
        {
            int t = r1;
            r1 = r2;
            r2 = t;
        }
#if debug_DetermineNumber_answer
        Debug.Log("r1=" + r1.ToString());
        Debug.Log("r2=" + r2.ToString());
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
            Debug.LogError("Not defined the delegate for selected ID");
        }

    }

    /// <summary>
    /// 一つの答えを出すサンプル
    /// 入力値1にある値とランダムを比較、当たりか判定
    /// </summary>
    /// <param name="n1">入力値1</param>
    /// <param name="n2">入力値2</param>
    /// <returns>判定結果</returns>
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

    /// <summary>
    /// 1から10の数をPCが設定し（乱数の使い方を調べて使用する）
    ///    その数を入力して当てる。入力回数を表示する。
    /// メッセージは、
    /// ・答えとの差の絶対値が3以下の場合：「近い」
    /// ・答えとの差の絶対値が1の場合：「惜しい」
    /// ・正解の場合：「当たり！」
    /// ・上記のいずれにも該当しない場合：「ハズレ」
    /// 例）答えが3の場合
    /// 入力が8:「1回目：ハズレ」
    /// 入力が5:「2回目：近い」
    /// 入力が2:「3回目：惜しい」
    /// 入力が3:「4回目：当たり！」
    /// </summary>
    /// <param name="n1">入力値1</param>
    /// <param name="n2">入力値2</param>
    /// <returns>判定結果</returns>
    string Quiz1(int n1, int n2)
    {
        string answer = "まだやってません1";
        return answer;
    }


    /// <summary>
    /// (2)2つの数あてゲーム
    /// 1から10の数を2種類、PCが設定し（乱数の使い方を調べて使用する）
    /// その数を入力して当てる。入力回数を表示する。
    /// メッセージは、それぞれの数の状態によって分かれる
    /// ・答えとの差の絶対値が3以下の場合：「片方近い」「両方近い」
    /// ・答えとの差の絶対値が1の場合：「片方惜しい」「両方惜しい」
    /// ・正解の場合：「片方当たり！」「両方当たり！」
    /// ・上記のいずれにも該当しない場合：「ハズレ」
    /// </summary>
    /// <param name="n1">入力値1</param>
    /// <param name="n2">入力値2</param>
    /// <returns>判定結果</returns>
    string Quiz2(int n1, int n2)
    {
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ
        if (r1 == n1)
        {   //一つ目当たり
            if (r2 == n2)
            {   //二つ目も当たり
                answer += "当たり！";
            }
            else if (Mathf.Abs(r2 - n2) <= 1)
            {   //二つ目惜しい
                answer += "ひとつ当たり、ひとつ惜しい";
            }
            else
            {
                answer += "ひとつ当たり";
            }
        }
        else if (Mathf.Abs(r1 - n1) <= 1)
        {   //一つ目惜しい
            if (r2 == n2)
            {   //二つ目も当たり
                answer += "ひとつ当たり、ひとつ惜しい";
            }
            else if (Mathf.Abs(r2 - n2) <= 1)
            {   //二つ目惜しい
                answer += "ふたつ惜しい";
            }
            else
            {
                answer += "ひとつ惜しい";
            }
        }
        //一つ目はずれ
        else if (r2 == n2)
        {   //二つ目当たり
            answer += "ひとつ当たり";
        }
        else if (Mathf.Abs(r2 - n2) <= 1)
        {   //二つ目惜しい
            answer += "ひとつ惜しい";
        }
        else
        {
            answer += "ハズレ";
        }
        return answer;
    }
    string Quiz3(int n1, int n2)
    {
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ
        int a1 = Mathf.Min(Mathf.Abs(r1 - n1), 2);
        int a2 = Mathf.Min(Mathf.Abs(r2 - n2), 2);
        string[,] answerTable
            ={
            //[0,0] [0,1] [0,2]
            {"当たり","ひとつ当たり、ひとつ惜しい","ひとつ当たり" },
            //[1,0] [1,1] [1,2]
            {"ひとつ当たり、ひとつ惜しい","両方惜しい","ひとつ惜しい" },
            //[2,0] [2,1] [2,2]
            { "ひとつ当たり","ひとつ惜しい","はずれ" }};
        answer += answerTable[a1, a2];
        return answer;
    }




public void ResetScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
