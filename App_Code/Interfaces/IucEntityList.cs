using System.Collections.Generic;
using System.Web.UI.WebControls;

public interface IucEntityList
{
    IEnumerable<IModel> DataSource { get; set; }
    SortDirection Dir { get; set; }
    IEntity Entity { get; }

    void InitializeList();
    void LoadGridViewData();
    void LoadDataSource();
    void ExportToExcel();
}