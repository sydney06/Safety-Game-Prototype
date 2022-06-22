using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        //=====================================GAME VARIABLES=======================================
        // reference to player
        private ThirdPersonCharacter _player;
        //==========================================================================================

        private static GameManager _instance;
        public static GameManager Instance { get => _instance; }

        [SerializeField]
        private TransitionFader _endTransitionPrefab;


        // initialize references
        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }


            //=========================GAME VARIABLES INITIALIZATIONS SECTION===========================
            

            //==========================================================================================
        }

        private void OnDestroy()
        {
            //=====================================GAME ONDESTROY=======================================
            if (_instance == this)
            {
                _instance = null;
            }
            //==========================================================================================
        }

        // check for the end game condition on each frame
        private void Update()
        {
            //======================================GAME UPDATE=======================================
            
            //==========================================================================================
        }


        //======================================GAME METHODS=======================================
        // end the level
        public void EndLevel()
        {
           
        }
        //==========================================================================================

    }
}