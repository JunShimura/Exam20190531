using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExecButtonManager : MonoBehaviour
{

    public Dropdown dropdown;
    public Text answerText;
    public GameObject numValue1;
    public GameObject numValue2;
    NumValueManager numValueManager1;
    NumValueManager numValueManager2;
    float n1;
    float n2;

    // Use this for initialization
    void Start()
    {

        numValueManager1 = numValue1.GetComponent<NumValueManager>();
        numValueManager2 = numValue2.GetComponent<NumValueManager>();

    }

    public void Exec()
    {
        //処理
        n1 = numValueManager1.Value;
        n2 = numValueManager2.Value;
        int selected = dropdown.value;
        switch (selected)
        {
            case 0:
                answerText.text = Ex0();
                break;
            case 1:
                answerText.text = Ex1();
                break;
            case 2:
                answerText.text = Ex2();
                break;
            case 3:
                answerText.text = Ex3();
                break;
            case 4:
                answerText.text = Ex4();
                break;
            case 5:
                answerText.text = Ex5();
                break;
            case 6:
                answerText.text = Ex6();
                break;
            case 7:
                answerText.text = Ex7();
                break;
            case 8:
                answerText.text = Ex8();
                break;
            case 9:
                answerText.text = Ex9();
                break;
            case 10:
                answerText.text = Ex10();
                break;
            default:
                break;
        }
    }
    string Ex0()
    {
        //問題0
        string answer = "";   //こたえのメッセージ
        //ここで答えを出してanswerへ代入する
        float result = n1 + n2;   //計算結果   

        answer = result.ToString(); //計算結果をanswerに入れて返す
        //answer = n1 + "+" + n2 + "=" + result.ToString(); 
        return answer;
    }
    string Ex1()
    {
        //問題1
        //例)20mの距離を4mごとに植木を植えるのに
        //何本いるかを以下で入力
        //変数1 = 20,変数2 = 4なら、
        //「6本いります」

        string answer = "";
        //ここで答えを出してanswerへ代入する
        float result = n1 / n2 + 1;
        answer = result.ToString() + "本いります";
        return answer;
    }
    string Ex2()
    {
        //問題2
        // (2)BMIその一
        //身長と体重を入力してBMIを算出
        //例）80kg、身長1.7mなら、80 / (1.7 * 1.7)＝27.68
        //表示は
        //BMI = 27.68
        string answer = "";
        //ここで答えを出してanswerへ代入する
        float result = n1 / (n2 / 100.0f * n2 / 100.0f);
        answer = "BMI=" + result.ToString("#.##");
        return answer;
    }
    string Ex3()
    {
        //問題3
        // (3)つるかめ算の基礎
        //例)つるが4羽、亀が5匹居ます
        //頭と足が幾つになるかを以下で入力
        //変数1 = 4,変数2 = 5なら、
        //「頭が9、足が28本」

        string answer = "";
        //ここで答えを出してanswerへ代入する
        float heads = n1 + n2;
        float legs = n1 * 2 + n2 * 4;
        answer = "頭が" + heads.ToString() + "、足が" + legs.ToString();
        return answer;
    }
    string Ex4()
    {
        //問題4
        //(4)BMIその2
        //肥満度を出す。以下を参照
        //http://keisan.casio.jp/exec/system/1161228732
        //ヒント：ifなどを使います

        string answer = "";
        //ここで答えを出してanswerへ代入する
        float result = n1 / (n2 / 100.0f * n2 / 100.0f);
        answer = "BMI=" + result.ToString("#.##");
        if (result < 18.5f)
        {
            answer += "低体重です";
        }
        else if (result < 25.0f)
        {
            answer += "普通体重です";
        }
        else if (result < 30.0f)
        {
            answer += "肥満（1度）です";
        }
        else if (result < 35.0f)
        {
            answer += "肥満（2度）です";
        }
        else if (result < 40.0f)
        {
            answer += "肥満（3度）です";
        }
        else
        {
            answer += "肥満（4度）です";
        }

        return answer;
    }
    string Ex5()
    {
        //問題5
        //つるかめ算
        //例)頭が4、足が12本ます
        //それぞれ何匹いるかを以下で入力
        //変数1 = 4,変数2 = 12なら、
        //「つるが2、亀が2」

        string answer = "";
        //ここで答えを出してanswerへ代入する
        float crane = 0;
        float turtle = 0;

        //crane + turtle = n1;
        //crane * 2 + turtle * 4 = n2;
        turtle = n2 / 2 - n1;
        crane = n1 - turtle;
        answer = "つるが" + crane.ToString() + "、亀が" + turtle.ToString();
        return answer;
    }
    string Ex6()
    {
        //問題6
        //入力エラーを出すようにする
        //例）頭が2、足が10ならあり得ないので
        //「入力エラー」

        string answer = "";
        //ここで答えを出してanswerへ代入する

        float crane = 0;
        float turtle = 0;

        //crane + turtle = n1;
        //crane * 2 + turtle * 4 = n2;
        turtle = n2 / 2 - n1;
        crane = n1 - turtle;
        Debug.Log(crane + "," + turtle);

        if (turtle >= 0 && crane >= 0 && Mathf.Ceil(turtle) == turtle && Mathf.Ceil(crane) == crane)
        {
            answer = "つるが" + crane.ToString() + "、亀が" + turtle.ToString();
        }
        else
        {
            answer = "入力エラー";
        }
        return answer;
    }
    string Ex7()
    {
        //問題7
        //ポケモンGOのポッポの進化できる数を算出します。
        //・飴の数とポッポの数を入力します
        //・ポッポは飴が12個で一体、進化できます
        //・ポッポは、博士に送ることで飴が一個、手に入ります
        //・ポッポから進化したピジョンは、
        //　博士に送ることで飴が一個、手に入ります

        string answer = "";
        //ここで答えを出してanswerへ代入する
        float candy = n1;   //飴
        float poppo = n2;   //ポッポ
        int evolution = 0;  //進化

        for (;;)
        {
            if (poppo > 0 && candy >= 12)
            {   //進化
                poppo--;
                candy -= 11;
                evolution++;
            }
            else if (poppo > 0 && poppo + candy >= 12 && candy < 12)
            {   //飴が足りないがポッポを飴に変えると進化できる
                poppo -= (12 - candy);
                candy += (12 - candy);
            }
            else
            {
                break;
            }
        }
        answer = "進化" + evolution.ToString()
            + "体,飴余り" + candy.ToString()
            + "個、ポッポ余り" + poppo.ToString() + "羽";

        return answer;
    }
    string Ex8()
    {
        //問題8
        string answer = "";
        //ここで答えを出してanswerへ代入する
        answer = "Ex8 まだやってません";
        return answer;
    }
    string Ex9()
    {
        //問題9
        string answer = "";
        //ここで答えを出してanswerへ代入する
        answer = "Ex9 まだやってません";
        return answer;
    }
    string Ex10()
    {
        //問題10
        string answer = "";
        //ここで答えを出してanswerへ代入する
        answer = "Ex10 まだやってません";
        return answer;
    }

}
