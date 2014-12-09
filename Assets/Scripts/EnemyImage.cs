using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyImage : MonoBehaviour {

	public RawImage EnemyIcon;
	public Texture EnemyTexture;
	public string enemyType ;

	// Use this for initialization
	void Start () {
		EnemyIcon = GetComponent<RawImage> ();

	}
	
	// Update is called once per frame
	void Update () {

		EnemyPortrait (enemyType);
		EnemyIcon.texture = EnemyTexture;

	}

	public void EnemyPortrait(string type)
	{
		enemyType = type;

		switch (enemyType) {

		case "Enemy_Golem": //Golem
			EnemyTexture = Resources.Load<Texture>("greygolem");
			break;

		case "Enemy_Golem(Clone)": //Golem
			EnemyTexture = Resources.Load<Texture>("greygolem");
			break;

		case "MudGolem 1": //Taong Lupa
			EnemyTexture = Resources.Load<Texture>("browngolem");
			break;

		case "MudGolem 2": //Taong Lupa
			EnemyTexture = Resources.Load<Texture>("browngolem");
			break;
		
		case "MudGolem 3": //Taong Lupa
			EnemyTexture = Resources.Load<Texture>("browngolem");
			break;

		case "MudGolem 1(Clone)": //Taong Lupa
            EnemyTexture = Resources.Load<Texture>("browngolem");
			break;
			
		case "MudGolem 2(Clone)": //Taong Lupa
            EnemyTexture = Resources.Load<Texture>("browngolem");
			break;
			
		case "MudGolem 3(Clone)": //Taong Lupa
            EnemyTexture = Resources.Load<Texture>("browngolem");
			break;

		case "SpikeMushroom": //Spikes
			EnemyTexture = Resources.Load<Texture>("mashroomspike");
			break;

		case "PurpleMushroom": //Poison
			EnemyTexture = Resources.Load<Texture>("mashroompoison");
			break;

		case "Empty":
			EnemyTexture = Resources.Load<Texture>("Question-mark");
			break;
		}
	}
}
