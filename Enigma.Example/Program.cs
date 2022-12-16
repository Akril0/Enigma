using System;
using System.IO;

namespace Enigma.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enigma machine emulator:");
			string pathIn = @"../../../Input.txt";
            string pathOut = @"../../../Output.txt";
			if(!File.Exists(pathOut)) 
			{
				using (FileStream fs = File.Create(pathOut)); 
			}
			
                string data = File.ReadAllText(pathIn);
            Enigma e = new Enigma();

			//Plugboard
			e.Plugboard.Add('X', 'D');
			e.Plugboard.Add('A', 'V');
			
			//Rotors
			e.Rotors.Add(RotorType.Rotor_I, 'A');
			e.Rotors.Add(RotorType.Rotor_II, 'B');
			e.Rotors.Add(RotorType.Rotor_III, 'C');
            e.Rotors.Add(RotorType.Rotor_IV, 'D');
            e.Rotors.Add(RotorType.Rotor_V, 'E');

            //Reflector
            e.Rotors.SetReflector(ReflectorType.UWK_B);

			string result = e.Encrypt(data);

			Console.WriteLine("Input: " + data);
			Console.WriteLine("Output: " + result);
            File.WriteAllText(pathOut, result);

            Console.WriteLine();
			Console.Read();
		}
	}
}
