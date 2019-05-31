#define debug_DetermineNumber_answer
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class DetermineNumber2 : MonoBehaviour
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
    int r1, r2;  //r2を追加
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
        r2 = (r1 + UnityEngine.Random.Range(0, rangeMax + 1)) % rangeMax + randomMin;
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

    /// <summary>
    /// 指定された番号に従って処理を呼ぶ
    /// </summary>
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
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ
        if (r1 == n1)
        {
            answer += "当たり！";
        }
        else if (n1 == r1 - 1 || n1 == r1 + 1)
        {   // 惜しい場合
            answer += "惜しい";
        }
        else if (n1 >= r1 - 3 && n1 <= r1 + 3)
        {   // 近い場合
            answer += "近い";
        }
        else
        {
            answer += "ハズレ";
        }
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
        if (n1 > n2)
        {
            int t = n2;
            n2 = n1;
            n1 = t;
        }
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ

        // 差分を求める
        int diff1 = Mathf.Abs(r1 - n1);
        int diff2 = Mathf.Abs(r2 - n2);
        if (diff1 > diff2)
        {
            int t = diff2;
            diff2 = diff1;
            diff1 = t;
        }
        if (diff1 == 0)
        {
            if (diff2 == 0)
            {
                answer = "当たり";
            }
            else
            {
                answer = "片方あたり";
                if (diff2 == 1)
                {
                    answer += "片方惜しい";
                }
                else if (diff2 <= 3)
                {
                    answer += "片方近い";
                }
            }
        }
        else if (diff1 == 1)
        {
            if (diff2 == 1)
            {
                answer = "両方惜しい";
            }
            else
            {
                answer = "片方惜しい";
                if (diff2 <= 3)
                {
                    answer += "片方近い";
                }
            }
        }
        else if (diff2 <= 3)
        {
            if (diff2 <= 3)
            {
                answer = "両方惜しい";
            }
            else
            {
                answer = "片方惜しい";
            }
        }
        else
        {
            answer = "ハズレ";
        }
        return answer;
    }


    enum Diff
    {
        much1 = 1,
        neighbor1 = 1 << 1,
        near1 = 1 << 2,
        far1 = 1 << 3,
        much2 = 1 << 4,
        neighbor2 = 1 << 5,
        near2 = 1 << 6,
        far2 = 1 << 7
    };
    Dictionary<Diff, string> DiffMessage = new Dictionary<Diff, string>()
    {
        {   Diff.much1      |Diff.much2,        "当たり" },
        {   Diff.much1      |Diff.neighbor2,    "片方当たり、片方惜しい" },
        {   Diff.much1      |Diff.near2,        "片方当たり、片方近い" },
        {   Diff.much1      |Diff.far2,         "片方当たり" },
        {   Diff.neighbor1  |Diff.neighbor2,    "両方惜しい" },
        {   Diff.neighbor1  |Diff.near2,        "片方惜しい、片方近い" },
        {   Diff.neighbor1  |Diff.far2,         "片方惜しい" },
        {   Diff.near1      |Diff.near2,        "両方近い"},
        {   Diff.near1      |Diff.far2,         "片方近い"},
        {   Diff.far1       |Diff.far2,         "ハズレ"}
    };

    Diff Compare(int a, int b)
    {
        int diff = Mathf.Abs(a - b);
        if (diff == 0)
        {
            return Diff.much1;
        }
        else if (diff == 1)
        {
            return Diff.neighbor1;
        }
        else if (diff == 2 || diff == 3)
        {
            return Diff.neighbor1;
        }
        else
        {
            return Diff.far1;
        }
    }
    string Quiz3(int n1, int n2)
    {
        if (n1 > n2)
        {
            int t = n2;
            n2 = n1;
            n1 = t;
        }
        answerdTimes++;
        string answer = answerdTimes.ToString() + "回目:";   //こたえのメッセージ
        // 差分を求める
        List<int> judge = new List<int>();
        judge.Add((int)Compare(n1, r1));
        judge.Add((int)Compare(n1, r2));
        judge.Add((int)Compare(n2, r1));
        judge.Add((int)Compare(n2, r2));
        Diff diff1;
        if (judge[0] < judge[1])
        {
            diff1 = (Diff)judge[0];
        }
        else
        {
            diff1 = (Diff)judge[1];
        }
        Diff diff2;
        if (judge[2] < judge[3])
        {
            diff2 = (Diff)judge[2];
        }
        else
        {
            diff2 = (Diff)judge[3];
        }
        answer += DiffMessage[diff1|(Diff)((int)diff2<<4)];

        return answer;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
