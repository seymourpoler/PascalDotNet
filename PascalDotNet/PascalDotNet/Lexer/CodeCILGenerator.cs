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

		public void Generate(Node syntaxTree)
		{
			throw new NotImplementedException ();
			assemblyBuilder.Save ("OutPut.exe"/*TODO: change*/);
		}

		private MethodBuilder BuildMainMethod()
		{
			var type = moduleBuilder.DefineType(
				name: "Application",
				attr: TypeAttributes.Public|TypeAttributes.Class);
			return type.DefineMethod (
				name: "Main",
				attributes: MethodAttributes.Public | MethodAttributes.Static,
				returnType: typeof(int), 
				parameterTypes: new Type[] { typeof(string[]) });
		}
	}
}
