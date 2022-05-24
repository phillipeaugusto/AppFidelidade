using static System.String;

namespace AppFidelidade.Domain.Constants;

public static class GlobalMessageConstants
{
    public const string ReturnInconsistenciesMessage = "There were inconsistencies in the Entity.";
    public const string MessageSucessRegistred = "Data registered successfully!.";
    public const string MessageSucessChange = "Data change successfully!.";
    public const string MessageSucessRemove = "Data remove successfully!.";
    public const string MessageDataNotFound = "Data Not Found!.";
    public static readonly string MessageEmpty = Empty;
    public const string FieldInvalidOrNonExistent = "Field Invalid or Non-existent.";
    public const string EntitieInvalid = "Entity Already registered or there is Invalid information, Check!.";
    public const string InvalidAccessData = "Invalid Access Data, Check!.";
    public const string NumberOfInvalidCharacters = "Number of Invalid Characters!";
}