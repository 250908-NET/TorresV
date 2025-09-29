using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
     internal class Human2
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int age;

        // Parameterless constructor
        public Human2() { }

        // Constructor with all values (note: order matches the TEST: eyeColor then age)
        public Human2(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        // Constructor with name + eyeColor
        public Human2(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        // Constructor with name + age
        public Human2(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        // Method AboutMe (same as Human)
        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }

        // Method AboutMe2 with conditionals
        public string AboutMe2()
        {
            string result = $"My name is {firstName} {lastName}.";
            if (age > 0) result += $" My age is {age}.";
            if (!string.IsNullOrEmpty(eyeColor)) result += $" My eye color is {eyeColor}.";
            return result;
        }

        // Property with validation
        private int weight;
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 0 || value > 400)
                {
                    weight = 0;
                }
                else
                {
                    weight = value;
                }
            }
        }
    } // end of class
} // end of namespace
