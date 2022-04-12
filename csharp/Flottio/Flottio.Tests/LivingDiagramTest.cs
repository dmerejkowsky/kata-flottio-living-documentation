using DotNetGraph;
using System;
using System.Reflection;
using Xunit;

namespace Flottio.Tests
{
    public class LivingDiagramTest
    {

        private DotGraph graph = new DotGraph("Hexagonal Architecture");

        [Fact]
        public void generateDiagram()
        {
            Assembly flottioAssembly = typeof(Basket).Assembly;


            //            String prefix = "flottio.fuelcardmonitoring";
            //            ImmutableSet<ClassInfo> allClasses = classPath.getTopLevelClassesRecursive(prefix);

            //            Digraph digraph = graph.getDigraph();
            //            digraph.setOptions("rankdir=LR");

            //            Stream<ClassInfo> domain = allClasses.stream().filter(filter(prefix, "domain"));
            //            Cluster core = digraph.addCluster("hexagon");
            //            core.setLabel("Core Domain");

            //            // add all domain model elements first
            //            domain.forEach(new Consumer<ClassInfo>()
            //            {

            //            public void accept(ClassInfo ci)
            //            {
            //                Class clazz = ci.load();
            //                core.addNode(clazz.getName()).setLabel(clazz.getSimpleName()).setComment(clazz.getSimpleName());
            //            }
            //        });

            //		Stream<ClassInfo> infra = allClasses.stream().filter(filterNot(prefix, "domain"));
            //        infra.forEach(new Consumer<ClassInfo>() {
            //			public void accept(ClassInfo ci)
            //        {
            //            Class clazz = ci.load();
            //            digraph.addNode(clazz.getName()).setLabel(clazz.getSimpleName()).setComment(clazz.getSimpleName());
            //        }
            //    });
            //infra = allClasses.stream().filter(filterNot(prefix, "domain"));
            //infra.forEach(new Consumer<ClassInfo>()
            //{
            //			public void accept(ClassInfo ci)
            //    {
            //        Class clazz = ci.load();
            //        // API
            //        for (Field field : clazz.getDeclaredFields())
            //        {
            //            Class <?> type = field.getType();
            //            if (!type.isPrimitive())
            //            {
            //                digraph.addExistingAssociation(clazz.getName(), type.getName(), null, null,
            //                        ASSOCIATION_EDGE_STYLE);
            //            }
            //        }

            //        // SPI
            //        for (Class intf : clazz.getInterfaces())
            //        {
            //            digraph.addExistingAssociation(intf.getName(), clazz.getName(), null, null, IMPLEMENTS_EDGE_STYLE);
            //        }
            //    }
            //});

            //// then wire them together
            //domain = allClasses.stream().filter(filter(prefix, "domain"));
            //domain.forEach(new Consumer<ClassInfo>()
            //{

            //            public void accept(ClassInfo ci)
            //{
            //    Class clazz = ci.load();
            //    for (Field field : clazz.getDeclaredFields()) {
            //    Class <?> type = field.getType();
            //    if (!type.isPrimitive())
            //    {
            //        digraph.addExistingAssociation(clazz.getName(), type.getName(), null, null,
            //                ASSOCIATION_EDGE_STYLE);
            //    }
            //}

            //for (Class intf : clazz.getInterfaces())
            //{
            //    digraph.addExistingAssociation(intf.getName(), clazz.getName(), null, null, IMPLEMENTS_EDGE_STYLE);
            //}
            //			}
            //		});

            //// render into image
            //String template = readTestResource("viz-template.html");

            //String title = "Living Diagram";
            //String content = graph.render().trim();
            //String text = evaluate(template, title, content);
            //write("", "livinggdiagram.html", text);
            //	}

            //	private Predicate<ClassInfo> filter(String prefix, String layer)
            //{
            //    return new Predicate<ClassInfo>()
            //    {

            //            public boolean test(ClassInfo ci)
            //    {
            //        boolean nameConvention = ci.getPackageName().startsWith(prefix)
            //                && !ci.getSimpleName().endsWith("Test") && !ci.getSimpleName().endsWith("IT")
            //                && ci.getPackageName().endsWith("." + layer);
            //        return nameConvention;
            //    }

            //};
            //	}

            //	private Predicate<ClassInfo> filterNot(String prefix, String layer)
            //{
            //    return new Predicate<ClassInfo>()
            //    {

            //            public boolean test(ClassInfo ci)
            //    {
            //        boolean nameConvention = ci.getPackageName().startsWith(prefix)
            //                && !ci.getSimpleName().endsWith("Test") && !ci.getSimpleName().endsWith("IT")
            //                && !ci.getPackageName().endsWith("." + layer);
            //        return nameConvention;
            //    }

            //};
            //	}
        }

    }
}
