namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IQRService
    {
        string GenerateAndSaveQRCodeForStudent(string qrText);
    }
}
