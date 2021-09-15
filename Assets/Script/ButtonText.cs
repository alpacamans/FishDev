using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private Text SetButtonText;
    /*  [SerializeField] private Image img_name;
      [SerializeField] private Sprite sprite;

      private bool isCoolTime = false;

      private float currenTime = 5f;
      private float delayTime = 5f;*/

    [SerializeField]
    GameObject InforWindow;

    [SerializeField]
    GameObject JoyStick;
    [SerializeField]
    GameObject FishingButton;

    public static bool BoatSet;
    // Start is called before the first frame update
    void Start()
    {

        BoatSet = true;
        if (BoatSet == true)
        {
            SetButtonText.text = "����";
            BoatSet = false;
            JoyStick.SetActive(true);
            FishingButton.SetActive(false);
        }
        else
        {
            SetButtonText.text = "���";
            BoatSet = true;
            JoyStick.SetActive(false);
            FishingButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Color color = img_name.color;
        color.a = 0f;
        img_name.color = color;
        if (isCoolTime)
        {
            currenTime -= Time.deltaTime;
            img_name.fillAmount = currenTime / delayTime;

            if (currenTime <= 0)
            {
                isCoolTime = false;
                currenTime = 1f;
                img_name.fillAmount = currenTime;
            }
        }*/
    }

    public void Change()
    {
        Debug.Log("�¹�ư����");
        if (InforWindow.activeSelf == false)
        {
            if (BoatSet == true)
            {
                //�������־�����
                Debug.Log("���ڼ¹�ư����");

                SetButtonText.text = "����";
                BoatSet = false;
                JoyStick.SetActive(true);
                FishingButton.SetActive(false);
            }
            else
            {
                //���ھ��߾�����
                Debug.Log("��߼¹�ư����");

                SetButtonText.text = "���";
                BoatSet = true;
                JoyStick.SetActive(false);
                FishingButton.SetActive(true);

                /*Debug.Log(GameObject.Find("Water").GetComponent<FishRandom>().selectfish.fishname);*/


            }
        }
    }
}
