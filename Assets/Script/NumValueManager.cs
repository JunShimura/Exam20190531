using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumValueManager : MonoBehaviour
{

    [SerializeField]
    private int storedValue = 0;

    public int Value
    {
        get
        {
            return storedValue;
        }
    }

    [SerializeField]
    Text valueText;


    // Use this for initialization
    void Start()
    {
        valueText.text = storedValue.ToString();
    }

    public void IncreaseValue()
    {
        storedValue++;
        valueText.text = storedValue.ToString();
    }
    public void IncreaseValue10()
    {
        storedValue+=10;
        valueText.text = storedValue.ToString();
    }
    public void DecreaseValue()
    {
        storedValue--;
        valueText.text = storedValue.ToString();
    }
    public void DecreaseValue10()
    {
        storedValue-=10;
        valueText.text = storedValue.ToString();
    }



}
