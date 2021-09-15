
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public Boolean End = false;
    public string[][,] Sentence;
    
    [SerializeField]
    public TextAsset[] txt;

    
    int lineSize, rowSize;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    // 저장된 데이터를 가져오는 작업

    void Start()
    {
        Sentence = new string[txt.Length][,];
        for (int z = 0; z < txt.Length; z++) {
            Debug.Log("시작됨" + txt.Length);


            string currentText = txt[z].text.Substring(0, txt[z].text.Length - 1);
            string[] line = currentText.Split('\n');
            lineSize = line.Length;
            rowSize = line[0].Split('\t').Length;
            Sentence[z] = new string[lineSize, rowSize];


            
            for (int i = 0; i < lineSize; i++)
            {
                string[] row = line[i].Split('\t');
                for (int j = 0; j < rowSize; j++) {
                    Sentence[z][i, j] = row[j].Trim();

                }
                if(rowSize==4)
                print(Sentence[z][i, 0] + ',' + Sentence[z][i, 1] + ',' + Sentence[z][i, 2] + ',' + Sentence[z][i, 3]);
                if(rowSize==2)
                    print(Sentence[z][i, 0] + ',' + Sentence[z][i, 1]);

            }
        }

        End = true;
    }
}