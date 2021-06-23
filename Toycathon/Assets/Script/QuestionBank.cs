using UnityEngine;
using UnityEngine.UI;

public class QuestionBank : MonoBehaviour
{
    [HideInInspector]
     public string[] Questions = new string[]{
        "Which state should be Annexed under policy of misgovernance?",
        "Who should start the mutiny on 29th March?",
        "Who should be named the ruler of Delhi?",
        "What should the Queen of England decide on the matter?"
    };

    [HideInInspector]
    public string[][] QuizAns = new string[][] {
        new string[]{ "Awadh", "Bihar", "Jansi", "Punjab", "Bengal" },
        new string[]{ "Mangal Pandey", "Bahadur Shah Zafar", "Tatia Tope", "Rani Laxmibai", "Nana Sahib" },
        new string[]{ "Bahadur Shah Zafar", "Kunwar Singh", "Tatia Tope", "Begum Hazrat Mehal" },
        new string[]{ "Take the authority over", "Impose heavier tax", "Gave independance", "Suppressed Indians by force" }
    };

    [HideInInspector]
    public string[][] ImgQuizAns = new string[][]
    {
        new string[]{"Those are Grease Cartridges", "Those are Tabacco", "Those are Small Explosives"},
        new string[]{ "It is Mangal Pandey", "It is Gandhiji", "It is Bahadur Shah Zafar", "It is Nana Saheb"},
        new string[]{"Bahadur Shah Zafar", "Nana Saheb", "Bakht Khan", "Kunwar Singh"},
        new string[]{"Queen Victoria", "Queen Elizabeth I", "Queen Elizabeth II", "Queen Anne"}
    };

    [HideInInspector]
    public string[] ImgQues = new string[]
    {
        "What is this thing?",
        "Can you guess the chained person in the image?",
        "Who is this person?",
        "What is the name of this Queen"
    };
}
