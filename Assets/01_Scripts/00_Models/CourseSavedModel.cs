using System;
using UnityEngine;

[Serializable]
public class CourseSavedModel
{
    public FolderSavedModel[] Folders;
    
    public CourseSavedModel()
    {
        Folders = new FolderSavedModel[0];
    }

    [Serializable]
    public class FolderSavedModel
    {
        public FolderSavedModel[] SubFolders;
        public string Name;

        public FolderSavedModel()
        {
            SubFolders = new FolderSavedModel[0];
        }
    }
}
