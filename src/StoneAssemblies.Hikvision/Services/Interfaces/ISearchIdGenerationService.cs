namespace StoneAssemblies.Hikvision.Services.Interfaces;

public interface ISearchIdGenerationService
{
    string Next();

    void Release(string searchId);
}