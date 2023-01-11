using UnityEngine;

public class GridSpawnerEntity : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    
    private GameObject[] imageWall;
    private Texture2D imageToRead;
     
    void Start()
    {
        var _levelImages = LevelDataManager.ınstance.levelData.levelImages;
        var randomImageIndex = Random.Range(0, _levelImages.Count);
        imageToRead = _levelImages[randomImageIndex];
        ColorCubeSpawner();
    }

    void ColorCubeSpawner()
    {
        Color[] pixels = imageToRead.GetPixels();
        imageWall = new GameObject[pixels.Length];
        
        for (int index = 0; index < pixels.Length; index++)
        {
            if (pixels[index] != new Color(0, 0, 0, 0))
            {
                imageWall[index] = Instantiate(cube, transform);
                imageWall[index].transform.localPosition = new Vector3( imageToRead.width -(index % imageToRead.width), 0,  index / imageToRead.width);
                imageWall[index].GetComponent<CubeEntity>().cubeMeshRenderer.material.color = pixels[index];
            }
        }
    }
}
