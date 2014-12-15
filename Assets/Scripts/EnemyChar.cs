using UnityEngine;
using System.Collections;

public class EnemyChar : MonoBehaviour
{

    public GameObject GolemDeathParticles;
    public float instantiateCounter;
    public bool instantiateActive;


    public float HP;
    public float baseDmg;
    public float magicDmg;
    public float agi;
    public float def;
    public float maxHp;
    public Experience exp;

    public GameObject hpbar;
    public GameObject expbar;


    //public float wepDmg;
    public float dmgSkill;
    public float dmgAtk;
    public float skillType;
    public float skillDmg;
    public float skillTotal;
    public float currentDmg;

    public int skills = 2;
    public int type = 1;

    public int level = 1;


    #region Particle death golem

    public float GolemDeathDelay;
    #endregion

    public EnemyMovement em;

    void EnemyType()
    {
        //Class
        switch (type)
        {
            case 1: //Mushroom Posion
                {
                    maxHp = 10;
                    HP = 10;
                    def = 1;
                    agi = 0;

                    break;
                }

            case 2: //Mushroom Spikes
                {
                    maxHp = 10;
                    HP = 10;
                    def = 1;
                    agi = 0;
                    magicDmg = 0;
                    break;
                }

            case 3: //Taong Lupa
                {
                    maxHp = 15;
                    HP = 15;
                    baseDmg = 100;
                    def = 1;
                    agi = 0;
                    magicDmg = 0;

                    break;
                }

            case 4: //Rock
                {
                    maxHp = 10;
                    HP = 10;
                    baseDmg = 255;
                    def = 3;
                    agi = 5;
                    magicDmg = 0;

                    break;
                }

            case 5: //Ibon
                {
                    maxHp = 10;
                    HP = 10;
                    baseDmg = 70;
                    agi = 10;
                    magicDmg = 0;

                    break;
                }

            case 6: //fireDwarf
                {
                    maxHp = 30;
                    HP = 30;
                    baseDmg = 70;
                    def = 8;
                    agi = 10;
                    magicDmg = 0;

                    break;
                }

            case 7: //earthDwarf
                {
                    maxHp = 34;
                    HP = 34;
                    baseDmg = 40;
                    def = 15;
                    agi = 10;
                    magicDmg = 20;

                    break;
                }

            case 8: //bossDwarf
                {
                    maxHp = 60;
                    HP = 60;
                    baseDmg = 100;
                    def = 20;
                    agi = 100;
                    magicDmg = 40;

                    break;
                }
            case 9: //SkeletonArcher
                maxHp = 8;
                HP = 8;
                baseDmg = 30.0f;
                def = 10.0f;
                agi = 30.0f;
                magicDmg = 15.0f;
                break;
        }
    }

    public void SkillDamage(int skilltype)
    {
        int skill = skilltype;
        switch (skill)
        {
            //Knight Skills
            case 1: //Blood Surge
                {
                    currentDmg = baseDmg;
                    baseDmg = currentDmg + (baseDmg * 0.20f);
                    break;
                }
            case 2: //Cyclone Pass
                {
                    skillDmg = 70 + (agi * 0.25f);
                    break;
                }
            case 3: //Defile Slash
                {
                    skillDmg = 150 + (magicDmg * 0.30f) + (agi * 0.50f);
                    break;
                }

            //Fist Skills
            case 4: //Alacrity Spritz
                {
                    skillDmg = 50 + (agi * 0.28f);
                    break;
                }
            case 5: //Dynamic Jab
                {
                    skillDmg = 65 + (magicDmg * 0.15f);
                    break;
                }
            case 6: //Myriad Strike
                {
                    skillDmg = 105 + (magicDmg * 0.40f) + (agi * 0.45f);
                    break;
                }

            //Mage Skills
            case 7: //Gravel Swain
                {
                    //Summon Golem
                    break;
                }
            case 8: //Outburst
                {
                    skillDmg = 80 + (magicDmg * 0.20f) + (agi * 0.09f);
                    break;
                }
            case 9: //Alleviate Heal
                {
                    //Heal 		
                    break;
                }

            //Hunter Skills
            case 10: //Daze Arrow
                {
                    skillDmg = 30 + (magicDmg * 0.20f);
                    break;
                }
            case 11: //Shaft
                {
                    skillDmg = 60 + (agi * 0.35f);
                    break;
                }
            case 12: //Rain Shower
                {
                    skillDmg = 90 + (magicDmg * 0.35f) + (agi * 0.55f);
                    break;
                }

        }

        dmgSkill = ((level + 2) * magicDmg + skillDmg) / 4;

        //Debug.Log ("Skill Damage " + dmgSkill);
    }

    public float NormalDamage()
    {
        dmgAtk = ((level + 2) * 2 + baseDmg) / 4;

        return dmgAtk;
        //Debug.Log ("Normal Damage : " + dmgAtk);
    }

    public void inflictDamage(float dmg)
    {
        //Debug.Log ("HP: " + HP);
        HP -= dmg;
        //Debug.Log ("HP Left: " + HP);
    }

    // Use this for initialization
    void Start()
    {
        //hpbar = GameObject.FindGameObjectWithTag("EnemyHP");
        //hpbar.SetActive (true);
        EnemyType();
        //SkillDamage (2);
        //NormalDamage ();
        //skills = 2;
        exp = GetComponent<Experience>();
        //dmgAtk = ((level + 2)* 2 +baseDmg)/ 4 ;
        expbar = GameObject.FindGameObjectWithTag("Exp");
        em = GetComponent<EnemyMovement>();

    }

    bool dead;
    // Update is called once per frames
    void Update()
    {

        dead = (HP <= 0) ? true : false;

        if (dead)
            if (GetComponent<EnemyMovement>())
            {
                GetComponent<EnemyMovement>().nav.enabled = false;
            }
            else
                if (GetComponent<MudGolem1>())
                {

                }
        if (instantiateActive == true)
        {
            Vector3 ParticlePosition = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
            if(GolemDeathParticles != null)
                Instantiate(GolemDeathParticles, ParticlePosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            instantiateCounter = 1;
            if (instantiateCounter == 1f)
            {
                instantiateActive = false;
            }
        }
        if (HP < 0)
        {
            //hpbar.SetActive(false);
            //exp.GetComponent<Experience>().getExperience(50);

            instantiateActive = true;
            GolemDeathDelay += Time.deltaTime;

            if (GolemDeathDelay > 0.02f)
            {
                switch (type)
                {
                    case 1:
                        expbar.GetComponent<Experience>().getExperience(30);
                        break;
                    case 4:
                        expbar.GetComponent<Experience>().getExperience(50);
                        break;
                }
                Destroy(this.gameObject);
            }


        }
    }
}
