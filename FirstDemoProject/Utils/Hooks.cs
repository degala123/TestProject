using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace FirstDemoProject.Utils
{
    [Binding]
    public sealed class Hooks : DriverManager
    {
        public Hooks(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitiateDriver("CHROME");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CleanUp();
        }
    }
}
