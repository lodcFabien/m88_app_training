using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class CourseDatabaseManager : Singleton<CourseDatabaseManager>
{
    private string _courseSaveDirectory = $"{Application.streamingAssetsPath}/Courses/";

    private List<CourseSavedModel> _courses = new List<CourseSavedModel>();
    public List<CourseSavedModel> Courses => _courses;

    private UnityEvent _databaseLoaded = new UnityEvent();
    public UnityEvent DatabaseLoaded => _databaseLoaded;

    private bool _loaded = false;
    public bool Loaded => _loaded;

    private void Start()
    {
        LoadAllCourses();
    }

    public void SaveCourse(CourseSavedModel course)
    {
        string savePath = $"{_courseSaveDirectory}{course.Id}.json";
        File.WriteAllText(savePath, JsonUtility.ToJson(course));
    }

    private void LoadAllCourses()
    {
        DirectoryInfo saveDirectory = new DirectoryInfo(_courseSaveDirectory);

        FileInfo[] files = saveDirectory.GetFiles();

        foreach (FileInfo file in files)
        {
            if(file.Extension == ".json")
            {
                CourseSavedModel loadedCourse = new CourseSavedModel();
                string loadedData = File.ReadAllText(file.FullName);
                loadedCourse = JsonUtility.FromJson<CourseSavedModel>(loadedData);
                _courses.Add(loadedCourse);
            }
        }

        _databaseLoaded.Invoke();
        _loaded = true;
    }

    public void DeleteCourse(CourseSavedModel course)
    {
        File.Delete($"{_courseSaveDirectory}{course.Id}.json");
    }
}
