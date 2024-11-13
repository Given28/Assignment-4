using MyGardeningApp;
using System;
using System.Collections.Generic;

namespace MyGardeningApp
{
    public class Greenhouse
    {
        // Private class attributes
        private string name;
        private double temperature; // in Celsius
        private double humidity; // in percentage
        private Dictionary<string, int> plants; // Plant name and quantity
        private bool isActive;

        // Building method
        public Greenhouse(string name)
        {
            this.name = name;
            this.temperature = 24.0; // Default temperature
            this.humidity = 60.0; // Default humidity
            this.plants = new Dictionary<string, int>();
            this.isActive = true; // Default to active
        }

        // Public method to introduce plants
        public void AddPlants(string plant, int quantity)
        {
            if (plants.ContainsKey(plant))
            {
                plants[plant] += quantity;
            }
            else
            {
                plants[plant] = quantity;
            }
            Console.WriteLine($"Added {quantity} {plant}(s). Total {plant}(s): {plants[plant]}.");
        }

        // Public method to remove plants
        public void RemovePlants(string plant, int quantity)
        {
            if (plants.ContainsKey(plant) && plants[plant] >= quantity)
            {
                plants[plant] -= quantity;
                Console.WriteLine($"Removed {quantity} {plant}(s). Remaining {plant}(s): {plants[plant]}.");
            }
            else
            {
                Console.WriteLine($"Not enough {plant}(s) to remove.");
            }
        }

        // Public method to set temperature
        public void SetTemperature(double newTemperature)
        {
            temperature = newTemperature;
            Console.WriteLine($"Temperature set to {temperature}°C.");
        }

        // Public method to set humidity
        public void SetHumidity(double newHumidity)
        {
            humidity = newHumidity;
            Console.WriteLine($"Humidity set to {humidity}%.");
        }

        // Private method to check status of greenhouse
        private void CheckStatus()
        {
            Console.WriteLine($"Greenhouse {name} - Temperature: {temperature}°C, Humidity: {humidity}%, Is Active: {isActive}");
            Console.WriteLine("Current plants in the greenhouse:");
            foreach (var plant in plants)
            {
                Console.WriteLine($"{plant.Key}: {plant.Value} units");
            }
        }

        // Public method to display greenhouse details
        public void DisplayGreenhouseDetails()
        {
            CheckStatus(); // Calling a private method from a public method
        }

        // Public method to deactivate the greenhouse
        public void Deactivate()
        {
            isActive = false;
            Console.WriteLine($"The greenhouse {name} has been deactivated.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Generating an instance of the Greenhouse class
        Greenhouse myGreenhouse = new Greenhouse("My Delightful Greenhouse");


        // Executing methods on the Greenhouse instance
        myGreenhouse.DisplayGreenhouseDetails();
        myGreenhouse.AddPlants("Potatoe", 20);
        myGreenhouse.AddPlants("Carrot", 15);
        myGreenhouse.RemovePlants("Potatoe", 5);
        myGreenhouse.SetTemperature(22.5);
        myGreenhouse.SetHumidity(65);
        myGreenhouse.DisplayGreenhouseDetails();
        myGreenhouse.Deactivate();

        // Uncomment the next line to invoke a private method directly (will cause a compilation error)
        // myGreenhouse.CheckCondition
    }
}
