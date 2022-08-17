using UnityEngine;
using System.Collections;
using UnityEngine;

public class PowerUpSpawnSystem : SpawnSystem
{
    [SerializeField] private GameObject prefabs = null;
    
    [SerializeField] private int poolSize;
    
    //The pool holding all spawnable objects
    private GameObject[] _pool;

    private int index;
    private int _index;

    private void Awake()
    {
        _pool = new GameObject[poolSize];
 
        for (int i = 0; i < poolSize; i++)
        {                    
            //index = Random.Range (0, prefabs.Length);
            var instance = Instantiate(prefabs);
            
            instance.SetActive(false);
            
            _pool[i] = instance;
        }

        _index = 0;
    }
    
    /// <summary>
    /// Spawns an element from the pool at the given position
    /// </summary>
    /// <param name="position"></param>
    public override void Spawn(Vector3 position)
    {
                        var instance = _pool[_index];
        instance.transform.position = position;
        instance.SetActive(true);
                
                UpdatePoolIndex();
    }
    
    /// <summary>
    /// Increases the index, defining which element will be returned next, when the spawn method is called 
    /// </summary>
    private void UpdatePoolIndex()
    {
        _index++;

        if (_index >=  _pool.Length)
        {
            _index = 0;
        }
    }
}
