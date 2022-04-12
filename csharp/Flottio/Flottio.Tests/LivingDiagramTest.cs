using DotNetGraph;
using DotNetGraph.Attributes;
using DotNetGraph.SubGraph;
using Flottio.FuelCardMonitoring.Domain;
using NFluent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Flottio.Tests
{
    public class LivingDiagramTest
    {

        private DotGraph graph = new DotGraph("Hexagonal Architecture", true);
        [Fact]
        public void GenerateDiagram()
        {
            Assembly flottioAssembly = typeof(Basket).Assembly;

            String prefix = "Flottio.FuelCardMonitoring";
            IEnumerable<Type> allClasses = flottioAssembly.GetTypes();
            var topLevelClasses = allClasses.Where(classe => classe.Namespace.Contains(prefix));

            string domainPrefix = ".Domain";
            var domainClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix + domainPrefix));
            DotSubGraph domainGraph = CreateSubGraph(domainClasses, "Core Domain");
            graph.Elements.Add(domainGraph);

            var infraClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix) && !classe.Namespace.Contains(domainPrefix));
            var infraSubGraph = CreateSubGraph(infraClasses, "Infra");
            graph.Elements.Add(infraSubGraph);

            DotNetGraph.Compiler.DotCompiler compiler = new DotNetGraph.Compiler.DotCompiler(graph);
            var compiledGraph = compiler.Compile();

            string templatePath = "./Ressources/viz-template.html";
            var template = ReadTemplate(templatePath);
            var title = "Living Diagram";
            var text = Evaluate(template, title, compiledGraph);
            Write("livinggdiagram.html", text);

            Check.That(compiledGraph).IsEqualTo("");
        }

        private void Write(string fileFullName, string content)
        {
            using (var streamWriter = new StreamWriter(fileFullName))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private string Evaluate(string template, string title, string content)
        {
            return template.Replace("{0}", title).Replace("{1}", content);
        }

        private string ReadTemplate(string templatePath)
        {
            using (var streamReader = new StreamReader(templatePath))
            {
                return streamReader.ReadToEnd();
            };
        }

        private static DotSubGraph CreateSubGraph(IEnumerable<Type> classes, string subGraphIdentifier)
        {
            DotSubGraph subGraph = new DotSubGraph(subGraphIdentifier);
            foreach (var topLevelClass in classes)
            {
                DotNetGraph.Core.IDotElement typeElement = new DotNetGraph.Node.DotNode(topLevelClass.Name);
                subGraph.Elements.Add(typeElement);
            }
            subGraph.Label = subGraphIdentifier;
            subGraph.Style = DotSubGraphStyle.Dashed;
            subGraph.Color = new DotColorAttribute(Color.Red);

            return subGraph;
        }
    }
}
