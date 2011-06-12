using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EnvDTE;

namespace YongFa365.BatchFormat
{
    public static class ConfigHelper
    {
        private static string filePath = "BatchFormat.config";
        private static List<string> lstEndsWith = new List<string> { "AssemblyInfo.cs", ".designer.cs", "Reference.cs" };

        public static void Save(string[] item)
        {
            var result = item.ToList().FindAll(p => !string.IsNullOrWhiteSpace(p));

            if (result.Count == 0)
            {
                result = lstEndsWith;
            }
            File.WriteAllText(filePath, ToXml<List<string>>(result));
        }

        public static List<string> Load()
        {
            List<string> endsWith = null;

            try
            {
                endsWith = FromXml<List<string>>(File.ReadAllText(filePath));
            }
            catch
            {
            }


            if (endsWith == null)
            {
                endsWith = lstEndsWith;
            }

            return endsWith;
        }

        public static string ToXml<T>(T item)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");
                serializer.Serialize(stream, item, namespaces);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }


        public static T FromXml<T>(string str)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

    }







    public static class IEnumerableExtensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> source, Action<TItem> action)
        {
            foreach (TItem local in source)
            {
                action(local);
            }
        }
    }


    public sealed class ProjectIterator : IEnumerable<Project>
    {
        private Solution solution;

        public ProjectIterator(Solution solution)
        {
            if (solution == null)
            {
                throw new ArgumentNullException("solution");
            }
            this.solution = solution;
        }

        private IEnumerable<Project> Enumerate(Project project)
        {
            IEnumerator enumerator = project.ProjectItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ProjectItem current = (ProjectItem)enumerator.Current;
                if (current.Object is Project)
                {
                    if (((Project)current.Object).Kind != "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
                    {
                        yield return (Project)current.Object;
                    }
                    else
                    {
                        foreach (Project iteratorVariable1 in this.Enumerate((Project)current.Object))
                        {
                            yield return iteratorVariable1;
                        }
                    }
                }
            }
        }

        public IEnumerator<Project> GetEnumerator()
        {
            IEnumerator enumerator = this.solution.Projects.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Project current = (Project)enumerator.Current;
                if (current.Kind != "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
                {
                    yield return current;
                }
                else
                {
                    foreach (Project iteratorVariable1 in this.Enumerate(current))
                    {
                        yield return iteratorVariable1;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


    }


    public sealed class ProjectItemIterator : IEnumerable<ProjectItem>, IEnumerable
    {
        private ProjectItems items;

        public ProjectItemIterator(ProjectItems items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            this.items = items;
        }

        private IEnumerable<ProjectItem> Enumerate(ProjectItems items)
        {
            IEnumerator enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ProjectItem current = (ProjectItem)enumerator.Current;
                yield return current;
                foreach (ProjectItem iteratorVariable1 in this.Enumerate(current.ProjectItems))
                {
                    yield return iteratorVariable1;
                }
            }
        }

        public IEnumerator<ProjectItem> GetEnumerator()
        {
            return this.Enumerate(this.items).Select<ProjectItem, ProjectItem>
                (item => { return item; }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


    }
}
