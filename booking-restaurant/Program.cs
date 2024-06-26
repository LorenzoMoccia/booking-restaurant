﻿//NEXT STEPS:
//Implementare la possibilità ad ogni tavolo di ordinare un piatto
//Implementare la possibilità di vedere l'ordine effettuato da ogni singolo tavolo


//MAIN METHOD
Ristorante ristorante = new("Assaje");
Console.WriteLine($"Benvenuto nel sistema di prenotazione del ristorante: {ristorante.StampaNome()}");

Ristorante.Persona persona = new("Pinco", "Pallino");


while(true)
{
    Console.WriteLine("[1] Prenota un tavolo | [2] Exit");
    int operazione = Convert.ToInt32(Console.ReadLine());

    switch (operazione)
    {
        case 1:

            Console.WriteLine("Inserisci il numero del tavolo per il quale vuoi prenotare:");
            int numeroTavolo = Convert.ToInt32(Console.ReadLine());
            persona.PrenotaTavolo(numeroTavolo);

            break;

        case 2:
            break;
    }

}





class Ristorante
{
    //Propietà
    string nome;
    static Tavolo[] tavoli = new Tavolo[5];

    //Costruttore
    public Ristorante(string name)
    {
        this.nome = name;
        Setup();
        Console.WriteLine();
    }


    //Methods
    static void Setup()
    {
        

        Console.WriteLine("LISTA DEI TAVOLI:");

        for (int i = 0; i < tavoli.Length; i++ )
        {
            tavoli[i] = new Tavolo(i + 1);
        }
    }

    //Stampa il nome del ristorante
    public string StampaNome()
    {
        return this.nome; 
    }



    
    public class Persona
    {
        //Propietà
        string nome;
        string cognome;
        int numeroTavoloPrenotato;
        bool giaPrenotato;


        //Costruttore
        public Persona(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
        }

        //Methods

        public void PrenotaTavolo(int numeroTavolo)
        {

            numeroTavoloPrenotato = numeroTavolo;

            if (TuttiITavoliSonoOccupati())
            {
                Console.WriteLine("Tutti i tavoli sono occupati!");
                return;
            }

            else if (giaPrenotato == true)
            {
                Console.WriteLine($"Hai già un tavolo riservato! Numero: {numeroTavoloPrenotato}");
            }
            
            
            if (numeroTavolo > 5 || numeroTavolo < 1)
            {
                Console.WriteLine("ATTENZIONE! Tavolo non esistente. (Da 1 a 5)");

            }
            else
            {
                int indiceTavoli = numeroTavolo - 1;

                if (tavoli[indiceTavoli].occupato == true && numeroTavolo == numeroTavoloPrenotato)
                {
                    Console.WriteLine("Tavolo non disponibile!");
                    Console.WriteLine();
                }
                else if(!giaPrenotato)
                {
                    Console.WriteLine($"PRENOTAZIONE TAVOLO N° {numeroTavolo} EFFETTUATA CON SUCCESSO!!");
                    Console.WriteLine();

                    numeroTavoloPrenotato = numeroTavolo;
                    giaPrenotato = true;
                    tavoli[indiceTavoli].occupato = true;
                }
            }

            //Controllo se tutti i tavoli sono occupati
            bool TuttiITavoliSonoOccupati()
            {
                foreach (var tavolo in tavoli)
                {
                    if (!tavolo.occupato)
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }

    class Tavolo
    {
        public int numeroTavolo;
        public bool occupato;

        public Tavolo(int numeroTavolo)
        {
            this.numeroTavolo = numeroTavolo;
            
        }
    }

}




