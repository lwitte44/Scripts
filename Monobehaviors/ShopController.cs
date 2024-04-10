using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ShopController : MonoBehaviour
{
    public GameObject Shopkeeper;
    public GameObject Upgrade;
    public TextMeshPro UpgradeDescription;
    public TextMeshProUGUI RubyErrorMessage;
    public TextMeshProUGUI RubyCount;
    private int upgradePrice = 3;
    // Start is called before the first frame update
    void Start()
    {
        setCount();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            if (MySingleton.count >= upgradePrice)
            {
                this.Upgrade.gameObject.SetActive(false);
                this.UpgradeDescription.gameObject.SetActive(false);
                MySingleton.hasUpgrade = true;
                MySingleton.count = MySingleton.count - upgradePrice;
                setCount();

            }
            else
            {
                StartCoroutine(errorMessage());
            }
        }
        else if(Input.GetKeyUp(KeyCode.H))
        {
            EditorSceneManager.LoadScene("Scene1");
        }
    }
    private void setCount()
    {
        this.RubyCount.text = "Rubies: " + MySingleton.count;
    }
    IEnumerator errorMessage()
    {
        this.RubyErrorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.RubyErrorMessage.gameObject.SetActive(false);
    }
}
