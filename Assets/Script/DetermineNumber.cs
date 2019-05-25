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
    int r1;
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
