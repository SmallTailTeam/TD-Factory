using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using UnityEngine;
using UnityEngine.UI;

namespace TdFactory.UI.Windows
{
    public class IdeWindow : Window
    {
        public Action<Assembly> Compiled { get; set; }

        [SerializeField] private Text _titleText;
        [SerializeField] private Text _errorsText;
        [SerializeField] private InputField _codeEditor;

        public void SetTitle(string title)
        {
            string[] words = title.Split(' ');
            
            string fileName = "";
            
            foreach (string word in words)
            {
                fileName += $"{char.ToUpper(word[0])}{word.Substring(1)}";
            }

            fileName += ".cs";
            
            _titleText.text = $"Editing {fileName}";
        }

        public void Compile()
        {
            _errorsText.text = "";
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(_codeEditor.text);

            List<Assembly> assemblies = new List<Assembly>
            {
                typeof(IdeWindow).Assembly,
                typeof(Debug).Assembly,
                typeof(object).Assembly
            };
            
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name.Contains("netstandard"))
                {
                    assemblies.Add(assembly);
                }
            }

            IEnumerable<PortableExecutableReference> references = assemblies.Select(assembly => MetadataReference.CreateFromFile(assembly.Location));

            CSharpCompilation compilation = CSharpCompilation.Create(
                Path.GetRandomFileName(),
                new[] {syntaxTree},
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using MemoryStream ms = new MemoryStream();
            
            EmitResult result = compilation.Emit(ms);

            if (!result.Success)
            {
                Diagnostic[] failures = result.Diagnostics.Where(diagnostic => 
                    diagnostic.IsWarningAsError || 
                    diagnostic.Severity == DiagnosticSeverity.Error).ToArray();

                _errorsText.text = $"Error count: {failures.Length}";
                
                foreach (Diagnostic diagnostic in failures)
                {
                    _errorsText.text += $"{Environment.NewLine}{diagnostic.Id}: {diagnostic.GetMessage()}";
                }
            }
            else
            {
                ms.Seek(0, SeekOrigin.Begin);
                Assembly assembly = Assembly.Load(ms.ToArray());
                Compiled?.Invoke(assembly);
            }
        }
    }
}