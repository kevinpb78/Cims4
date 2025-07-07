using Cims4.Core.Entities;
using Cims4.Core.Services;
using Cims4.Infrastructure.Services;

namespace Cims4.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Set the GUID generator here BEFORE any entities are created
            BaseMasterEntity.SetGuidGenerator(new MasterGuidGenerator());

            Application.Run(new Form1());
        }
    }
}