namespace UniversityHousingSystem.Service.Abstractions.Helpers
{
    public interface IPasswordGeneratorService
    {
        string Generate(int length = 12);
    }
}
