using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class QuizDatabaseManager : Singleton<QuizDatabaseManager>
{
    private string _quizSaveDirectory = $"{Application.streamingAssetsPath}/Quizzes/";

    private List<QuizSavedModel> _quizzes= new List<QuizSavedModel>();
    public List<QuizSavedModel> Quizzes => _quizzes;

    private UnityEvent _databaseLoaded = new UnityEvent();
    public UnityEvent DatabaseLoaded => _databaseLoaded;

    private bool _loaded = false;
    public bool Loaded => _loaded;

    private void Start()
    {
        LoadAllQuizzes();
    }

    public void SaveQuiz(QuizSavedModel quiz)
    {
        string savePath = $"{_quizSaveDirectory}{quiz.Id}_{quiz.QuizTitle}.quiz";
        File.WriteAllText(savePath, JsonUtility.ToJson(quiz));
    }

    private void LoadAllQuizzes()
    {
        DirectoryInfo saveDirectory = new DirectoryInfo(_quizSaveDirectory);

        FileInfo[] files = saveDirectory.GetFiles();

        foreach (FileInfo file in files)
        {
            if (file.Extension == ".quiz")
            {
                QuizSavedModel loadedQuiz = new QuizSavedModel();
                string loadedData = File.ReadAllText(file.FullName);
                loadedQuiz = JsonUtility.FromJson<QuizSavedModel>(loadedData);
                _quizzes.Add(loadedQuiz);
            }
        }

        _databaseLoaded.Invoke();
        _loaded = true;
    }

    public void DeleteQuiz(QuizSavedModel quiz)
    {
        File.Delete($"{_quizSaveDirectory}{quiz.Id}_{quiz.QuizTitle}.quiz");
    }
}
