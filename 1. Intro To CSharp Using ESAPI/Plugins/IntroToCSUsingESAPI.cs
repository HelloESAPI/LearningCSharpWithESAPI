using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.ComponentModel;

[assembly: AssemblyVersion("1.0.0.1")]

namespace VMS.TPS
{
  public class Script
  {
    public Script()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    // The method cannot be inlined.Inlining is an optimization by which a method call is replaced with the method body.
    public void Execute(ScriptContext context /*, System.Windows.Window window, ScriptEnvironment environment*/)
    {
      // Common Value Types that we'll use   --   A solid introduction to Value Types: https://www.youtube.com/watch?v=Kl4wiD_TU8Y
      // 0. Bytes   -> sbyte, byte
      // 1. Text    -> char, string
      // 2. Numbers -> int, float, double, decimal
      // 3. Boolean -> bool
      // 4. Dates   -> DateTime

      #region Value Type Examples

      // current plan
      PlanSetup plan = context.PlanSetup;

      // common text examples                               
      var planName = plan.Name;
      string planId = plan.Id;
      char myCharacter = 'A';
      string myString = "A";

      // common number examples
      int numberOfPlans = context.Patient.Courses.First().PlanSetups.Count();
      double? planMaxDose = plan.Dose?.DoseMax3D.Dose;

      if (plan != null)
      {
        // boolean example
        bool planHasDose = plan.IsDoseValid;
        if (planHasDose == true)
        {
          // get dose stats here
        }

      }


      // common date examples
      var structureSet = context.PlanSetup.StructureSet;
      var createdDate = structureSet.Image.CreationDateTime;
      MessageBox.Show(createdDate.Value.DayOfWeek.ToString()); // returns 0-6

      //var person = new Person();
      //var employee = new Employee(person, "RadOnc");

      //var age = 30;




      #endregion Value Type Examples



      // Some Basic Visual Studio Short Cuts
      // 0. Building
      // 1. Line manipulations
      // 2. Commenting

      // readability example - naming convention, explicit value types, comments, etc. 
      // the current plan
      //PlanSetup planSetup = context.PlanSetup;


      // Things To Consider When Writing Code
      // 0. Readability
      // 1. Reusability
      // 2. Version Control
      // 3. Design Principles And Future Projects



      // Object-Oriented Programming --  blog post from Kevin Smith - https://kevinsmith.io/whats-so-great-about-oop/
      // 0. Manipulation of Objects vs. Data
      // 1. Abstraction   -> understanding what the object is and does without needing to know how it does it
      // 2. Inheritance   -> allows one object to possess the same properties and behaviors of another object
      // 3. Encapsulation -> protects the inner workings of an object from the outside world
      // 4. Polymorphism  -> one name, many forms -- an object can behave differently given different circumstances or uses



    }

    #region oop

    class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Address { get; set; }
      public int Age { get; set; }
      public DateTime Birthday { get; set; }

    }
    class Employee : Person
    {
      public string Department { get; set; }
      public bool AbleToDrink { get; private set; }

      private bool IsOver21()
      {
        if (Age >= 21)
        {
          return true;
        }
        else
          return false;
      }
      public bool IsOver21(int age)
      {
        return age >= 21;
      }

      // constructors
      public Employee(string fName, string lName, int age)
      {
        FirstName = fName;
        LastName = lName;
        Age = age;
        AbleToDrink = IsOver21();
      }

      public Employee(Person person, string department)
      {
        FirstName = person.FirstName;
        LastName = person.LastName;
        Age = person.Age;
        Department = department;
        AbleToDrink = IsOver21();
      }

    }

    #endregion oop

  }
}
