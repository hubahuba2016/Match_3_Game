using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Match3
{
    public class Level : MonoBehaviour
    {
        public GameGrid gameGrid;
        //public Hud hud;
        public Text score_text;

        public int score1Star;
        public int score2Star;
        public int score3Star;    

        protected LevelType type;

        protected int currentScore;

        private bool _didWin;

        private void Start()
        {
            //hud.SetScore(currentScore);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public LevelType Type => type;

        protected virtual void GameWin()
        {
            gameGrid.GameOver();
            _didWin = true;
            StartCoroutine(WaitForGridFill());
        }

        protected virtual void GameLose()
        {        
            gameGrid.GameOver();
            _didWin = false;
            StartCoroutine(WaitForGridFill());
        }
    
        public virtual void OnMove()
        {
        }

        public virtual void OnPieceCleared(GamePiece piece)
        {
            currentScore += piece.score;
            Debug.Log("score is " + currentScore);
            score_text.text = "score is " + currentScore;
            //hud.SetScore(currentScore);
        }

        protected virtual IEnumerator WaitForGridFill()
        {
            while (gameGrid.IsFilling)
            {
                yield return null;
            }

            if (_didWin)
            {
                // hud.OnGameWin(currentScore);
                Debug.Log("You win");
            }
            else
            {
                // hud.OnGameLose();
                Debug.Log("You lose");
            }
        }
    }
}
