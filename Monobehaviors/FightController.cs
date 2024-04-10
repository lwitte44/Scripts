using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;


public class FightController : MonoBehaviour
{
    public GameObject Player, Monster;
    public TextMeshPro PlayerStats, MonsterStats;
    public TextMeshProUGUI GameEndText;
    public TextMeshProUGUI AttackText;
    public GameObject AttacklineL, AttacklineR;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;

    private void Setstats()
    {
        this.PlayerStats.text = "HP: " + MySingleton.thePlayer.getCurrentHP() + " AC: " + MySingleton.thePlayer.getCurrentAC();
        this.MonsterStats.text = "HP: " + this.theMonster.getCurrentHP() + " AC: " + this.theMonster.getCurrentAC();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        this.theMonster = new Monster("Lurtz"); 
        resetStats();
        print("BATTLE STARTED");
        Setstats();
        print("Player Starting Stats: HP: " + MySingleton.thePlayer.getCurrentHP() + " AC: " + MySingleton.thePlayer.getCurrentAC());
        print("Monster Starting Stats: HP: " + this.theMonster.getCurrentHP() + " AC: " + this.theMonster.getCurrentAC());

        int num = Random.Range(0, 2); //coin flip will produce 0 and 1 since 2 is excluded
        if (num == 0)
        {
            this.currentAttacker = Player;
            print("Player goes first...");
        }
        else
        {
            this.currentAttacker = Monster;
            print("Monster goes first...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (this.currentAttacker == this.Player)
            {
                this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                print("Player's Turn...");

                if (diceRole(20) >= this.theMonster.getCurrentAC())
                {
                    print("PLAYER ATTACK");
                    this.theCurrentAnimator.SetTrigger("attackP");

                    if (MySingleton.hasUpgrade == true)
                    {
                        this.theMonster.setCurrentHP(this.theMonster.getCurrentHP() - diceRole(6) - 4);
                        print("USED UPGRADE");
                    }
                    else
                    {
                        this.theMonster.setCurrentHP(this.theMonster.getCurrentHP() - diceRole(6));
                    }

                    StartCoroutine(attackMove());

                    this.currentAttacker = this.Monster;
                    Setstats();
                    deathCheck();
                }
                else
                {
                    StartCoroutine(missMove());
                    this.currentAttacker = this.Monster;
                }
            }
            else if (this.currentAttacker == this.Monster)
            {
                this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                print("Monster's Turn...");

                if (diceRole(20) >= MySingleton.thePlayer.getCurrentAC())
                {
                    this.theCurrentAnimator.SetTrigger("attackM");
                    print("MONSTER ATTACK");
                    MySingleton.thePlayer.setCurrentHP(MySingleton.thePlayer.getCurrentHP() - diceRole(6));

                    StartCoroutine(attackMove());

                    this.currentAttacker = this.Player;
                    Setstats();
                    deathCheck();
                }
                else
                {
                    StartCoroutine(missMove());
                    this.currentAttacker = this.Player;
                }
            }
        }
    }
    private void deathCheck()
    {
        if (MySingleton.thePlayer.getCurrentHP() <= 0)
        {
            this.GameEndText.text = "GAMEOVER";
            this.Player.gameObject.SetActive(false);
            this.PlayerStats.gameObject.SetActive(false);
            this.currentAttacker = null;
            MySingleton.playerWin = false;
            EditorSceneManager.LoadScene("Scene1");
        }
        else if (this.theMonster.getCurrentHP() <= 0)
        {
            this.GameEndText.text = "GAMEOVER";
            this.Monster.gameObject.SetActive(false);
            this.MonsterStats.gameObject.SetActive(false);
            this.currentAttacker = null;
            MySingleton.playerWin = true;
            MySingleton.count = MySingleton.count + 1;
            EditorSceneManager.LoadScene("Scene1");
        }
        else
        {
            return;
        }
    }
    private int diceRole(int size)
    {
        int answer = Random.Range(1, size + 1);
        print("You Rolled a " + answer + "!");
        return answer;

    }
    IEnumerator attackMove()
        {
        if (currentAttacker == this.Player) 
        {
            this.AttackText.transform.position = this.AttacklineR.transform.position;
            this.AttackText.text = "Attack!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "";
        }
        else
        {
            this.AttackText.transform.position = this.AttacklineL.transform.position;
            this.AttackText.text = "Attack!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "";
        }
        
        }
    IEnumerator missMove()
    {
        if (currentAttacker == this.Player)
        {
            this.AttackText.transform.position = this.AttacklineR.transform.position;
            this.AttackText.text = "Miss!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "";
        }
        else
        {
            this.AttackText.transform.position = this.AttacklineL.transform.position;
            this.AttackText.text = "Miss!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "";
        }

    }
    private void resetStats()
    {
        this.theMonster.rerollHP();
        MySingleton.thePlayer.rerollHP();
    }

}
