using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fishing : MonoBehaviour
{

    [SerializeField]
    GameObject InforWindow;

    [SerializeField]
    Image FishImage;
    [SerializeField]
    Text FishInformation;
    [SerializeField]
    Text FishName;

    bool isTouch = false;

    public Text Btn_Text;
    public float timeSet;
    private float time;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch == true)
        {
            time -= Time.deltaTime;
            Btn_Text.text = time.ToString("N1");
            if (time <= 0)
            {
                Btn_Text.text = "³¬½ÃÇÏ±â";
                isTouch = false;
            }
        }


    }
    public void GetButtonClick()
    {
        if (InforWindow.activeSelf == false && isTouch == false)
        {
            isTouch = true;
            time = timeSet;
            GameObject.Find("Water").GetComponent<FishRandom>().GetFish();
            Debug.Log("µÊ");
            InforWindow.SetActive(true);
            FishName.text = GameObject.Find("Water").GetComponent<FishRandom>().selectfish.fishname;
            FishInformation.text = GameObject.Find("Water").GetComponent<FishRandom>().selectfish.fishinformation;
            FishImage.sprite = GameObject.Find("Water").GetComponent<FishRandom>().selectfish.fishimage;
        }
        

    }


}