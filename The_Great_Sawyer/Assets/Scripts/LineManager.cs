using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro.Examples;

public class LineManager : MonoBehaviour
{
    private Camera _camera;

    public GameObject player;
    public Tilemap target;
    public Tilemap[] NPCTiles;
    public Button button;
    public Text text;
    public Text commuBox;

    public Vector3Int playerPos;
    private string npcLocation;

    private Vector3Int up;
    private Vector3Int down;
    private Vector3Int left;
    private Vector3Int right;

    public GameObject scriptBox;
    public GameObject endCursor;
    private int scriptStack;
    private bool isCommunicating;
    // Start is called before the first frame update
    void Start()
    {
        scriptStack = 0;
        endCursor.SetActive(false);
        isCommunicating = false;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        int rand = PathFinder.Instance.rand;
        target = NPCTiles[rand];
        playerPos = target.WorldToCell(player.transform.position);
        up = new Vector3Int(playerPos.x + 1, playerPos.y, 0);
        down = new Vector3Int(playerPos.x - 1, playerPos.y, 0);
        left = new Vector3Int(playerPos.x, playerPos.y + 1, 0);
        right = new Vector3Int(playerPos.x, playerPos.y - 1, 0);

        if (target.HasTile(up))
        {
            button.interactable = true;
            text.text = "대화하기";
            npcLocation = "up";
        }
        else if (target.HasTile(down))
        {
            button.interactable = true;
            text.text = "대화하기";
            npcLocation = "down";
        }
        else if (target.HasTile(left))
        {
            button.interactable = true;
            text.text = "대화하기";
            npcLocation = "left";
        }
        else if (target.HasTile(right))
        {
            button.interactable = true;
            text.text = "대화하기";
            npcLocation = "right";
        }
        else
        {
            button.interactable = false;
            text.text = "주변에 아무것도 없습니다.";
            npcLocation = "none";
        }

        if (Input.GetMouseButtonUp(0) && isCommunicating)
        {
            scriptStack++;
        }
    }

    public void Communicate()
    {
        if (npcLocation != "none")
        {
            if (npcLocation == "up")
            {
                Vector3 loc = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, -10);
                _camera.DOOrthoSize(3, 0.5f).SetEase(Ease.InOutSine);
                if (!isCommunicating) _camera.transform.DOMove(loc, 0.5f).SetEase(Ease.InOutSine);
                Liner(up);
            }
            else if (npcLocation == "down")
            {
                Vector3 loc = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, -10);
                _camera.DOOrthoSize(3, 0.5f).SetEase(Ease.InOutSine);
                if (!isCommunicating) _camera.transform.DOMove(loc, 0.5f).SetEase(Ease.InOutSine);
                Liner(down);
            }
            else if (npcLocation == "left")
            {
                Vector3 loc = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, -10);
                _camera.DOOrthoSize(3, 0.5f).SetEase(Ease.InOutSine);
                if (!isCommunicating) _camera.transform.DOMove(loc, 0.5f).SetEase(Ease.InOutSine);
                Liner(left);
            }
            else if (npcLocation == "right")
            {
                Vector3 loc = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f,-10);
                _camera.DOOrthoSize(3, 0.5f).SetEase(Ease.InOutSine);
                if (!isCommunicating) _camera.transform.DOMove(loc, 0.5f).SetEase(Ease.InOutSine);
                Liner(right);
            }
            else
            {
                _camera.GetComponent<CameraController>().enabled = false;
            }
        }


    }
    void Liner(Vector3Int location)
    {
        scriptBox.SetActive(true);
        isCommunicating = true;
        DataManager.NPC[] NPCs = DataManager.Instance.npcContainer.NPCs;

        DataManager.NPC npc = NPCs[0];

        for (int i = 0; i < NPCs.Length; i++)
        {
            if (NPCs[i].location == location)
            {
                npc = NPCs[i];
                break;
            }
        }

        if (scriptStack == npc.defaultTalks.Length)
        {
            isCommunicating = false;
            scriptStack = 0;
            scriptBox.SetActive(false);
            _camera.DOOrthoSize(5, 0.5f).SetEase(Ease.InOutSine);
        }
        else
        {
            Speak(npc.defaultTalks[scriptStack]);
        }
    }


    void Speak(string script)
            {
                commuBox.DOText("", 0.01f);
                commuBox.DOText(script, 1f).OnComplete(() => { endCursor.SetActive(true); });
            }
}
