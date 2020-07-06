using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singelton instance reference
    public static GameManager instance = null;

    // Keeps Track of the Number of items in play
    public List<GameObject> items;

    // The max number of items in play
    public int maxItems;

    // the number of items needed to win
    public int ItemsToWin;

    // the number of disposed of items
    private int disposedItems;

    // The Game State
    public enum GameState
    {
        GameStart = 0,
        GamePlay = 1,
        GameWin = 2,
        GameOver = 3
    }

    public GameState currentGameState;

    void Awake()
    {
        if( instance != null && instance != this )
        {
            Destroy( this.gameObject );
        }

        instance = this;
        DontDestroyOnLoad( this.gameObject );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //depending on the game state
        switch ( currentGameState )
        {
            case GameState.GameStart:
            //Game is starting
                break;
            case GameState.GamePlay:
                // Game is playing
                // If the number of items in play exceed the max number, 
                if(items.Count >= maxItems)
                {
                    // Game over
                    currentGameState = GameState.GameOver;
                }
                // If the number of disposed of items is exceeds the winning items
                else if(disposedItems >= ItemsToWin)
                {
                    // win the game
                    currentGameState = GameState.GameWin;
                }
                break;
            case GameState.GameWin:
            //Game is won
                break;
            case GameState.GameOver:
            //Game is over
                break;
        }
    }

    // A ball was spawned
    public void AddItemToManager(GameObject item)
    {
        items.Add(item);
    }

    // A ball was despawned
    public void RemoveItemFromManager(GameObject item)
    {
        //remove the item from the items (if we can find it)
        items.Remove(items.Find(i => i == item));
        //i'll assume for now that we will only ever destroy an object if we disposed of it.
        disposedItems++;
    }
}
