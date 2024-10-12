using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace CSharpCompiler
{
    public static class Compiler
    {
        public static Assembly CompileString(string code, CSharpCompilationOptions options = null)
        {
            string assemblyName = Path.GetRandomFileName();

            Assembly[] usedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<MetadataReference> references = new List<MetadataReference>();
            foreach (Assembly usedAssembly in usedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(usedAssembly.Location));
            }

            CSharpCompilation compilation;
            if (options != null)
            {
                compilation = CSharpCompilation.Create(
                    assemblyName,
                    new[] { CSharpSyntaxTree.ParseText(code) },
                    references: references,
                    options: options
                );
            }
            else
            {
                compilation = CSharpCompilation.Create(
                    assemblyName,
                    new[] { CSharpSyntaxTree.ParseText(code) },
                    references: references
                );
            }

            using var stream = new MemoryStream();
            EmitResult emitResults = compilation.Emit(stream);
            if (!emitResults.Success)
            {
                IEnumerable<Diagnostic> failures = emitResults.Diagnostics.Where(Diagnostic =>
                    Diagnostic.IsWarningAsError || Diagnostic.Severity == DiagnosticSeverity.Error
                );

                foreach (Diagnostic diagnostic in failures)
                {
                    UnityEngine.Debug.LogErrorFormat("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                }
            }
            stream.Position = 0;

            return Assembly.Load(stream.ToArray());
        }

        public static Assembly CompileFile(string path, CSharpCompilationOptions options = null)
        {
            string lines = File.ReadAllText(path).Replace("\n", " ").Replace("\r", " ");
            return CompileString(lines, options);
        }

        public static void RunMethod(this Assembly assembly, string type, string method)
        {
            var func = assembly.GetType(type).GetMethod(method);
            var del = (Action)Delegate.CreateDelegate(typeof(Action), func);
            del.Invoke();
        }
    }
}