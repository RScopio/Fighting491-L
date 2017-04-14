using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XboxMenuInput : MonoBehaviour
{

    private string LeftJoyNum = "1";
    private string RightJoyNum = "2";

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
    private int highlightedButtonLeft;
    private int highlightedButtonRight;
    bool allowMovementLeft = false;
    bool allowMovementRight = false;

    private int leftPlayerSelected = -1;
    private int rightPlayerSelected = -1;

    private Color leftColor = new Color(0, 0, 10);
    private Color rightColor = new Color(10, 0, 0);


    // Update is called once per frame
    void Update()
    {
        if (Input.GetJoystickNames().Length != 0)
        {
            ReadXbox(LeftJoyNum);

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

                if (allowMovementLeft && (xbox_vAxis > 0 || xbox_dvaxis > 0))
                {
                    //up 
                    allowMovementLeft = false;
                    highlightedButtonLeft--;
                    if (highlightedButtonLeft < 0)
                    {
                        highlightedButtonLeft = Buttons.Length - 1;
                    }
                }
                else if (allowMovementLeft && (xbox_vAxis < 0 || xbox_dvaxis < 0))
                {
                    allowMovementLeft = false;
                    //down
                    highlightedButtonLeft++;
                    if (highlightedButtonLeft >= Buttons.Length)
                    {
                        highlightedButtonLeft = 0;
                    }
                }
                else if (!allowMovementLeft && xbox_vAxis == 0 && xbox_dvaxis == 0)
                {
                    allowMovementLeft = true;
                }

                Buttons[highlightedButtonLeft].Select();

                if (xbox_a)
                {
                    Buttons[highlightedButtonLeft].onClick.Invoke();
                }
            }
            #endregion
            #region StageSelect
            if (CurrentScreen == Screen.StageSelect)
            {
                if (allowMovementLeft && (xbox_hAxis > 0 || xbox_dhaxis > 0 || xbox_vAxis < 0 || xbox_dvaxis < 0))
                {
                    //right
                    allowMovementLeft = false;
                    highlightedButtonLeft++;
                    if (highlightedButtonLeft >= Buttons.Length)
                    {
                        highlightedButtonLeft = 0;
                    }
                }
                else if (allowMovementLeft && (xbox_hAxis < 0 || xbox_dhaxis < 0 || xbox_vAxis > 0 || xbox_dvaxis > 0))
                {
                    //left
                    allowMovementLeft = false;
                    highlightedButtonLeft--;
                    if (highlightedButtonLeft < 0)
                    {
                        highlightedButtonLeft = Buttons.Length - 1;
                    }
                }
                else if (!allowMovementLeft && xbox_hAxis == 0 && xbox_dhaxis == 0 && xbox_vAxis == 0 && xbox_dvaxis == 0)
                {
                    allowMovementLeft = true;
                }

                Buttons[highlightedButtonLeft].Select();

                if (xbox_a)
                {
                    Buttons[highlightedButtonLeft].onClick.Invoke();
                }
            }
            #endregion

            CharacterSelectLeft();
            if (Input.GetJoystickNames().Length == 2 && GameObject.Find("GameController").GetComponent<StageInfo>().GameMode == StageInfo.GameType.Local)
            {
                ReadXbox(RightJoyNum);
                CharacterSelectRight();
            }

        }
    }

    void CharacterSelectLeft()
    {
        #region CharacterSelect
        if (CurrentScreen == Screen.CharacterSelect)
        {
            Buttons[highlightedButtonLeft].image.color = Color.white;
            if (allowMovementLeft && (xbox_hAxis > 0 || xbox_dhaxis > 0))
            {
                //right
                allowMovementLeft = false;
                highlightedButtonLeft++;
                if (highlightedButtonLeft >= 4)
                {
                    highlightedButtonLeft = 0;
                }
            }
            else if (allowMovementLeft && (xbox_hAxis < 0 || xbox_dhaxis < 0))
            {
                //left
                allowMovementLeft = false;
                highlightedButtonLeft--;
                if (highlightedButtonLeft < 0)
                {
                    highlightedButtonLeft = 3;
                }
            }
            //else if (allowMovementLeft && (xbox_vAxis > 0 || xbox_dvaxis > 0))
            //{
            //    //up
            //    highlightedButtonLeft = 4;
            //}
            //else if (allowMovementLeft && (xbox_vAxis < 0 || xbox_dvaxis < 0))
            //{
            //    //down
            //    highlightedButtonLeft = 0;
            //}
            else if (!allowMovementLeft && xbox_hAxis == 0 && xbox_dhaxis == 0 && xbox_vAxis == 0 && xbox_dvaxis == 0)
            {
                allowMovementLeft = true;
            }


            Buttons[highlightedButtonLeft].Select();
            Buttons[highlightedButtonLeft].image.color = leftColor;

            if (xbox_a)
            {
                if (leftPlayerSelected >= 0)
                {
                    Buttons[leftPlayerSelected].image.color = Color.white;
                }
                CharacterSelectionAction setPlayer = Buttons[highlightedButtonLeft].GetComponent<CharacterSelectionAction>();
                if (setPlayer) { setPlayer.SetPlayerLeft(); }
                Buttons[highlightedButtonLeft].onClick.Invoke();
                leftPlayerSelected = highlightedButtonLeft;

            }

            if (xbox_start)
            {
                Buttons[Buttons.Length - 1].onClick.Invoke();
            }

            if (leftPlayerSelected >= 0)
            {
                Buttons[leftPlayerSelected].image.color = leftColor;
            }
        }
        #endregion
    }
    void CharacterSelectRight()
    {
        #region CharacterSelect
        if (CurrentScreen == Screen.CharacterSelect)
        {
            Buttons[highlightedButtonRight].image.color = Color.white;
            if (allowMovementRight && (xbox_hAxis > 0 || xbox_dhaxis > 0))
            {
                //right
                allowMovementRight = false;
                highlightedButtonRight++;
                if (highlightedButtonRight >= 4)
                {
                    highlightedButtonRight = 0;
                }
            }
            else if (allowMovementRight && (xbox_hAxis < 0 || xbox_dhaxis < 0))
            {
                //left
                allowMovementRight = false;
                highlightedButtonRight--;
                if (highlightedButtonRight < 0)
                {
                    highlightedButtonRight = 3;
                }
            }
            else if (!allowMovementRight && xbox_hAxis == 0 && xbox_dhaxis == 0 && xbox_vAxis == 0 && xbox_dvaxis == 0)
            {
                allowMovementRight = true;
            }


            Buttons[highlightedButtonRight].Select();
            Buttons[highlightedButtonRight].image.color = rightColor;

            if (xbox_a)
            {
                if (rightPlayerSelected >= 0)
                {
                    Buttons[rightPlayerSelected].image.color = Color.white;
                }
                Buttons[highlightedButtonRight].GetComponent<CharacterSelectionAction>().SetPlayerRight();
                Buttons[highlightedButtonRight].onClick.Invoke();
                rightPlayerSelected = highlightedButtonRight;

            }

            if (rightPlayerSelected >= 0)
            {
                Buttons[rightPlayerSelected].image.color = rightColor;
            }
        }
        #endregion
    }
    void ReadXbox(string JoyNum)
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
