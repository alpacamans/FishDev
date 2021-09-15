using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public GameObject Player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {


            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            /*GameObject Player = GameObject.FindWithTag("Player");
            Player.transform.position = new Vector3(500, 0, 100);
            Player.transform.rotation = Quaternion.identity;
                Debug.Log("태평양가즈아");
    */
            Debug.Log(sceneName);

            if (sceneName == "PacificOcean")
            {
                Debug.Log("태평양가즈아");
                Player = GameObject.FindWithTag("Player");
                Player.transform.position = new Vector3(500, 0, 150);
            }
        }
    }

}
