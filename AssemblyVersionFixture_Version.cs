[TestFixture]
public class AssemblyVersionFixture
{
	[Test]
	// TODO: Figure out what we're testing here! Was there a bug?
	public void Version()
	{
		Version version = new Version("1.0.0.2002");
		string nameString = "TestAssembly";

		AssemblyName assemblyName = new AssemblyName(); 
		assemblyName.Name = nameString;
		assemblyName.Version = version;
		MakeDynamicAssembly(assemblyName);

		Assembly assembly = FindAssemblyByName(nameString);

		System.Version foundVersion = assembly.GetName().Version;
		Assert.AreEqual(version, foundVersion);
	}
}

