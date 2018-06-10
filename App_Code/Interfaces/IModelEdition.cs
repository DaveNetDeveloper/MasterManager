using System; 

public interface IModelEdition
{
    #region [ properties ]

    BasePage.ViewMode Mode { get; set; }
    string PrimaryKey { get; set; }
    string PageTitle { get; }

    #endregion

    #region [ methods ]

    void GetPageParameters();
    void ApplyLayout(); 
    void FillFromModel(); 
    bool SaveModel();
    bool IsValidModel();
    void ResetFields();

    void GoBackClick(object sender, EventArgs e);
    void SaveModelClick(object sender, EventArgs e);
     
    #endregion
}