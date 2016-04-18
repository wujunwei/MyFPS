using UnityEngine;
using System.Collections;


[AddComponentMenu("Game/Enemy")]
public class Enemy : MonoBehaviour {

    // Transform���
    Transform m_transform;
    //CharacterController m_ch;

    // �������
    Animator m_ani;

    // Ѱ·���
   // NavMeshAgent m_agent;
   A_alogrithm m_agent;
    // ����
    Player m_player;

    // ��ɫ�ƶ��ٶ�
    float m_movSpeed = 0.5f;

    // ��ɫ��ת�ٶ�
    float m_rotSpeed = 120;

    //  ��ʱ��
    float m_timer=2;

    // ����ֵ
    int m_life = 15;

    // ������
    protected EnemySpawn m_spawn;

	// Use this for initialization
	void Start () {
        m_agent = this.transform.FindChild("A_alogrithm").GetComponent<A_alogrithm>();
        // ��ȡ���
        m_transform = this.transform;
        m_ani = this.GetComponent<Animator>();
       // m_agent = GetComponent<NavMeshAgent>();
        // �������
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}

    // ��ʼ��
    public void Init(EnemySpawn spawn)
    {
        m_spawn = spawn;

        m_spawn.m_enemyCount++;
    }

    // ��������ʱ
    public void OnDeath()
    {
        //���µ�������
        m_spawn.m_enemyCount--;

        // ��100��
        GameManager.Instance.SetScore(100);

        // ����
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        // �����������Ϊ0��ʲôҲ����
        if (m_player.m_life <= 0)
            return;

        // ��ȡ��ǰ����״̬
        AnimatorStateInfo stateInfo = m_ani.GetCurrentAnimatorStateInfo(0);

        // ������ڴ���״̬
        if (stateInfo.nameHash == Animator.StringToHash("Base Layer.idle") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idle", false);

            // ����һ��ʱ��
            m_timer -= Time.deltaTime;
            if (m_timer > 0)
                return;

            // �����������С��1.5�ף����빥������״̬
            if (Vector3.Distance(m_transform.position, m_player. m_transform.position) < 1.5f)
            {
                m_ani.SetBool("attack", true);
            }
            else
            {
                // ���ö�ʱ��
                m_timer=1;

                // ����Ѱ·Ŀ���
                m_agent.SetDestination(m_player.m_transform.position);

                // �����ܲ�����״̬
                m_ani.SetBool("run", true);
            }
        }

        // ��������ܲ�״̬
        if (stateInfo.nameHash == Animator.StringToHash("Base Layer.run") && !m_ani.IsInTransition(0))
        {

            m_ani.SetBool("run", false);


            // ÿ��1�����¶�λ���ǵ�λ��
            m_timer -= Time.deltaTime;
            if (m_timer < 0)
            {
               // m_agent.SetDestination(m_player.m_transform.position);

                m_timer = 1;
            }
 
            // ׷������
            MoveTo();

            // �����������С��1.5�ף������ǹ���
            if (Vector3.Distance(m_transform.position, m_player. m_transform.position) <= 1.5f)
            {
			  //ֹͣѰ·	
                m_agent.ResetPath();
		      // ���빥��״̬
                m_ani.SetBool("attack", true);
            }
        }

        // ������ڹ���״̬
        if (stateInfo.nameHash == Animator.StringToHash("Base Layer.attack") && !m_ani.IsInTransition(0))
        {
           
            // ��������
            RotateTo();

            m_ani.SetBool("attack", false);

            // ��������������꣬���½������״̬
            if (stateInfo.normalizedTime >= 1.0f)
            {
                m_ani.SetBool("idle", true);

                // ���ü�ʱ��
                m_timer = 2;

                m_player.OnDamage(1);
            }
        }

        // ����
        if (stateInfo.nameHash == Animator.StringToHash("Base Layer.death") && !m_ani.IsInTransition(0))
        {
            if (stateInfo.normalizedTime >= 1.0f)
            {
                OnDeath();
              
            }
        }

 
	}
   
    // ת��Ŀ���
    void RotateTo()
    {
        // ��ǰ�Ƕ�   
        Vector3 oldangle = m_transform.eulerAngles;

        //  ����������ǵĽǶ�
        m_transform.LookAt(m_player.m_transform);
        float target = m_transform.eulerAngles.y;

        // ת������
        float speed = m_rotSpeed * Time.deltaTime;
        float angle = Mathf.MoveTowardsAngle(oldangle.y, target, speed);
        m_transform.eulerAngles = new Vector3(0, angle, 0);
    }

    // Ѱ·�ƶ�
    void MoveTo()
    {
        float speed = m_movSpeed * Time.deltaTime;
        m_agent.Move(speed);

    }

    // �˺�
    public void OnDamage(int damage)
    {
        m_life -= damage;

        // �������Ϊ0����������
        if (m_life <= 0)
        {
            m_ani.SetBool("death", true);
        }
    }
}
