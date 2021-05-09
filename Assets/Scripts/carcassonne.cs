using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carcassonne : MonoBehaviour
{
    public GameObject startTile;
    public GameObject Tiles;
    public Text score1Text;
    public Text score2Text;
    public Text ppDisplay;
    public Text FollowerDisplay;

    private int curPlayer;
    private int curPhase;
    private int scoreP1 ;
    private int scoreP2;
    private int followers1;
    private int followers2;

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
        updateSigns();
    }

    
    void Update()
    {
        
    }

    //Function for clicking next
    public void onClickNext()
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
        updateSigns();
    }

    //Function for updating displayed signs
    public void updateSigns()
    {
        //Updating the Phase and Player Display
        if (curPhase == 2) {
            ppDisplay.text = "Player " + curPlayer.ToString() + "\n" + "Meeple Placing";
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
}
