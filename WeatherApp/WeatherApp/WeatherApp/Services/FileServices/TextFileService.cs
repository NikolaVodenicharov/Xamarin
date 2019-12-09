using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WeatherApp.Services.FileServices
{
    public class TextFileService : ITextFileService
    {
        // more generic, move to generic file service, not to TextFileService ?
        public List<string> GetEmbederResourceNames()
        {
            var assemblyAnchor = this.EnsureAssemblyAnchor();
            var assembly = IntrospectionExtensions.GetTypeInfo(assemblyAnchor).Assembly;

            var names = assembly.GetManifestResourceNames().ToList();
            return names;
        }

        /// <summary>
        /// Read all lines of text file and return them as collections of strings.
        /// </summary>
        /// <param name="resourceName">The name of file</param>
        /// <param name="assemblyAnchor">The assemly of the file. If not specified, a default one is used.</param>
        /// <returns></returns>
        public List<string> ReadAllLines(string resourceName, Type assemblyAnchor = null)
        {
            assemblyAnchor = this.EnsureAssemblyAnchor(assemblyAnchor);
            var assembly = this.GetAssembly(assemblyAnchor);
            var stream = assembly.GetManifestResourceStream(resourceName);

            var lines = new List<string>();

            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    lines.Add(line);
                }
            }

            return lines;
        }

        /// <summary>
        /// If no type to get assembly is passed, it takes type of the current class
        /// </summary>
        private Type EnsureAssemblyAnchor(Type assemblyAnchor = null)
        {
            if (assemblyAnchor == null)
            {
                assemblyAnchor = typeof(TextFileService);
            }

            return assemblyAnchor;
        }

        private Assembly GetAssembly(Type assemblyAnchor)
        {
            return IntrospectionExtensions.GetTypeInfo(assemblyAnchor).Assembly;
        }
    }
}
