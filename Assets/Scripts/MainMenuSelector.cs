using UnityEngine;
using System.Collections;

public class MainMenuSelector : MonoBehaviour {
    
    public GameObject[] choices;
    public GameObject identifier;
    bool axisNotMoving;
    int selectedChoice;
    Vector3 refVel;

	// Use this for initialization
	void Start () {
	
	}

    void ChangeSelections()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if(axisNotMoving)
            {
                selectedChoice++;
                axisNotMoving = false;
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            if (axisNotMoving)
            {
                selectedChoice--;
                axisNotMoving = false;
            }
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (axisNotMoving)
            {
                selectedChoice++;
                axisNotMoving = false;
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (axisNotMoving)
            {
                selectedChoice--;
                axisNotMoving = false;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            axisNotMoving = true;

        if (selectedChoice > choices.Length - 1)
            selectedChoice = choices.Length - 1;
        if (selectedChoice <= 0)
            selectedChoice = 0;
    }

    float width;
    float refVelf;
	// Update is called once per frame
	void Update () {

        ChangeSelections();

        identifier.transform.position = Vector3.SmoothDamp(identifier.transform.localPosition, 
            choices[selectedChoice].transform.localPosition - new Vector3(0, 0, -0.1f), 
            ref refVel, 
            0.1f);
        width = Mathf.SmoothDamp(width, choices[selectedChoice].transform.localScale.x, ref refVelf, 0.1f);
        identifier.transform.localScale = new Vector3(width, identifier.transform.localScale.y, 0.01f);

        if (Input.GetButtonDown("Skill 3") || Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectedChoice)
            {
                case 0:
                    Application.LoadLevel(1);
                    break;
                case 1:
                    Application.LoadLevel(2);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    
    }
}
