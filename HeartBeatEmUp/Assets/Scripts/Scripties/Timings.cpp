using UnityEngine;

Public class Timings: Monobehaviour
{

    public PlayerBehaviour playerBehaviour;//refrences script PlayerBehaviour so can call outside class
    public int Beats;
    public float AttackTime;
    public float Delay;
    public int timeLeft;//timer length(this is length of the song)
    void awake()
    {
        
    }
    void start()
    {
        startcoroutine(BMP());//starts coroutine BMP
    }

    void update()
    {
        timeLeft -= Time.deltaTime; //takes time since last frame from timeLeft
        if (timeLeft =< 0 ) //checks if time left is less or equal to 0
        {
            Debug.Log("Timer Has Ended");//prints to debug log
        }
    }

    public IEnumerator BMP()
    {
        for(i=0,i<Beats,i++)//creates loop that plays depening on amount of beats in song
        {
        yield return new WaitForSeconds(Delay);//adds space between beats(beats per second)
        if(Input.GetKeyDown(KeyCode.return))// checks if the return was pressed within current time
        {
        playerBehaviour.Attack();//if key was pressed call attack class(this does the animation)
        }
        yield return new WaitForSeconds(AttackTime);//gives time allowed to attack within (Length of beat)
        playerBehaviour.AttackOff();//ensures animation is ended
        }
        
    }
}