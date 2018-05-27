using System; 

public interface IModelEdition
{
    #region [ properties ]

    BasePage.ViewMode Mode { get; set; }
    string PrimaryKey { get; set; }

    #endregion

    #region [ methods ]

    void GetPageParameters();
    void ApplyLayout();

    //IModel GetModel();
    void FillFromModel();
    //IModel GetModelFromForm();
    bool SaveModel(IModel mdoel);
    bool IsValidModel();
    void ResetFields();

    void GoBackClick(object sender, EventArgs e);
    void SaveModelClick(object sender, EventArgs e);
     
    #endregion
}