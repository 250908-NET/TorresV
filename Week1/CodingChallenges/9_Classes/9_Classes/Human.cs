using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";

        // Parameterless constructor
        public Human() { }

        // Parameterized constructor
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        // Method
        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        } // end of class
    } //end of namespace

}