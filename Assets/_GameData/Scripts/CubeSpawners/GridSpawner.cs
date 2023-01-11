using _GameData.Scripts.Managers;
using UnityEngine;

namespace _GameData.Scripts.CubeSpawners
{
    public class GridSpawner : MonoBehaviour
    {
        private GameObject[] _imageWall;
        private Texture2D _imageToRead;
     
        private void Start()
        {
            var levelImages = LevelDataManager.ınstance.levelData.levelImages;
            var randomImageIndex = Random.Range(0, levelImages.Count);
            _imageToRead = levelImages[randomImageIndex];
            ColorCubeSpawner();
        }

        private void ColorCubeSpawner()
        {
            Color[] pixels = _imageToRead.GetPixels();
            _imageWall = new GameObject[pixels.Length];

            for (int index = 0; index < pixels.Length; index++)
            {
                if (pixels[index] == new Color(0, 0, 0, 0)) continue;
                _imageWall[index] = Instantiate( LevelDataManager.ınstance.levelData.SpawnCube, transform);
                _imageWall[index].transform.localPosition = new Vector3( _imageToRead.width -(index % _imageToRead.width), 0,  index / _imageToRead.width);
                _imageWall[index].GetComponent<Cube>().cubeMeshRenderer.material.color = pixels[index];
                CollectedCountManager.ınstance.totalCubeCount++;
            }
        }
    }
}
