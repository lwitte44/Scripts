using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;


public class FightController : MonoBehaviour
{
    public GameObject Player; 
    public GameObject[] DragonList;
    public GameObject monsterLocation;
    public TextMeshPro PlayerStats, MonsterStats;
    public TextMeshProUGUI GameEndText;
    public TextMeshProUGUI AttackText;
    public GameObject AttacklineL, AttacklineR;
    private GameObject currentAttacker;
    private GameObject realDragon;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private int dragonIndex;
    private bool attackHit = false;


    private void Setstats()
    {
        this.PlayerStats.text = "HP: " + MySingleton.thePlayer.getCurrentHP() + " AC: " + MySingleton.thePlayer.getCurrentAC();
        this.MonsterStats.text = "HP: " + this.theMonster.getCurrentHP() + " AC: " + this.theMonster.getCurrentAC();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Lurtz");

        this.dragonIndex = Random.Range(0, DragonList.Length);

        resetStats();
        print("BATTLE STARTED");
        Setstats();
        print("Player Starting Stats: HP: " + MySingleton.thePlayer.getCurrentHP() + " AC: " + MySingleton.thePlayer.getCurrentAC());
        print("Monster Starting Stats: HP: " + this.theMonster.getCurrentHP() + " AC: " + this.theMonster.getCurrentAC());
        //chooseDragon();
        int num = Random.Range(0, 2); //coin flip will produce 0 and 1 since 2 is excluded
        if (num == 0)
        {
            this.currentAttacker = Player;
            print("Player goes first...");
            this.AttackText.text = "Player Turn:";
        }
        else
        {
            this.currentAttacker = this.realDragon;
            print("Monster goes first...");
            this.AttackText.text = "Monster Turn:";
        }

        this.DragonList[this.dragonIndex].SetActive(true);
        this.DragonList[this.dragonIndex].transform.position = this.monsterLocation.transform.position;
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
                    this.attackHit = true;
                    this.theCurrentAnimator.SetTrigger("newAttack");

                    if (MySingleton.hasUpgrade == true)
                    {
                        this.theMonster.setCurrentHP(this.theMonster.getCurrentHP() - diceRole(6) - 4);
                        print("USED UPGRADE");
                    }
                    else
                    {
                        this.theMonster.setCurrentHP(this.theMonster.getCurrentHP() - diceRole(6));
                    }

                    //StartCoroutine(attackMove());
                    setTurn();

                    this.currentAttacker = this.DragonList[this.dragonIndex];
                    Setstats();
                    deathCheck();
                    this.attackHit = false;
                }
                else
                {
                    this.attackHit = false;
                    //StartCoroutine(missMove());
                    setTurn();
                    this.currentAttacker = this.DragonList[this.dragonIndex];
                }
            }
            else if (this.currentAttacker == this.DragonList[this.dragonIndex])
            {
                this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                print("Monster's Turn...");

                if (diceRole(20) >= MySingleton.thePlayer.getCurrentAC())
                {
                    this.attackHit = true;
                    this.theCurrentAnimator.SetTrigger("Attack1");
                    print("MONSTER ATTACK");
                    MySingleton.thePlayer.setCurrentHP(MySingleton.thePlayer.getCurrentHP() - diceRole(6));

                    //StartCoroutine(attackMove());
                    setTurn();

                    this.currentAttacker = this.Player;
                    Setstats();
                    deathCheck();
                    this.attackHit = false;
                }
                else
                {
                    this.attackHit = false;
                    //StartCoroutine(missMove());
                    setTurn();
                    this.currentAttacker = this.Player;
                } 
            }
            print("I'm dumb.");
        }
    }
    private void deathCheck()
    {
        if (MySingleton.thePlayer.getCurrentHP() <= 0)
        {
            StartCoroutine(gameEnd());
        }
        else if (this.theMonster.getCurrentHP() <= 0)
        {
            StartCoroutine(gameEnd());
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
    private void setTurn()
    {
        if (this.currentAttacker == this.Player && this.attackHit == true)
        {
            StartCoroutine(attackMove());
        }
        else if (this.currentAttacker == this.Player && this.attackHit == false)
        {
            StartCoroutine(missMove());
        }
        else if (this.currentAttacker == this.DragonList[this.dragonIndex] && this.attackHit == true)
        {
            StartCoroutine(attackMove());
        }
        else if (this.currentAttacker == this.DragonList[this.dragonIndex] && this.attackHit == false)
        {
            StartCoroutine(missMove());
        }
        else
        {
            print("****ATTACK BROKEN****");
        }
    }
    IEnumerator attackMove()
        {
        if (currentAttacker == this.Player) 
        {
            this.AttackText.text = "Player Turn: ATTACK!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "Monster Turn:";
        }
        else
        {
            this.AttackText.text = "Monster Turn: ATTACK!";
            yield return new WaitForSeconds(3);
            this.AttackText.text = "Player Turn:";
        }
        
        }
    IEnumerator missMove()
    {
        if (currentAttacker == this.Player)
        {
            this.AttackText.text = "Player Turn: MISS!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "Monster Turn:";
        }
        else
        {
            this.AttackText.text = "Monster Turn: MISS!";
            yield return new WaitForSeconds(1);
            this.AttackText.text = "Player Turn:";
        }

    }
    IEnumerator gameEnd() 
    {
        if (MySingleton.thePlayer.getCurrentHP() <= 0)
        {
            yield return new WaitForSeconds(3);
            this.GameEndText.text = "GAMEOVER";
            this.AttackText.text = "Monster Wins!";
            this.Player.gameObject.SetActive(false);
            this.PlayerStats.gameObject.SetActive(false);
            this.currentAttacker = null;
            MySingleton.playerWin = false;
            yield return new WaitForSeconds(3);
            EditorSceneManager.LoadScene("Scene1");
        }
        else if (this.theMonster.getCurrentHP() <= 0)
        {
            yield return new WaitForSeconds(3);
            this.GameEndText.text = "GAMEOVER";
            this.AttackText.text = "Player Wins!";
            this.DragonList[this.dragonIndex].gameObject.SetActive(false);
            this.MonsterStats.gameObject.SetActive(false);
            this.currentAttacker = null;
            MySingleton.playerWin = true;
            MySingleton.count = MySingleton.count + 1;
            yield return new WaitForSeconds(3);
            EditorSceneManager.LoadScene("Scene1");
        }
    }
    private void resetStats()
    {
        this.theMonster.rerollHP();
        MySingleton.thePlayer.rerollHP();
    }
    /*
    private void chooseDragon()
    {
       

        if ( DragonIndex == 1) 
        {
            this.Dragon1 = this.realDragon;
            this.Dragon1.SetActive(true);
        }
        else if (theNum == 2)
        {
            this.Dragon2 = this.realDragon;
            this.Dragon2.SetActive(true);
        }
        else if (theNum == 3)
        {
            this.Dragon3 = this.realDragon;
            this.Dragon3.SetActive(true);
        }
        else if (theNum == 4)
        {
            this.Dragon4 = this.realDragon;
            this.Dragon4.SetActive(true);
        }
    }
    */

}
