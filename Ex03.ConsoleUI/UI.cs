using System;
using System.Collections.Generic;
using System.Text;

/// For us
// communication with user -

// #1 overriding ToString methods - as well as Equal and other methods of Object  (for polymorphysm)
// #2 storing placeholders content for the string format string - for messages for communication with user 
// #3 leaving the enumeration structure of instance as is with switch architecture 
// #4 deciding whether the instance class will be static or not- more likely static 
// #5 UI - checking the validation of input- using logic methods of Logic layer

//strings discussion

// Generating strings - (implemented in) Logic layer (override - #1)
// Processing the strings (made by user input) into types- #4
// parsing from string to types -   (implemented in)- the UI layer
// generating a string - this included in the 

//exception discussion - 

//exception will be thrown at the logic layer
// This additional to validation checks in the Logic layer- for "Independence" and "Reuseability" of Logic layer
// UI LAYER- #5 - most likely using boolean variables 

//memory storage in Garage object class-  

// #6 using dictionary<> of int keys (made of string) and objects of vehicles
// Explanation : - using polymorphism by overriding .GetHashCode() that by default works on reference-  need to make a key from strings represent license number
// #7 using dictionary<> for driver details of int keys (same logic as #6) and objects of array of 2 strings- name and the other thing describes a driver
// using enumeration class - optional 
// adding enum variable for describing the status of a vehicle in the garage- 3 status modes 

// optional readonly for collection!!!
// Generating only once- suitable for collection of cars and collection of drivers' details mentioned in #7


namespace Ex03.ConsoleUI
{
     using GarageLogic;
     internal class UI
     {
          public static void OpenGarageForBusiness()
          {
               Garage MyGarage = new Garage();

               
          }

     }

}
