using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MageSkill1 : MonoBehaviour {
	public GameObject Mage;
	public float skillDmg;

	public Slider enemyHPSlider;
	public GameObject EnemyImage;

	// Use this for initialization
	void Start () {
		Mage = GameObject.Find("Mage");
		//skillDmg = Mage.GetComponent<Movements>().SkillDamage(7);
		skillDmg = 0.3f;
		EnemyImage = Mage.GetComponent<Movements> ().EnemyImage;
		enemyHPSlider = Mage.GetComponent<Movements>().enemyHPSlider;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		
		if(other.gameObject.tag == "Enemy")
		{
			enemyHPSlider.gameObject.SetActive(true);
			EnemyImage.SetActive (true);
			EnemyImage.GetComponent<RawImage>().GetComponent<EnemyImage>().EnemyPortrait(other.gameObject.name);
	
			if(other.gameObject.name == "MudGolem 1")
			{
				other.gameObject.GetComponent<MudGolem1> ().inflictDamage(skillDmg);
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem1>().HP;
			}
			else if(other.gameObject.name == "MudGolem 1(Clone)")
			{
				other.gameObject.GetComponent<MudGolem1> ().inflictDamage(skillDmg);
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem1>().HP;
			}
			
			else if(other.gameObject.name == "MudGolem 2(Clone)")
			{
				other.gameObject.GetComponent<MudGolem2> ().inflictDamage(skillDmg);
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem2>().HP;
			}
			
			else if(other.gameObject.name == "MudGolem 3(Clone)")
			{
				other.gameObject.GetComponent<MudGolem3> ().inflictDamage(skillDmg);
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<MudGolem3>().HP;
			}
			
			else{
				other.gameObject.GetComponent<EnemyChar> ().inflictDamage(skillDmg);
				enemyHPSlider.value =  other.transform.gameObject.GetComponent<EnemyChar>().HP;
				//Debug.Log("DAMAGE: " + enemyHPSlider.value);
			}

		}
		
		
		
		
		
	}
}
