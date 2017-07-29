using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace PascalDotNet.Lexer
{
	public class CodeCILGenerator
	{
		AssemblyBuilder assemblyBuilder;

		public CodeCILGenerator ()
		{
			var domain = Thread.GetDomain();
			var assembyName = new AssemblyName(){
				Version = new System.Version(0,0,0,1),
				//TODO: change
				Name = "OutPut"};
			assemblyBuilder = domain.DefineDynamicAssembly (assembyName, AssemblyBuilderAccess.Save);
		}

		public void Generate()
		{
			
		}

	}
}

