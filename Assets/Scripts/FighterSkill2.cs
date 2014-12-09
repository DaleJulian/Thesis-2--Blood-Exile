using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FighterSkill2 : MonoBehaviour {
	
	
	public float damage;
	public float skillDmg;
	public GameObject EnemyImage;
	private GameObject enemyHealthObject;
	public Slider enemyHPSlider;
	public GameObject Fighter;
	
	// Use this for initialization
	void Awake()
	{
		Fighter = GameObject.Find ("Fighter");
		
	}
	void Start () {
		//Mage.GetComponent<Movements> ().Hit();
		//EnemyImage = GameObject.Find ("EnemyImage");
		skillDmg = Fighter.GetComponent<Movements> ().SkillDamage(5);
		EnemyImage = Fighter.GetComponent<Movements> ().EnemyImage;
		//enemyHPSlider = GameObject.Find("EnemyHealth").GetComponent<Slider>();
		enemyHPSlider = Fighter.GetComponent<Movements>().enemyHPSlider;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		
				if (other.gameObject.tag == "Enemy") {

						enemyHPSlider.gameObject.SetActive (true);
						EnemyImage.SetActive (true);
						EnemyImage.GetComponent<RawImage> ().GetComponent<EnemyImage> ().EnemyPortrait (other.gameObject.name);
			
						if (other.gameObject.name == "MudGolem 1") {
								other.gameObject.GetComponent<MudGolem1> ().inflictDamage (skillDmg);
								enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1> ().maxHp;
								enemyHPSlider.value = other.transform.gameObject.GetComponent<MudGolem1> ().HP;
						} else if (other.gameObject.name == "MudGolem 1(Clone)") {
								other.gameObject.GetComponent<MudGolem1> ().inflictDamage (skillDmg);
								enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1> ().maxHp;
								enemyHPSlider.value = other.transform.gameObject.GetComponent<MudGolem1> ().HP;
						} else if (other.gameObject.name == "MudGolem 2(Clone)") {
								other.gameObject.GetComponent<MudGolem2> ().inflictDamage (skillDmg);
								enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1> ().maxHp;
								enemyHPSlider.value = other.transform.gameObject.GetComponent<MudGolem2> ().HP;
						} else if (other.gameObject.name == "MudGolem 3(Clone)") {
								other.gameObject.GetComponent<MudGolem3> ().inflictDamage (skillDmg);
								enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1> ().maxHp;
								enemyHPSlider.value = other.transform.gameObject.GetComponent<MudGolem3> ().HP;
						} else {
								other.gameObject.GetComponent<EnemyChar> ().inflictDamage (skillDmg);
								enemyHPSlider.maxValue = other.transform.gameObject.GetComponent<MudGolem1> ().maxHp;
								enemyHPSlider.value = other.transform.gameObject.GetComponent<EnemyChar> ().HP;
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
