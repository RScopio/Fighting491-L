using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {
    public GameObject[] stageselect;
    public static int stageindex;
    public int speed;
    public float fireRate;
    public float nextFire;
 
    public bool ispress;
    public bool ispressb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!ispress)
        {
            if (Input.GetAxis("Horizontal") > 0.25f)
            {

                stageindex = stageindex + 1;
                ispress = true;
            }
           


            if (Input.GetAxis("Horizontal") < -0.25f)
            {

                stageindex = stageindex - 1;
                ispress = true;
            }


           

            if (stageindex >= stageselect.Length) {

                stageindex = stageselect.Length-1;
            }
            if (stageindex < 0)
                stageindex = 0;


        }






        if (ispress)
        {

            if (Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
            {

                ispress = false;
            }
        }



            if (!ispressb) {




                if (Input.GetAxis("Vertical") > 0.25f)
                {

                    stageindex = stageindex - 2;
                    ispressb = true;
                }



                if (Input.GetAxis("Vertical") < -0.25f)
                {

                    stageindex = stageindex + 2;
                    ispressb = true;
                }






            if (stageindex >= stageselect.Length)
            {

                stageindex = stageselect.Length - 1;
            }
            if (stageindex < 0)
                stageindex = 0;




        }


        if (ispressb)
        {

            if (Input.GetAxis("Vertical") < 0.25f && Input.GetAxis("Vertical") > -0.25f)
            {

                ispressb = false;
            }


        }




                transform.position = Vector3.MoveTowards((transform.position), stageselect[stageindex].transform.position, speed * Time.deltaTime);

        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump")) {


            SceneManager.LoadScene("battle");

        }
    }

        }

