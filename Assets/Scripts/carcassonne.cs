using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcassonne : MonoBehaviour
{
    public GameObject startTile;
    public GameObject Tiles;
    private int curPlayer;
    private int curPhase;
    private int scoreP1;
    private int scoreP2;

    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        curPlayer = 1;
        curPhase = 1;
        for(int i = 0; i < 5; i++) {
            GameObject tile = Instantiate(startTile, new Vector2(0,0), Quaternion.identity);
            tile.transform.SetParent(Tiles.transform, false);
        }
    }

    // Update is called once per frame
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

    }

    //Function for updating displayed signs
    public void updateSigns()
    {

    }

    //Function for updating the scores
    public void updateScores(int score1, int score2)
    {
        scoreP1 = score1;
        scoreP2 = score2;
    }
}
