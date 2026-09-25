using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class LawOfDementer
    {
        public LawOfDementer() { }

        public void doSomething() { }
        public void MethodCallOfObject()
        {
            doSomething();
        }

        public void MethodCallOfParameter(LawOfDementer parameterClass) 
        {
            parameterClass.doSomething();
        }

        public void MethodCallOfCreation()
        {
            LawOfDementer creationClass = new LawOfDementer();
            creationClass.doSomething();
        }
        private LawOfDementer? uninstantiatedComponent;
        public void MethodCallOfInstantiation()
        {
            uninstantiatedComponent = new LawOfDementer();
            uninstantiatedComponent.doSomething();
        }

        private LawOfDementer? ComposedComponent;
        public LawOfDementer(LawOfDementer lawOfDementer)
        {
            ComposedComponent = lawOfDementer;
        }
        public void MethodCallOfComponent()
        {
            ComposedComponent?.doSomething();
        }
    }
}
