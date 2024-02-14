using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("onCollisionEnter");
    }

    private void OnTriggerEnter(Collider other)
    {
        // print("Secret Number = " + MySingleton.secretNumber);
        //MySingleton.secretNumber = 5;
        if (other.gameObject.CompareTag("North Exit"))
        {
            EditorSceneManager.LoadScene("Scene2");
            print("****ENTER SCENE2****");
            this.gameObject.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        }
        if (other.gameObject.CompareTag("East Exit"))
        {
            EditorSceneManager.LoadScene("Scene2");
            print("****ENTER SCENE2****");
            this.gameObject.transform.position = other.gameObject.transform.position;
        }
        if (other.gameObject.CompareTag("South Exit"))
        {
            EditorSceneManager.LoadScene("Scene2");
            print("****ENTER SCENE2****");
            this.gameObject.transform.position = other.gameObject.transform.position;
        }
        if (other.gameObject.CompareTag("West Exit"))
        {
            EditorSceneManager.LoadScene("Scene2");
            print("****ENTER SCENE2****");
            this.gameObject.transform.position = other.gameObject.transform.position;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        print("onTriggerExit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
