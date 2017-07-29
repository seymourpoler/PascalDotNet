using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace PascalDotNet.Lexer
{
	public class CodeCILGenerator
	{
		AssemblyBuilder assemblyBuilder;
		ModuleBuilder moduleBuilder;

		public CodeCILGenerator ()
		{
			var domain = Thread.GetDomain();
			var assembyName = new AssemblyName(){
				Version = new System.Version(0,0,0,1),
				//TODO: change
				Name = "OutPut"};
			assemblyBuilder = domain.DefineDynamicAssembly (assembyName, AssemblyBuilderAccess.Save);
			moduleBuilder = assemblyBuilder.DefineDynamicModule(assembyName.Name, "OutPut.exe"/*TODO: change*/);
			assemblyBuilder.SetEntryPoint (BuildMainMethod(), PEFileKinds.ConsoleApplication);
		}

		public void Generate()
		{
			throw new NotImplementedException ();
		}

		private MethodBuilder BuildMainMethod()
		{
			var type = moduleBuilder.DefineType("Application",
				TypeAttributes.Public|TypeAttributes.Class);
			return type.DefineMethod("Main",
				MethodAttributes.Public|
				MethodAttributes.Static,
				typeof(int), new Type[] { typeof(string[]) });
		}
	}
}
