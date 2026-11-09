using System;
using System.Collections.Generic;

class Program
{
   
    static List<string> palabras = new List<string>()
    {
        "CASA",
        "PERRO",
        "ESCUELA",
        "COMPUTADORA",
        "PROGRAMACION",
        "TELEFONO",
        "MUSICA"
    };

    
    static void Main()
    {
        Random aleatorio = new Random();

        
        string palabra = palabras[
            aleatorio.Next(palabras.Count)
        ];

        // Preparar palabra oculta
        char[] descubiertas =
            new string('_', palabra.Length).ToCharArray();

        HashSet<char> utilizadas = new HashSet<char>();

        int vidas = 6;
        bool gano = false;

        Console.WriteLine("=== JUEGO DEL AHORCADO ===");

        while (vidas > 0 && !gano)
        {
            Console.WriteLine("\nPalabra: " +
                string.Join(" ", descubiertas));

            Console.WriteLine("Vidas restantes: " + vidas);

            Console.WriteLine("Letras utilizadas: " +
                string.Join(", ", utilizadas));

            Console.Write("Ingresa una letra: ");

            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("No puedes dejarlo vacio.");
                continue;
            }

            entrada = entrada.Trim().ToUpper();

           
            if (entrada.Length != 1 ||
                !char.IsLetter(entrada[0]))
            {
                Console.WriteLine(
                    "Ingresa solamente una letra."
                );
                continue;
            }

            char letra = entrada[0];

            
            if (utilizadas.Contains(letra))
            {
                Console.WriteLine("Esa letra ya fue utilizada.");
                continue;
            }

            utilizadas.Add(letra);

          
            if (palabra.Contains(letra))
            {
                Console.WriteLine("¡Correcto!");

                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == letra)
                    {
                        descubiertas[i] = letra;
                    }
                }
            }
            else
            {
                Console.WriteLine("Letra incorrecta.");
                vidas--;
            }

           
            gano = !descubiertas.Contains('_');
        }

        if (gano)
        {
            Console.WriteLine("\n¡FELICIDADES, GANASTE!");
            Console.WriteLine("La palabra era: " + palabra);
        }
        else
        {
            Console.WriteLine("\n¡PERDISTE!");
            Console.WriteLine("La palabra era: " + palabra);
        }

        Console.WriteLine("\nFin del juego.");
    }
}