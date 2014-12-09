using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MageNormalAttack : MonoBehaviour {

    public float speed = 0.5f;
    public float damage;
	public float mageDmg;
	public GameObject EnemyImage;
	private GameObject enemyHealthObject;
	public Slider enemyHPSlider;
	public GameObject Mage;

	// Use this for initialization
	void Awake()
	{
		Mage = GameObject.Find ("Mage");
	
	}
	void Start () {
		mageDmg = GameObject.Find ("Mage").GetComponent<Movements> ().NormalDamage ();
		//Mage.GetComponent<Movements> ().Hit();
		//EnemyImage = GameObject.Find ("EnemyImage");
		EnemyImage = Mage.GetComponent<Movements> ().EnemyImage;
		//enemyHPSlider = GameObject.Find("EnemyHealth").GetComponent<Slider>();
		enemyHPSlider = Mage.GetComponent<Movements>().enemyHPSlider;
	}

    void OnTriggerEnter(Collider collide)
    {
        if(collide.gameObject.tag == "Enemy")
        {
            Debug.Log(collide.gameObject.name);
			enemyHPSlider.gameObject.SetActive(true);
			EnemyImage.SetActive (true);
			EnemyImage.GetComponent<RawImage>().GetComponent<EnemyImage>().EnemyPortrait(collide.gameObject.name);
			
			if(collide.gameObject.name == "MudGolem 1")		
			{		
				collide.transform.gameObject.GetComponent<MudGolem1>().inflictDamage(mageDmg);
				enemyHPSlider.maxValue = collide.transform.gameObject.GetComponent<MudGolem1>().maxHp;	
				enemyHPSlider.value = collide.transform.gameObject.GetComponent<MudGolem1>().HP;		
			}	
			if(collide.gameObject.name == "MudGolem 1(Clone)")		
			{		
				collide.transform.gameObject.GetComponent<MudGolem1>().inflictDamage(mageDmg);
				enemyHPSlider.maxValue = collide.transform.gameObject.GetComponent<MudGolem1>().maxHp;	
				enemyHPSlider.value = collide.transform.gameObject.GetComponent<MudGolem1>().HP;		
			}	
			
			else if(collide.gameObject.name == "MudGolem 2(Clone)")		
			{		
				collide.transform.gameObject.GetComponent<MudGolem2>().inflictDamage(mageDmg);	
				enemyHPSlider.maxValue = collide.transform.gameObject.GetComponent<MudGolem2>().maxHp;	
				enemyHPSlider.value = collide.transform.gameObject.GetComponent<MudGolem2>().HP;		
			}		
			
			else if(collide.gameObject.name == "MudGolem 3(Clone)")		
			{		
				collide.transform.gameObject.GetComponent<MudGolem3>().inflictDamage(mageDmg);	
				enemyHPSlider.maxValue = collide.transform.gameObject.GetComponent<MudGolem3>().maxHp;	
				enemyHPSlider.value = collide.transform.gameObject.GetComponent<MudGolem3>().HP;		
			}		
			
			else{		
				collide.transform.gameObject.GetComponent<EnemyChar>().inflictDamage(mageDmg);	
				enemyHPSlider.maxValue = collide.transform.gameObject.GetComponent<EnemyChar>().maxHp;	
				enemyHPSlider.value = collide.transform.gameObject.GetComponent<EnemyChar>().HP;		
				//Debug.Log("DAMAGE: " + enemyHPSlider.value);		
			}
        }
        
	}	

	// Update is called once per frame
	void Update () {

		if (enemyHPSlider.value <= 0) {
			enemyHPSlider.gameObject.SetActive(false);	
			EnemyImage.SetActive(false);
		}


        //transform.Translate(transform.forward * speed);

	}
}
