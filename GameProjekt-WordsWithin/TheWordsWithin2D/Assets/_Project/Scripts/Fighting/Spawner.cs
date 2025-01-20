using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject spawnThis;
        public int spawnRate = 30;
        
        private float _minY = -6;
        private float _maxY = 6;
        private int _counter;

        private void FixedUpdate()
        {
            _counter += 1;
            if(_counter < spawnRate) return;

            _counter = 0;
            
            float randomY = Random.Range(_minY, _maxY);
        
            Vector3 position = spawnThis.transform.position;
        
            Instantiate(spawnThis, new Vector3(position.x, randomY, position.z), Quaternion.identity);
        }
    }
}
