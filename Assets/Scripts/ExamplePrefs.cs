using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePrefs : MonoBehaviour
{


    public int loadedInt;
    public float loadedFloat;
    public string loadedString;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        //SaveData();
        LoadData();
        Debug.Log(loadedInt);
        Debug.Log(loadedFloat);
        Debug.Log(loadedString);


    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
    
    public void SaveData()
    {
        PlayerPrefs.SetInt("MyIntData", 100);
        PlayerPrefs.SetFloat("MyFloatData", 0.5f);
        PlayerPrefs.SetString("MyStringData", "PlayerPrefs Example!!!!!!!!!!!!");
        Debug.Log("Data Saved!!!!");


    }

    public void LoadData()
    {
        loadedInt= PlayerPrefs.GetInt("MyIntData");
        loadedFloat= PlayerPrefs.GetFloat("MyFloatData");
        loadedString= PlayerPrefs.GetString("MyStringData");
        Debug.Log("Data Load!!!!");
    }
}
