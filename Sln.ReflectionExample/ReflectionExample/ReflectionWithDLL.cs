using System;
using System.Reflection;

namespace ReflectionExample
{
    public static class ReflectionWithDLL
    {
        public static void GetDLLDetails()
        {
            //dynamically load assembly from file TestClassLibrary.dll
            Assembly _TestClassLibraryAssembly = Assembly.LoadFile(@"G:\TheGitCloning\TMP\Sln.ReflectionExample\TestClassLibrary\bin\Debug\TestClassLibrary.dll");

            //get type of class Win32_Process from just loaded assembly
            Type _Win32_ProcessType = _TestClassLibraryAssembly.GetType("TestClassLibrary.Win32_Process");

            //create instance of class Win32_Process
            object _Win32_ProcessInstance = Activator.CreateInstance(_Win32_ProcessType);

            //get info about property: public string Caption
            PropertyInfo captionPropertyInfo = _Win32_ProcessType.GetProperty("Caption");

            //get value of property: public string Caption
            string valueCaption = (string)captionPropertyInfo.GetValue(_Win32_ProcessInstance, null);

            //set value of property: public string Caption
            captionPropertyInfo.SetValue(_Win32_ProcessInstance, "My captions", null);




            Type _SummSubtMulDivType = _TestClassLibraryAssembly.GetType("TestClassLibrary.SummSubtMulDiv");
            object _SummSubtMulDivInstance = Activator.CreateInstance(_SummSubtMulDivType);

            //invoke public instance method: public void Clear()
            //_SummSubtMulDivType.InvokeMember("Summation",
            //    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
            //    null, _SummSubtMulDivInstance, null);


            //invoke public instance method: public int Summation(int number)
            int valueSummation = (int)_SummSubtMulDivType.InvokeMember("Summation",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                null, _SummSubtMulDivInstance, new object[] { 20, 10 });




        }
    }
}
