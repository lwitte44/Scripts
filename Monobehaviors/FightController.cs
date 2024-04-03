using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FightController : MonoBehaviour
{
    public GameObject Player, Monster;
    public TextMeshPro PlayerStats, MonsterStats;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Inhabitant monster;
    private Inhabitant player;

    private void Setstats()
    {
        this.PlayerStats.text = "HP: " + this.player.getCurrentHP() + " AC: " + this.player.getCurrentAC();
        this.MonsterStats.text = "HP: " + this.monster.getCurrentHP() + " AC: " + this.monster.getCurrentAC();
    }
    // Start is called before the first frame update
    void Start()
    {
        print("BATTLE STARTED");
        Setstats();

    int num = Random.Range(0, 2); //coin flip will produce 0 and 1 since 2 is excluded
        if (num == 0)
        {
            this.currentAttacker = Player;
        }
        else
        {
            this.currentAttacker = Monster;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.currentAttacker == this.Player)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();

            if (diceRole(20) >= this.monster.getCurrentAC())
            {
                this.theCurrentAnimator.SetTrigger("attackP");
                this.monster.setCurrentHP(this.monster.getCurrentHP() - diceRole(6));
                this.currentAttacker = this.Monster;
                Setstats();
            }
            else
            {
                this.currentAttacker = this.Monster;
            }
        }    
        else if (this.currentAttacker == this.Monster)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();

            if (diceRole(20) >= this.player.getCurrentAC())
            {
                this.theCurrentAnimator.SetTrigger("attackM");
                this.player.setCurrentHP(this.player.getCurrentHP() - diceRole(6));
                this.currentAttacker = this.Player;
                Setstats();
            }
            else
            {
                this.currentAttacker = this.Player;
            }
         
        }
    }
    private int diceRole(int size)
    {
       return Random.Range(1, size + 1);
    }
   
}
