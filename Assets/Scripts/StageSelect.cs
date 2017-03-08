using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    public GameObject[] stageselect;
    public static int stageindex;

    [HideInInspector]
    public bool HorizPress;
    [HideInInspector]
    public bool VertPress;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        if (!HorizPress)
        {
            if (Input.GetAxis("Horizontal") > 0.25f)
            {
                stageindex = stageindex + 1;
                HorizPress = true;
            }
            if (Input.GetAxis("Horizontal") < -0.25f)
            {
                stageindex = stageindex - 1;
                HorizPress = true;
            }
            if (stageindex >= stageselect.Length)
            {
                stageindex = stageselect.Length - 1;
            }
            if (stageindex < 0)
            {
                stageindex = 0;
            }
        }
        if (HorizPress)
        {
            if (Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
            {
                HorizPress = false;
            }
        }
        if (!VertPress)
        {
            if (Input.GetAxis("Vertical") > 0.25f)
            {
                stageindex = stageindex - 2;
                VertPress = true;
            }
            if (Input.GetAxis("Vertical") < -0.25f)
            {
                stageindex = stageindex + 2;
                VertPress = true;
            }
            if (stageindex >= stageselect.Length)
            {
                stageindex = stageselect.Length - 1;
            }
            if (stageindex < 0)
                stageindex = 0;
        }
        if (VertPress)
        {
            if (Input.GetAxis("Vertical") < 0.25f && Input.GetAxis("Vertical") > -0.25f)
            {
                VertPress = false;
            }
        }

        transform.position = Vector3.MoveTowards((transform.position), stageselect[stageindex].transform.position, Speed * Time.deltaTime);

        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("battle");
        }
    }
}

