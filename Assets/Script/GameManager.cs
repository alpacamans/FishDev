
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
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    // ����� �����͸� �������� �۾�

    void Start()
    {
        Sentence = new string[txt.Length][,];
        for (int z = 0; z < txt.Length; z++) {
            Debug.Log("���۵�" + txt.Length);


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