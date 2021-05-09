using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carcassonne : MonoBehaviour
{
    public GameObject startTile; //Initial tile to be created
    public GameObject baseTile; //basetile to be pulled when creating a new tile
    public GameObject Tiles; //The in game category of all tiles in play
    public Text score1Text; //Text displayed on P1 scoreboard
    public Text score2Text; //Text displayed on P2 scoreboard
    public Text ppDisplay; //Text displayed on for current player and phase board
    public Text FollowerDisplay; //Text displayed on the follower count board
    public Sprite[] tileOptions; //Array of all the possible tile sprites
    private Image rend; //The sprite renderer to change the sprite
   
    private Movement moving; //Script object for movement
    private int curPlayer; //Current player
    private int curPhase; //Current phase
    private int scoreP1; //Player 1's score
    private int scoreP2; //Player 2's score
    private int followers1; //Player 1's followers
    private int followers2; //Player 2's followers
    private int tileNumber; //Random number corresponding to the tile sprite to be pulled

    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        followers1 = 7;
        followers2 = 7;
        curPlayer = 1;
        curPhase = 1;
        GameObject tile = Instantiate(startTile, new Vector2(0,0), Quaternion.Euler(0, 0, 90));
        tile.transform.SetParent(Tiles.transform, false);
        spawnTile();
        updateSigns();
    }

    //Function for clicking next
    private void onClickNext()
    {
        if (curPhase == 2) {
            if (curPlayer == 1) {
                curPlayer = 2;
            } else {
                curPlayer = 1;
            }
            curPhase = 1;
        } else if (curPhase == 1) {
            curPhase = 2;
        }

        if (curPhase == 1)
            spawnTile();
        if (curPhase == 2)
            moving.changeInPlay(false);

        updateSigns();
    }

    //Function for updating displayed signs
    private void updateSigns()
    {
        //Updating the Phase and Player Display
        if (curPhase == 2) {
            ppDisplay.text = "Player " + curPlayer.ToString() + "\n" + "Follower Placing";
        } else {
            ppDisplay.text = "Player " + curPlayer.ToString() + "\n" + "Tile Placing";
        }
        //Updating the Score Display
        score1Text.text = "Player 1 Score\n" + scoreP1.ToString();
        score2Text.text = "Player 2 Score\n" + scoreP2.ToString();
        //Updating the Follower Display
        if (curPlayer == 1) {
            FollowerDisplay.text = "Followers Remaining\n" + followers1.ToString();
        } else {
            FollowerDisplay.text = "Followers Remaining\n" + followers2.ToString();
        }
    }

    //Function for updating the scores
    public void updateScores(int score1, int score2)
    {
        scoreP1 = score1;
        scoreP2 = score2;
        updateSigns();
    }

    //Function for updating the followers
    public void updateFollowers(int follower1, int follower2)
    {
        followers1 = follower1;
        followers2 = follower2;
        updateSigns();
    }

    //Spawns a new tile
    private void spawnTile()
    {
        GameObject tile = Instantiate(baseTile, new Vector2(850,-520), Quaternion.identity);
        tile.transform.SetParent(Tiles.transform, false);
        tileNumber = Random.Range(0,38);
        rend = tile.GetComponent<Image>();
        rend.sprite = tileOptions[tileNumber];
        moving = GameObject.FindObjectOfType(typeof(Movement)) as Movement;
    }
}
