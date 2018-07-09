using System;

public interface IModelEdition
{
    #region [ properties ]

    BaseUC.ViewMode Mode { get; set; }
    string PrimaryKey { get; set; }
    string PageTitle { get; }

    IModel Model { get; set; }

    #endregion

    #region [ methods ]

    void GetPageParameters();
    void ApplyLayout(); 
    void FillFromModel(); 
    bool SaveModel();
    bool IsValidModel();
    void ResetFields();

    #endregion

    #region [ events ]

    void Page_Init(object sender, EventArgs e);
    void Page_Load(object sender, EventArgs e);
    void GoBackClick(object sender, EventArgs e);
    void SaveModelClick(object sender, EventArgs e);
     
    #endregion
}