using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public string JoyNum = "0";
    public KeyCode AttackKey;
    public KeyCode PowerKey;
    public KeyCode SuperKey;
    public KeyCode JumpKey;
    public KeyCode BlockKey;
    public KeyCode RightKey;
    public KeyCode LeftKey;
    public KeyCode UpKey;
    public KeyCode DownKey;


    public bool Attack { get; set; }
    public bool Power { get; set; }
    public bool Super { get; set; }
    public bool Jump { get; set; }
    public bool Block { get; set; }

    public float Horizontal { get; set; }
    public float Vertical { get; set; }

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

    Text DebugText;

    // Use this for initialization
    void Start()
    {
        DebugText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadXbox();
        Keys();
        Movement();
    }

    void Keys()
    {
        if (Input.GetKeyDown(AttackKey) || xbox_x)
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }

        if (Input.GetKeyDown(PowerKey) || xbox_y)
        {
            Power = true;
        }
        else
        {
            Power = false;
        }

        if (Input.GetKey(BlockKey) || xbox_b)
        {
            Block = true;
        }
        else
        {
            Block = false;
        }
    }

    void Movement()
    {
        if (Input.GetKey(RightKey) || xbox_hAxis > 0 || xbox_dhaxis > 0)
        {
            Horizontal = 1;
        }
        else if (Input.GetKey(LeftKey) || xbox_hAxis < 0 || xbox_dhaxis < 0)
        {
            Horizontal = -1;
        }
        else
        {
            Horizontal = 0;
        }

        if (Input.GetKey(UpKey) || xbox_a || xbox_vAxis > 0 || xbox_dvaxis > 0)
        {
            Vertical = 1;
        }
        else if (Input.GetKey(DownKey) || xbox_vAxis < 0 || xbox_dvaxis < 0)
        {
            Vertical = -1;
        }
        else
        {
            Vertical = 0;
        }


    }





    void ReadXbox()
    {
        if(Input.GetJoystickNames().Length == 0)
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

        //if (JoyNum == "1")
        //{
        //    DebugText.text =
        //    string.Format(
        //        "Horizontal: {14:0.000} Vertical: {15:0.000}\n" +
        //        "HorizontalTurn: {16:0.000} VerticalTurn: {17:0.000}\n" +
        //        "LTrigger: {0:0.000} RTrigger: {1:0.000}\n" +
        //        "A: {2} B: {3} X: {4} Y:{5}\n" +
        //        "LB: {6} RB: {7} LS: {8} RS:{9}\n" +
        //        "View: {10} Menu: {11}\n" +
        //        "Dpad-H: {12:0.000} Dpad-V: {13:0.000}\n",
        //        xbox_ltaxis, xbox_rtaxis,
        //        xbox_a, xbox_b, xbox_x, xbox_y,
        //        xbox_lb, xbox_rb, xbox_ls, xbox_rs,
        //        xbox_back, xbox_start,
        //        xbox_dhaxis, xbox_dvaxis,
        //        xbox_hAxis, xbox_vAxis,
        //        xbox_htAxis, xbox_vtAxis);
        //}
    }
}
