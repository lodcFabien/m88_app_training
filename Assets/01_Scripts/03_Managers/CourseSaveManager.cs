using System.IO;
using UnityEngine;

public class CourseSaveManager : Singleton<CourseSaveManager>
{
    private string _courseSaveDirectory = $"{Application.streamingAssetsPath}/Courses/"; 

    public void SaveCourse(CourseSavedModel course, string courseName)
    {
        string savePath = $"{_courseSaveDirectory}{courseName}.json";
        File.WriteAllText(savePath, JsonUtility.ToJson(course));
    }

    public CourseSavedModel LoadCourse(string courseName)
    {
        CourseSavedModel loadedCourse = new CourseSavedModel();
        string loadPath = $"{_courseSaveDirectory}{courseName}.json";
        string loadedData = File.ReadAllText(loadPath);

        loadedCourse = JsonUtility.FromJson<CourseSavedModel>(loadedData);

        return loadedCourse;
    }
}
