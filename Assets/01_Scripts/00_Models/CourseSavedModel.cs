using System;
using UnityEngine;
using static Enums;

[Serializable]
public class CourseSavedModel : ICloneable
{
    public int Id;
    public string CourseTitle;
    public FolderSavedModel[] Folders;
    public TrainingCategory[] Categories;

    public CourseSavedModel(string courseTitle = "")
    {
        CourseTitle = courseTitle;
        Folders = new FolderSavedModel[0];
        Id = 0; 
        Categories = new TrainingCategory[0];
    }

    [Serializable]
    public class FolderSavedModel
    {
        public FolderSavedModel[] SubFolders;
        public string[] Files;
        public string FolderName;

        public FolderSavedModel()
        {
            SubFolders = new FolderSavedModel[0];
            Files = new string[0];
        }
    }

    public object Clone()
    {
        return this.MemberwiseClone();    
    }
}
