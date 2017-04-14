using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XboxMenuInput : MonoBehaviour
{

    public string JoyNum = "1";

    //controller input
    float xbox_hAxis;
    float xbox_vAxis;
    //float xbox_aAxis;
    float xbox_htAxis;
    float xbox_vtAxis;

    float xbox_ltaxis;
    float xbox_rtaxis;
    float xbox_dhaxis;
    float xbox_dvaxis;

    bool xbox_a;
    bool xbox_b;
    bool xbox_x;
    bool xbox_y;
    bool xbox_lb;
    bool xbox_rb;
    bool xbox_ls;
    bool xbox_rs;
    bool xbox_back;
    bool xbox_start;

    public enum Screen
    {
        Title,
        MainMenu,
        CharacterSelect,
        StageSelect
    }

    public Screen CurrentScreen;


    public Button PlayButton;
    public Button[] Buttons = new Button[6];
    private int selectedButton;
    bool allowMovement = false;


    // Update is called once per frame
    void Update()
    {
        ReadXbox();

        #region Title
        if (CurrentScreen == Screen.Title)
        {
            if (xbox_a)
            {
                PlayButton.onClick.Invoke();
            }
        }

        if (CurrentScreen == Screen.MainMenu)
        {

            if (allowMovement && (xbox_vAxis > 0 || xbox_dvaxis > 0))
            {
                //up 
                allowMovement = false;
                selectedButton--;
                if (selectedButton < 0)
                {
                    selectedButton = Buttons.Length - 1;
                }
            }
            else if (allowMovement && (xbox_vAxis < 0 || xbox_dvaxis < 0))
            {
                allowMovement = false;
                //down
                selectedButton++;
                if (selectedButton >= Buttons.Length)
                {
                    selectedButton = 0;
                }
            }
            else if (!allowMovement && xbox_vAxis == 0 && xbox_dvaxis == 0)
            {
                allowMovement = true;
            }

            Buttons[selectedButton].Select();

            if (xbox_a)
            {
                Buttons[selectedButton].onClick.Invoke();
            }
        }
        #endregion
        #region CharacterSelect
        if (CurrentScreen == Screen.CharacterSelect)
        {
            if (allowMovement && (xbox_hAxis > 0 || xbox_dhaxis > 0))
            {
                //right
                allowMovement = false;
                selectedButton++;
                if (selectedButton >= 4)
                {
                    selectedButton = 0;
                }
            }
            else if (allowMovement && (xbox_hAxis < 0 || xbox_dhaxis < 0))
            {
                //left
                allowMovement = false;
                selectedButton--;
                if (selectedButton < 0)
                {
                    selectedButton = 3;
                }
            }
            else if (allowMovement && (xbox_vAxis > 0 || xbox_dvaxis > 0))
            {
                //up
                selectedButton = 4;
            }
            else if (allowMovement && (xbox_vAxis < 0 || xbox_dvaxis < 0))
            {
                //down
                selectedButton = 0;
            }
            else if (!allowMovement && xbox_hAxis == 0 && xbox_dhaxis == 0 && xbox_vAxis == 0 && xbox_dvaxis == 0)
            {
                allowMovement = true;
            }


            Buttons[selectedButton].Select();

            if (xbox_a)
            {
                Buttons[selectedButton].onClick.Invoke();
            }
        }
        #endregion
        #region StageSelect
        if (CurrentScreen == Screen.StageSelect)
        {
            if (allowMovement && (xbox_hAxis > 0 || xbox_dhaxis > 0 || xbox_vAxis < 0 || xbox_dvaxis < 0))
            {
                //right
                allowMovement = false;
                selectedButton++;
                if (selectedButton >= Buttons.Length)
                {
                    selectedButton = 0;
                }
            }
            else if (allowMovement && (xbox_hAxis < 0 || xbox_dhaxis < 0 || xbox_vAxis > 0 || xbox_dvaxis > 0))
            {
                //left
                allowMovement = false;
                selectedButton--;
                if (selectedButton < 0)
                {
                    selectedButton = Buttons.Length - 1;
                }
            }
            else if (!allowMovement && xbox_hAxis == 0 && xbox_dhaxis == 0 && xbox_vAxis == 0 && xbox_dvaxis == 0)
            {
                allowMovement = true;
            }

            Buttons[selectedButton].Select();

            if (xbox_a)
            {
                Buttons[selectedButton].onClick.Invoke();
            }
        }
        #endregion

    }

    void ReadXbox()
    {
        if (Input.GetJoystickNames().Length == 0)
        {
            return;
        }
        xbox_hAxis = Input.GetAxis("Joy" + JoyNum + "_Horizontal");
        xbox_vAxis = Input.GetAxis("Joy" + JoyNum + "_Vertical");
        //xbox_aAxis = Input.GetAxis("Joy"+JoyNum+"_Altitude");
        xbox_htAxis = Input.GetAxis("Joy" + JoyNum + "_HorizontalTurn");
        xbox_vtAxis = Input.GetAxis("Joy" + JoyNum + "_VerticalTurn");

        xbox_ltaxis = Input.GetAxis("Joy" + JoyNum + "_XboxLeftTrigger");
        xbox_rtaxis = Input.GetAxis("Joy" + JoyNum + "_XboxRightTrigger");
        xbox_dhaxis = Input.GetAxis("Joy" + JoyNum + "_XboxDpadHorizontal");
        xbox_dvaxis = Input.GetAxis("Joy" + JoyNum + "_XboxDpadVertical");

        xbox_a = Input.GetButton("Joy" + JoyNum + "_XboxA");
        xbox_b = Input.GetButton("Joy" + JoyNum + "_XboxB");
        xbox_x = Input.GetButton("Joy" + JoyNum + "_XboxX");
        xbox_y = Input.GetButton("Joy" + JoyNum + "_XboxY");
        xbox_lb = Input.GetButton("Joy" + JoyNum + "_XboxLB");
        xbox_rb = Input.GetButton("Joy" + JoyNum + "_XboxRB");
        xbox_ls = Input.GetButton("Joy" + JoyNum + "_XboxLS");
        xbox_rs = Input.GetButton("Joy" + JoyNum + "_XboxRS");
        xbox_back = Input.GetButton("Joy" + JoyNum + "_XboxBack");
        xbox_start = Input.GetButton("Joy" + JoyNum + "_XboxStart");

    }
}
