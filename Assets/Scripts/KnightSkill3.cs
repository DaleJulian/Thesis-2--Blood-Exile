using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KnightSkill3 : MonoBehaviour {
	public GameObject Knight;
	public float skillDmg;
	
	public Slider enemyHPSlider;
	public GameObject EnemyImage;
	
	// Use this for initialization
	void Start () {
		Knight = GameObject.Find("Knight");
		//skillDmg = Mage.GetComponent<Movements>().SkillDamage(7);
		skillDmg = Knight.GetComponent<Movements>().SkillDamage(3);
		//skillDmg = 1;
		EnemyImage = Knight.GetComponent<Movements> ().EnemyImage;
		enemyHPSlider = Knight.GetComponent<Movements>().enemyHPSlider;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHPSlider.value <= 0) {
			enemyHPSlider.gameObject.SetActive(false);	
			EnemyImage.SetActive(false);
		}
		
	}
	
	void OnTriggerEnter(Collider other) 
	{
		
		if(other.gameObject.tag == "Enemy" && Knight.GetComponent<Movements>().isSkillCooldown3==true)
		{
			enemyHPSlider.gameObject.SetActive(true);
			EnemyImage.SetActive (true);
			EnemyImage.GetComponent<RawImage>().GetComponent<EnemyImage>().EnemyPortrait(other.gameObject.name);
			
			if(other.gameObject.name == "MudGolem 1")
			{
				other.gameObject.GetComponent<MudGolem1> ().inflictDamage(skillDmg);
				enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1>().maxHp;
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem1>().HP;
			}
			else if(other.gameObject.name == "MudGolem 1(Clone)")
			{
				other.gameObject.GetComponent<MudGolem1> ().inflictDamage(skillDmg);
				enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1>().maxHp;
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem1>().HP;
			}
			
			else if(other.gameObject.name == "MudGolem 2(Clone)")
			{
				other.gameObject.GetComponent<MudGolem2> ().inflictDamage(skillDmg);
				enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1>().maxHp;
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem2>().HP;
			}
			
			else if(other.gameObject.name == "MudGolem 3(Clone)")
			{
				other.gameObject.GetComponent<MudGolem3> ().inflictDamage(skillDmg);
				enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1>().maxHp;
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem3>().HP;
			}
			
			else{
				other.gameObject.GetComponent<EnemyChar> ().inflictDamage(skillDmg);
				enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1>().maxHp;
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<EnemyChar>().HP;
				//Debug.Log("DAMAGE: " + enemyHPSlider.value);
			}
			
		}
		
		
		
		
		
	}
}
