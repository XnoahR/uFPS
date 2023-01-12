
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public float _BoxHealthPoint;
    
    void Awake(){
        _BoxHealthPoint = 250;
    }
    public void Damaged(float _Dmg){
        
        _BoxHealthPoint -= _Dmg;

        if(_BoxHealthPoint <= 0){
            _BoxHealthPoint = 0;
            Dead();
        }
    }

private void Dead(){
    Destroy(gameObject);
}

}
