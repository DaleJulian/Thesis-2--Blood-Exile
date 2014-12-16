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
				switch (type) {
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
						{
								maxHp = 20;
								HP = 20;
								baseDmg = 35.0f;
								def = 4.0f;
								agi = 1.0f;
								magicDmg = 25.0f;
								break;
						}

				case 10: //SkeletonSwordsman
						{
								maxHp = 35;
								HP = 35;
								baseDmg = 15.0f;
								def = 8.0f;
								agi = 1.0f;
								magicDmg = 5.0f;
								break;
						}
				}
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
					case 9:
						expbar.GetComponent<Experience>().getExperience(50);
						break;
					case 10:
						expbar.GetComponent<Experience>().getExperience(50);
						break;
                }
                Destroy(this.gameObject);
            }


        }
    }
}
