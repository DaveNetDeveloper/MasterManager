
function GetInitializedIModel(pId) {

    interface IModel {
        Id: number;
    }

    var pModel = {} as IModel;
    pModel.Id = pId;

    return pModel;
}