using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FishRandom : MonoBehaviour
{
    [Serializable]
    public struct fish
    {
        public string fishname;
        public string fishinformation;
        public float fishpercent;
        public Sprite fishimage;

    }
    [SerializeField]
    public string[] GetFishName;


    public fish[] fishs;
    public fish selectfish;

    public float Allfishpercent=0;


    [SerializeField]
    public TextAsset txt;
    int lineSize;
    int rowSize;

    // Start is called before the first frame update
    void Start()
    {
        
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        GetFishName = new string[lineSize];

        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++) GetFishName[i] = row[j].Trim();
        }
        while (true)
        {
            if (GameManager.Instance.End)
            {
                SetFish();
                break;
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFish()
    {
        fishs = new fish[GetFishName.Length];

        Allfishpercent = 0f;
        for (int i = 0; i < GetFishName.Length; i++)
        {

            for (int j = 0; j < GameManager.Instance.Sentence[0].GetLength(0); j++)
            {
          
                GetFishName[i] = GetFishName[i].Trim();
                if (GameManager.Instance.Sentence[0][j, 0].Trim() == GetFishName[i])
                {
                    fishs[i].fishname = GetFishName[i];
                    fishs[i].fishpercent = float.Parse(GameManager.Instance.Sentence[0][j, 1]);
                    fishs[i].fishinformation = GameManager.Instance.Sentence[0][j, 3];
                    fishs[i].fishimage = Resources.Load<Sprite>("Fish/image/" + GetFishName[i]);
                    break;

                }
            }
            Allfishpercent += fishs[i].fishpercent;
        }
        Debug.Log("전체확률 = " + Allfishpercent);
        selectfish.fishname = null;
        selectfish.fishinformation = null;
        selectfish.fishpercent = 0;
        selectfish.fishimage = null;
    }

    public void GetFish()
    {
        float randomfish = UnityEngine.Random.Range(0,Allfishpercent);
        /*Debug.Log("물고기 확률 생성 = " + randomfish);*/

        for (int i = 0; i < fishs.Length; i++)
        {
            /*Debug.Log("물고기 반복 = " + i + 1);
            Debug.Log("물고기 확률 = " + fishs[i].fishpercent);
            Debug.Log("물고기 랜덤 = " + randomfish);*/
            if (fishs[i].fishpercent >= randomfish)
            {
                this.selectfish = fishs[i];
                break;
            }
            
            randomfish -= fishs[i].fishpercent;
        }
    }
}
