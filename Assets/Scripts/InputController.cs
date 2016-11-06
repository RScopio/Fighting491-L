using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
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

        if (Input.GetKey(BlockKey) || xbox_rb)
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
        if (Input.GetKey(RightKey) || xbox_hAxis > 0)
        {
            Horizontal = 1;
        }
        else if (Input.GetKey(LeftKey) || xbox_hAxis < 0)
        {
            Horizontal = -1;
        }
        else
        {
            Horizontal = 0;
        }

        if (Input.GetKey(UpKey) || xbox_a || xbox_vAxis > 0)
        {
            Vertical = 1;
        }
        else if (Input.GetKey(DownKey) || xbox_vAxis < 0)
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
        xbox_hAxis = Input.GetAxis("Horizontal");
        xbox_vAxis = Input.GetAxis("Vertical");
        //xbox_aAxis = Input.GetAxis("Altitude");
        xbox_htAxis = Input.GetAxis("HorizontalTurn");
        xbox_vtAxis = Input.GetAxis("VerticalTurn");

        xbox_ltaxis = Input.GetAxis("XboxLeftTrigger");
        xbox_rtaxis = Input.GetAxis("XboxRightTrigger");
        xbox_dhaxis = Input.GetAxis("XboxDpadHorizontal");
        xbox_dvaxis = Input.GetAxis("XboxDpadVertical");

        xbox_a = Input.GetButton("XboxA");
        xbox_b = Input.GetButton("XboxB");
        xbox_x = Input.GetButton("XboxX");
        xbox_y = Input.GetButton("XboxY");
        xbox_lb = Input.GetButton("XboxLB");
        xbox_rb = Input.GetButton("XboxRB");
        xbox_ls = Input.GetButton("XboxLS");
        xbox_rs = Input.GetButton("XboxRS");
        xbox_back = Input.GetButton("XboxBack");
        xbox_start = Input.GetButton("XboxStart");

        DebugText.text =
        string.Format(
            "Horizontal: {14:0.000} Vertical: {15:0.000}\n" +
            "HorizontalTurn: {16:0.000} VerticalTurn: {17:0.000}\n" +
            "LTrigger: {0:0.000} RTrigger: {1:0.000}\n" +
            "A: {2} B: {3} X: {4} Y:{5}\n" +
            "LB: {6} RB: {7} LS: {8} RS:{9}\n" +
            "View: {10} Menu: {11}\n" +
            "Dpad-H: {12:0.000} Dpad-V: {13:0.000}\n",
            xbox_ltaxis, xbox_rtaxis,
            xbox_a, xbox_b, xbox_x, xbox_y,
            xbox_lb, xbox_rb, xbox_ls, xbox_rs,
            xbox_back, xbox_start,
            xbox_dhaxis, xbox_dvaxis,
            xbox_hAxis, xbox_vAxis,
            xbox_htAxis, xbox_vtAxis);
    }
}
