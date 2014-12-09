using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Experience : MonoBehaviour {
	public float exp, totalexp;
	public Slider expSlider;
	public int level;
	public float tempexp;
	public GameObject levelup;
	float counter = 0;
	public bool statup = false;

	public bool isLevelup = false;
	// Use this for initialization
	void Start () {
		expSlider = GetComponent<Slider> ();
		level = 1;
		exp = 0;
		totalexp = 150;

		expSlider.maxValue = totalexp;

		levelup = GameObject.Find("Levelup");

		levelup.SetActive (false);
	}
	 	 
	// Update is called once per frame
	void Update () {


	if (expSlider.value >= totalexp) {
						tempexp = totalexp;
						level += 1;
						expSlider.minValue = tempexp;
						totalexp += tempexp * 0.7f;
						expSlider.maxValue = totalexp;
			isLevelup = true;
				}
		if (isLevelup)
					LevelUp ();

		//getExperience (0.1f);
		//Debug.Log ("counter = " + counter);
	}

	void LevelUp()
	{
		statup = true;
		counter += Time.deltaTime;
		if (counter < 3) {
						levelup.SetActive (true);
				}
		//levelup.SetActive(false);
		else if (counter > 3){
			counter = 0;
			levelup.SetActive(false);
			isLevelup = false;
				}
	}

	public void getExperience(float expget)
	{	
		expSlider.value += ((2 * Mathf.Pow (level, 3) + 9 * Mathf.Pow (level, 2) + expget * level)/6);
		//Debug.Log("Exp Get: " + expget + "Exp Total " + exp "/" +expSlider.maxValue);
	}

}
