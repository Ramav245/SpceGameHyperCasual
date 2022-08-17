namespace Ilumisoft.SceneManagement
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Playables;

    [RequireComponent(typeof(PlayableDirector))]
    [RequireComponent(typeof(Animator))]
    public class SceneManager : MonoBehaviour
    {
        [Tooltip("(Optional) Played when the scene is loaded")]
        [SerializeField] private PlayableAsset loadedPlayable = null;
        
        [Tooltip("(Optional) Played when loading another scene")]
        [SerializeField] private PlayableAsset unloadPlayable = null;

        private PlayableDirector _playableDirector;

        private void Awake()
        {
            _playableDirector = GetComponent<PlayableDirector>();
        }

        private void Start()
        {
            if (loadedPlayable != null)
            {
                _playableDirector.playableAsset = loadedPlayable;
                _playableDirector.Play();
            }
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }
        
        public void LoadSceneDelayed(string sceneName, float delay)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName, delay));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, float delay = 0.0f)
        {
            //Wait for the given delay
            if (delay > 0.0f)
            {
                yield return new WaitForSecondsRealtime(delay);
            }

            //If set, play the unload playable and wait until it is finished
            if (unloadPlayable != null)
            {
                _playableDirector.playableAsset = unloadPlayable;

                var duration = _playableDirector.duration;

                _playableDirector.Play();

                yield return new WaitForSecondsRealtime((float) duration);
            }

            //Load the given scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}