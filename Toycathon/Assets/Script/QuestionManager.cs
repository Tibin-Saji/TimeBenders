using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class QuestionManager : MonoBehaviour
{
    public VideoPlayer VP;
    public SetQuiz setQuiz;
    public ImageQuiz imgQuiz;
    public Animator QuizAnim;
    public Animator ImgQuizAnim;
    public Animator LifeAnim;
    public GameObject CorrectPanel;
    public GameObject LivesOverPanel;
    public VideoClip[] videoClips;

    private int QuesType;
    private bool calledQues = false;
    private int QNo = 0;
    private int Lives = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Lives == 0)
        {
            StartCoroutine(ShowLivesOverPanel());
        }
        if (((ulong)VP.frame == VP.frameCount - 1) && !calledQues)
        {
            if(QNo == videoClips.Length - 1)
            {
                SceneManager.LoadScene(2);
            }
            
            calledQues = true;
            ++QNo;
            SelectQuesType();
        }

    }

    IEnumerator ShowLivesOverPanel()
    {
        yield return new WaitForSeconds(0.5f);
        LivesOverPanel.SetActive(true);
    }

    void SelectQuesType()
    {
        QuesType = Random.Range(0, 2);
        switch (QuesType)
        {
            case 0:
                setQuiz.SetQues(QNo);
                QuizAnim.Play("QuestionPanelShow");
                break;
            case 1:
                imgQuiz.SetQues(QNo);
                ImgQuizAnim.Play("ImgQuesPanelShow");
                break;

            default:
                break;
        }
    }

    public void GotCorrectAnswer()
    {
        switch (QuesType)
        {
            case 0:
                StartCoroutine(HideQuizPanel());
                break;
            case 1:
                StartCoroutine(HideImgQuizPanel());
                break;
            default:
                break;
        }
        StartCoroutine(ShowCorrectPanel());
        StartCoroutine(HideCorrectPanel());
    }

    IEnumerator HideQuizPanel()
    {
        yield return new WaitForSeconds(0.5f);
        QuizAnim.Play("QuestionPanelHide");
    }

    IEnumerator HideImgQuizPanel()
    {
        yield return new WaitForSeconds(0.5f);
        ImgQuizAnim.Play("ImgQuesnPanelHide");
    }

    IEnumerator ShowCorrectPanel()
    {
        yield return new WaitForSeconds(1f);
        CorrectPanel.SetActive(true);
    }

    //Hiding Panel and changing video clip
    IEnumerator HideCorrectPanel()
    {
        yield return new WaitForSeconds(3f);
        CorrectPanel.SetActive(false);
        VP.clip = videoClips[QNo];
        calledQues = false;
    }

    public void ReduceLife()
    {
        --Lives;
        switch (Lives)
        {
            case 3:
                LifeAnim.Play("BlinkT");
                break;
            case 2:
                LifeAnim.Play("BlinkI");
                break;
            case 1:
                LifeAnim.Play("BlinkM");
                break;
            case 0:
                LifeAnim.Play("BlinkE");
                break;
            default:
                break;
        }
    }

    public void RestartVideo()
    {
        VP.Play();
        --QNo;
        QuizAnim.Play("QuestionPanelHide");
        calledQues = false;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(2);
    }
}
