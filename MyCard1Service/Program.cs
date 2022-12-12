// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Runtime.Loader;
using MyCard1PluginBase;
namespace MyCard1Service
{
    public class Program
    {
        private static Dictionary<string, IMyCard1Plugin> Plugins = new Dictionary<string, IMyCard1Plugin>();

        private static string PluginPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"Plugins"));

        public static void Main(string[] args)
        {
            Console.WriteLine("Application Started");
            LoadPlugins();
            foreach (var key in Plugins.Keys)
            {
                Plugins[key].MakePayment();
            }
        }

        public static void LoadPlugins()
        {
            foreach (var dll in Directory.GetFiles(PluginPath, "*.dll"))
            {
                AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(dll);
                Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                var MyCard1Plugin = Activator.CreateInstance(assembly.GetTypes()[2]) as IMyCard1Plugin;
                if (MyCard1Plugin != null)
                {
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), MyCard1Plugin);
                }
            }
        }
    }
   
}



