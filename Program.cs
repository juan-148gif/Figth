// Juan Camilo y Juan Jose Mejia


using System;
using System.Collections.Generic;

class Pokemon
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Salud { get; set; }
    public List<int> Ataques { get; set; }
    public List<int> Defensas { get; set; }
    private Random rnd = new Random(); // Instancia de Random para evitar repeticiones de valores en ciclos cortos.

    public Pokemon(string nombre, string tipo, int salud)
    {
        this.Nombre = nombre;
        this.Tipo = tipo;
        this.Salud = salud;
        Ataques = new List<int>();
        Defensas = new List<int>();
    }

    public int Atacar()
    {
        int indiceAtaque = rnd.Next(0, Ataques.Count);
        int ataque = Ataques[indiceAtaque];
        return (int)(ataque * (rnd.NextDouble() > 0.5 ? 1 : 1.5));
    }

    public int Defensa()
    {
        int indiceDefensa = rnd.Next(0, Defensas.Count);
        int defensa = Defensas[indiceDefensa];
        return (int)(defensa * (rnd.NextDouble() > 0.5 ? 1 : 0.5));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pokemon pokemon_1 = new Pokemon("Pikachu", "Eléctrico", 100);
        pokemon_1.Ataques.AddRange(new int[] { 20, 30, 40 });
        pokemon_1.Defensas.AddRange(new int[] { 10, 20 });

        Pokemon pokemon_2 = new Pokemon("Charmander", "Fuego", 100);
        pokemon_2.Ataques.AddRange(new int[] { 25, 35, 30 });
        pokemon_2.Defensas.AddRange(new int[] { 15, 25 });

        for (int i = 0; i < 3; i++)
        {
            // Turno de Pikachu
            int ataquePikachu = pokemon_1.Atacar();
            int defensaCharmander = pokemon_2.Defensa();
            Console.WriteLine($"Comienza la batalla entre {pokemon_1.Nombre} y {pokemon_2.Nombre}\n");

            int diferencia1 = ataquePikachu - defensaCharmander;
            if (diferencia1 > 0)
            {
                pokemon_2.Salud -= diferencia1;
            }
             Console.WriteLine($"{pokemon_1.Nombre} ataca con {ataquePikachu} de poder. {pokemon_2.Nombre} se defiende con {defensaCharmander}. {pokemon_2.Nombre} pierde {diferencia1} puntos de salud.");

            // Turno de Charmander
            int ataqueCharmander = pokemon_2.Atacar();
            int defensaPikachu = pokemon_1.Defensa();

            int diferencia2 = ataqueCharmander - defensaPikachu;
            if (diferencia2 > 0)
            {
                pokemon_1.Salud -= diferencia2;
            }
            Console.WriteLine($"{pokemon_2.Nombre} ataca con {ataqueCharmander} de poder. {pokemon_1.Nombre} se defiende con {defensaPikachu}. {pokemon_1.Nombre} pierde {diferencia2} puntos de salud.");

        }

        // Determinar el resultado
        if (pokemon_1.Salud > pokemon_2.Salud)
        {
            Console.WriteLine("Pikachu es el Ganador!");
        }
        else if (pokemon_2.Salud > pokemon_1.Salud)
        {
            Console.WriteLine("Charmander es el Ganador!");
        }
        else
        {
            Console.WriteLine("Poke-Empataron!!");
        }
    }
}