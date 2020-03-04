using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instaniate;

    public int coin ;
    public float meterFloatScore;
    public bool playerIsDead = false;

    public Transform player;
    public Text meterScore;
    public Text coinText;
    public GameObject[] tileObject;
    public List<GameObject> tileList = new List<GameObject>();
    private Vector3 createPosition;
    private SpriteRenderer tileSpriteLength;

    private void Awake()
    {
        instaniate = this;
    }

    private void Start()
    {
        float _position = player.transform.localPosition.x;
        createPosition = new Vector3 (_position, 0f, player.transform.position.z);

        tileList.Add(Instantiate(tileObject[0], createPosition, Quaternion.identity, transform));
        tileSpriteLength = tileList[0].GetComponent<SpriteRenderer>();
        createPosition.x += tileSpriteLength.bounds.size.x + 5f;

        RandomTile(_position);
    }

    private void Update()
    {
        PlayerDeadControl();

        TextFunctions();

        if (tileList.Count < 19)
        {
            TileCreate();
        }
    }

    private void TextFunctions()
    {

        meterFloatScore = player.transform.position.x / 10;
        meterScore.text = meterFloatScore.ToString("0") + " m";

        coinText.text = coin.ToString() + " C";
    }

    //Game Over Panel and First Scene
    private void PlayerDeadControl()
    {
        if (playerIsDead)
        {
            if(PlayerPrefs.GetFloat("Score") < meterFloatScore)
            {
                PlayerPrefs.SetFloat("Score", meterFloatScore);
            }
            int setCoin = PlayerPrefs.GetInt("Coin");
            setCoin += coin;
            PlayerPrefs.SetInt("Coin", setCoin);
            SceneManager.LoadScene(0);
        }
    }

    //Objelerin Rastgele ve ard arda çıkması için gereken kod bloğu
    private void RandomTile(float _position)
    {
        for (int createPrefabLoop = 0; createPrefabLoop < 20; createPrefabLoop++)
        {
            int random = Random.Range(0, tileObject.Length);
            tileList.Add( Instantiate(tileObject[random], createPosition, Quaternion.identity, transform));
            tileSpriteLength = tileList[createPrefabLoop].GetComponent<SpriteRenderer>();
            createPosition.x += tileSpriteLength.bounds.size.x + 4f;
        }
    }

    //Create one tile
    private void TileCreate()
    {
        int random = Random.Range(0, tileObject.Length);
        tileList.Add(Instantiate(tileObject[random], createPosition, Quaternion.identity, transform));
        tileSpriteLength = tileList[tileList.Count -1].GetComponent<SpriteRenderer>();
        createPosition.x += tileSpriteLength.bounds.size.x + 4f;
    }

    public void ClickPanelButton(string value)
    {
        if(value == "MainMenu")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
