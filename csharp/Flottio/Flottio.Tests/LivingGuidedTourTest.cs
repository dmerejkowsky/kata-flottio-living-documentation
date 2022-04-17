using System;
using System.Collections.Generic;
using System.Text;
using NFluent;
using Xunit;
using Xunit.Abstractions;

namespace Flottio.Tests
{
    public class LivingGuidedTourTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LivingGuidedTourTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        private const string SEP = "\n\n";
		private const string CONTEXT_PREFIX = "flottio.fuelcardmonitoring";
        private const string ANNOTATION_NAME = "flottio.annotations.GuidedTour";
        private const string REPO_LINKS_PREFIX = "https://github.com/cyriux/livingdocumentation-workshop/blob/master/living-documentation-workshop";
        // private PrintWriter writer;
        //
        private readonly Dictionary<string, Tour> tours = new Dictionary<string, Tour>();
        private class Tour {
	        public SortedDictionary<int, string> Sites = new SortedDictionary<int, string>();
        
	        public string put(int step, string describtion) {
		        Sites.Add(step, describtion);
		        return describtion;
	        }
        
	        public override string ToString() {
		        return Sites.ToString();
	        }
        }
        
        // private static class TourStep {
	       //  private final String name;
	       //  private final String description;
	       //  private final int step;
        //
	       //  public String name() {
		      //   return name;
	       //  }
        //
	       //  public String description() {
		      //   return description;
	       //  }
        //
	       //  public int step() {
		      //   return step;
	       //  }
        //
	       //  public TourStep(String name, String description, int step) {
		      //   this.name = name;
		      //   this.description = description;
		      //   this.step = step;
	       //  }
        //
        // }

        [Fact]
        public void test()
        {
            
                //     JavaProjectBuilder builder = new JavaProjectBuilder();
            //     // Adding all .java files in a source tree (recursively).
            //     builder.addSourceTree(new File("src/main/java"));
            //     printAll(builder);
            //
            string content;
            
            var template = TemplateFiller.ReadTemplate("./Ressources/strapdown-template.html");

            StringBuilder sb = new StringBuilder();
            foreach (string tourName in tours.Keys)
            {
	            sb.Append(WriteSightSeeingTour(tourName, template));
            }
            //writer.close();
            
            //TemplateFiller.CreateTargetFile(content, "./Ressources/strapdown-template.html", "Quick_Developer_Tour.html");

            Check.That(sb.ToString()).IsNotEmpty();
            
        }
        
        private string WriteSightSeeingTour(string tourName, string template) {
	        
			StringBuilder sb = new StringBuilder();
			// writer = new PrintWriter(out);
			Tour tour = tours[tourName];
			int count = 1;
			foreach (string step in tour.Sites.Values) {
				sb.Append(SEP);
				sb.Append("## " + count++ + ". " + step);
			}
			string title = tourName;
			string content = sb.ToString();
			string text = string.Format(template, new Object[] { title, content });
			// write("", tourName.replaceAll(" ", "_") + ".html", text);
			return string.Empty;
        }
 //
	// private void printAll(JavaProjectBuilder builder) {
	// 	for (JavaPackage p : builder.getPackages()) {
	// 		if (!p.getName().startsWith(CONTEXT_PREFIX)) {
	// 			continue;
	// 		}
	// 		final TourStep step = getQuickDevTourStep(p);
	// 		if (step != null) {
	// 			// process(p);
	// 		}
	// 	}
	// 	for (JavaClass c : builder.getClasses()) {
	// 		if (!c.getPackageName().startsWith(CONTEXT_PREFIX)) {
	// 			continue;
	// 		}
	// 		process(c);
	// 	}
 //
	// }
 //
	// private TourStep getQuickDevTourStep(JavaAnnotatedElement doc) {
	// 	for (JavaAnnotation annotation : doc.getAnnotations()) {
	// 		if (annotation.getType().getFullyQualifiedName().equals(ANNOTATION_NAME)) {
	// 			final String tourName = (String) annotation.getNamedParameter("name");
	// 			final String step = (String) annotation.getNamedParameter("rank");
	// 			final String desc = (String) annotation.getNamedParameter("description");
	// 			return new TourStep(tourName.replaceAll("\"", ""), desc.replaceAll("\"", ""), Integer.valueOf(step));
	// 		}
	// 	}
	// 	return null;
	// }
 //
	// protected String title(final String title) {
	// 	return "\n### " + title;
	// }
 //
	// protected String listItem(final String bullet) {
	// 	return "- " + bullet;
	// }
 //
	// protected String link(final String name, String url) {
	// 	return "[" + name + "](" + url + ")";
	// }
 //
	// protected String linkSrcJava(final String name, String qName, int lineNumber) {
	// 	return link(name, REPO_LINKS_PREFIX + "/src/main/java/" + qName.replace('.', '/') + ".java#L" + lineNumber);
	// }
 //
	// protected void process(JavaClass c) {
	// 	final String comment = blockQuote(c.getComment());
	// 	addTourStep(getQuickDevTourStep(c), c.getName(), c.getFullyQualifiedName(), comment, c.getLineNumber());
 //
	// 	if (c.isEnum()) {
	// 		for (JavaField field : c.getEnumConstants()) {
	// 			// printEnumConstant(field);
	// 		}
	// 		for (JavaMethod method : c.getMethods(false)) {
	// 			//
	// 		}
	// 	} else if (c.isInterface()) {
	// 		for (JavaClass subClass : c.getDerivedClasses()) {
	// 			// printSubClass(subClass);
	// 		}
	// 	} else {
	// 		for (JavaField field : c.getFields()) {
	// 			// printField(field);
	// 		}
	// 		for (JavaMethod m : c.getMethods(false)) {
	// 			final String name = m.getCallSignature();
	// 			final String qName = c.getFullyQualifiedName();
	// 			final String codeBlock = code(m.getCodeBlock());
	// 			final int lineNumber = m.getLineNumber();
	// 			final TourStep step = getQuickDevTourStep(m);
	// 			addTourStep(step, name, qName, codeBlock, lineNumber);
 //
	// 		}
	// 	}
	// }
 //
	// private String code(String codeBlock) {
	// 	return "\n```\n" + codeBlock + "\n```";
	// }
 //
	// private String blockQuote(String quote) {
	// 	return quote == null ? "" : "> " + quote.replaceAll("\n", "\n> ");
	// }
 //
	// private void addTourStep(final TourStep step, final String name, final String qName, final String comment,
	// 		final int lineNumber) {
	// 	if (step != null) {
	// 		final StringBuilder content = new StringBuilder();
	// 		// content.append(name);
	// 		content.append(linkSrcJava(name, qName, lineNumber));
	// 		if (step.description() != null) {
	// 			content.append(SEP);
	// 			content.append("*" + step.description().trim() + "*");
	// 		}
	// 		if (comment != null) {
	// 			content.append(SEP);
	// 			content.append(comment);
	// 		}
	// 		content.append(SEP);
 //
	// 		getTourNamed(step.name()).put(step.step(), content.toString());
	// 	}
	// }
 //
	// private Tour getTourNamed(String name) {
	// 	Tour tour = tours.get(name);
	// 	if (tour == null) {
	// 		tour = new Tour();
	// 		tours.put(name, tour);
	// 	}
	// 	return tour;
	// }
    }
}