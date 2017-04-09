using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoomCamera : MonoBehaviour
{
    private struct Boundry
    {
        public float Left;
        public float Right;
        public float Top;
        public float Bottom;
    }

    private List<GameObject> players;
    private bool active = false;
    private Vector3 midPoint;
    private Vector3 offset;
    private float distance = 1f;
    private GameObject background;
    private Boundry back;

    public void Initialize()
    {
        players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        players.AddRange(GameObject.FindGameObjectsWithTag("AI"));

        if (players.Count == 2)
        {
            active = true;
            midPoint = new Vector3(
                  (players[0].transform.position.x + players[1].transform.position.x) / 2.0f
                , (players[0].transform.position.y + players[1].transform.position.y) / 2.0f
                , (players[0].transform.position.z + players[1].transform.position.z) / 2.0f
                );

            offset = transform.position - midPoint;
            background = GameObject.FindGameObjectWithTag("Background");

            back.Left = background.transform.position.x - background.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            back.Right = background.transform.position.x + background.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            back.Top = background.transform.position.y + background.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            back.Bottom = background.transform.position.y - background.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            distance = Vector3.Distance(players[0].transform.position, players[1].transform.position);
            midPoint = new Vector3(
                  (players[0].transform.position.x + players[1].transform.position.x) / 2.0f
                , (players[0].transform.position.y + players[1].transform.position.y) / 2.0f
                , (players[0].transform.position.z + players[1].transform.position.z) / 2.0f
                );
        }
    }

    private void LateUpdate()
    {
        if (active)
        {
            var vertExtent = Camera.main.orthographicSize;
            var horzExtent = vertExtent * Screen.width / Screen.height;
            transform.position = new Vector3(Mathf.Clamp(midPoint.x + offset.x, back.Left + horzExtent, back.Right - horzExtent), transform.position.y, transform.position.z);
            //Camera.main.orthographicSize = Mathf.Clamp(distance, 5, 7.937309f);
        }
    }
}
