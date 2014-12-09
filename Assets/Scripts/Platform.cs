using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public PlatformType platformType;
    public bool toggle = false;

    public float buildTime;

    public Vector3 originalScale, originalPosition;
    //private float floatbuildTime = 1.0f;
    private Vector3 vel;

    public CharacterManager characterManager;

    public float distance;
    public float maxDistance;

    public enum PlatformType
    {
        Falling,
        Scaling
    }
    void Awake()
    {
        if (platformType == PlatformType.Scaling)
            originalScale = transform.localScale;
        else if (platformType == PlatformType.Falling)
            originalPosition = transform.position;
        else { };
        
    }
	// Use this for initialization
	void Start () {

        characterManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        if (platformType == PlatformType.Scaling)
            this.transform.localScale = new Vector3(0, 0, 0);
        else if (platformType == PlatformType.Falling)
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 15.0f, transform.position.z);
        else { };

	}

    
	
	// Update is called once per frame
	void Update () {
        
        


        if (platformType == PlatformType.Scaling)
        {
            distance = Vector3.Distance(this.transform.position, characterManager.selectedLeader.transform.position);
        }
        else if (platformType == PlatformType.Falling)
        {
            distance = Vector3.Distance(originalPosition, characterManager.selectedLeader.transform.position);
        }
        else { }


        if (toggle)
        {
            if (platformType == PlatformType.Scaling)
            {
                transform.localScale = Vector3.SmoothDamp(this.transform.localScale, originalScale, ref vel, buildTime);
            }
            else if (platformType == PlatformType.Falling)
            {
                transform.position = Vector3.SmoothDamp(this.transform.position, originalPosition, ref vel, buildTime);
            }
            else { };
        }

        if (distance <= maxDistance)
            toggle = true;
	
	}
}
