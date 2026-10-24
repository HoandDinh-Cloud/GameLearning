using System.Collections.Generic;

using UnityEngine;

namespace _Script
{
    public class PlayerPosition : MonoBehaviour
    {
        //Khai báo biến
        private float _playerPositionX;
 

        //Kiểm soát bom được tạo ra bằng List
        [SerializeField] public GameObject bomPrefab;
        [SerializeField] private int bomPoolSize = 7;
        [SerializeField] private List<GameObject> bomsList = new();

        private bool _spawnFlag;
        
        //Tạo thông số kiểm soát thời gian
        [SerializeField] protected float spawnDelay = 1f;
        private float _spawnTimer;
       private void Start()
        { 
            //Tạo pool đúng một lần khi bắt đầu.
            SetUpBomPool();
        }

        private void Update()
        {
            if (TimerBeforeMakeABom())
            {
                SpawnBomFromPool();
            }
            
        }

        bool TimerBeforeMakeABom()
        {
            //Spawn theo thời gian 
            this._spawnTimer += Time.deltaTime;
            if (_spawnTimer < spawnDelay) return false;
            _spawnTimer = 0;
            return true;
        }
        void SetUpBomPool()
        {
            for (int i = 0; i < bomPoolSize; i++)
            {
                GameObject bom = Instantiate(bomPrefab, transform.position, Quaternion.identity);

                bom.name = $"Bom #{i + 1}";
                bom.SetActive(false);
                bomsList.Add(bom);
            }
        }

        void SpawnBomFromPool()
        {
            foreach (GameObject bom in bomsList)
            {
                if (!bom.activeSelf)
                {
                    bom.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

                    bom.SetActive(true);
                    return;
                }
            }
        }
            
        }
    }
