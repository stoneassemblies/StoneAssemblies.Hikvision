string NuGetVersionV2 = "";
string SolutionFileName = "src/StoneAssemblies.Hikvision.sln";

string[] DockerFiles = System.Array.Empty<string>();

string[] OutputImages = System.Array.Empty<string>();

string[] ComponentProjects  = new [] {
	"./src/StoneAssemblies.Hikvision/StoneAssemblies.Hikvision.csproj"
};

string TestProject = "src/StoneAssemblies.Hikvision.Tests/StoneAssemblies.Hikvision.Tests.csproj";

string SonarProjectKey = "stoneassemblies_StoneAssemblies.Hikvision";
string SonarOrganization = "stoneassemblies";