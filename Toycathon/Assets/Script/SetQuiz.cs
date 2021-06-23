using UnityEngine;
using UnityEngine.UI;

public class SetQuiz : QuestionBank
{
    public Text Ques;
    public Text Ans1;
    public Text Ans2;
    public Text Ans3;
    private Text[] AnsButtons = new Text[3];
    public QuestionManager QM;

    private int AnsIndex;
    private string AnsText;

    // Start is called before the first frame update
    void Start()
    {
        AnsButtons = new Text[]{Ans1, Ans2, Ans3};
    }

    public void SetQues(int QNo)
    {
        string[] AnswerSet = QuizAns[QNo - 1];
        AnsText = AnswerSet[0];
        Ques.text = Questions[QNo - 1];

        AnsIndex = Random.Range(0, 3);
        AnsButtons[AnsIndex].text = AnswerSet[0];
        AnswerSet[0] = " ";

        for (int i = 0; i < 3; i++)
        {
            if(i != AnsIndex)
            {
                int OptionIndex;
                do
                {
                    OptionIndex = Random.Range(0, AnswerSet.Length);
                } while (AnswerSet[OptionIndex] == " ");

                AnsButtons[i].text = AnswerSet[OptionIndex];
                AnswerSet[OptionIndex] = " ";
            }
        }
    }

    public void OnAnswerClick(Button button)
    {
        if(button.GetComponentInChildren<Text>().text == AnsText)
        {
            button.GetComponentInChildren<ParticleSystem>().Play();
            QM.GotCorrectAnswer();
        }
        else
        {
            QM.ReduceLife();
            button.GetComponent<Animator>().SetTrigger("isWrong");

        }
    }
}
