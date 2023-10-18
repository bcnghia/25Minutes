using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;
    public int bulletsToShoot = 12; // Số viên đạn kẻ địch sẽ bắn mỗi lần
    public float shootInterval = 0.1f; // Thời gian giữa các lần bắn
    private int bulletsFired = 0; // Số viên đạn đã bắn trong lần bắn hiện tại

    public bool shootStraight = false; // Bật tắt có bắn vào người chơi hay ko 

    void Start()
    {
        // Bắn sau mỗi 1 giây
        InvokeRepeating("Shoot", 0.5f, shootInterval);
    }

    void Shoot()
    {
        GameObject playerShip = GameObject.Find("Spaceship");

        if (playerShip != null) // Nếu người chơi không chết
        {
            if (bulletsFired < bulletsToShoot)
            {
                // Khởi tạo viên đạn cho địch
                GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);

                // Tính hướng đạn dựa vào vị trí của người chơi
                Vector2 direction;

                if (shootStraight)
                {
                    // Nếu bật, thì bắn thẳng xuống phía dưới
                    direction = Vector2.down;
                }
                else
                {
                    // Nếu không cài đặt để bắn thẳng, tính hướng đạn dựa vào vị trí của người chơi
                    direction = (playerShip.transform.position - bullet.transform.position).normalized;
                }

                // Đặt hướng đạn
                bullet.GetComponent<Enemy_Bullets>().SetDirection(direction);

                bulletsFired++;
            }
            else
            {
                // Đã bắn đủ số viên đạn, hủy việc kích hoạt hàm Shoot()
                CancelInvoke("Shoot");
            }
        }
    }

    // Hàm để bật/tắt chế độ bắn thẳng
    public void SetShootStraight(bool straight)
    {
        shootStraight = straight;
    }

    void Update()
    {

    }
}
