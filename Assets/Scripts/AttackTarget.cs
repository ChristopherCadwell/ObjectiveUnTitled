using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour
{

    public GameObject owner;
    public AudioClip clip; // assign hit sound

    [SerializeField]
    private string attackAnimation;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float manaCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    public void hit(GameObject target)
    {

        //attack target
        UnitStats ownerStats = this.owner.GetComponent<UnitStats>();//get stats of current unit
        UnitStats targetStats = target.GetComponent<UnitStats>();//get stats of target unit

        if (ownerStats.mana >= this.manaCost)//check mana cost
        {
         //work out values
            float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
            float damage = (this.magicAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

            float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

            //show attack
            this.owner.GetComponent<Animator>().Play(this.attackAnimation);
            AudioSource.PlayClipAtPoint(clip, new Vector3());

            //do damage
            targetStats.receiveDamage(damage);

            //mana calc
            ownerStats.mana -= this.manaCost;
        }
    }
}
