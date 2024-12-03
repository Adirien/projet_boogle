// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using boogle;

using System;

class Prog {


    public static void testPartie(){
        Console.WriteLine("dans testPartie");
        Partie partie = new Partie(4,"FR");
        partie.generer();
        
    }

    public static void testCreationAlphabet(){
        Alphabet alphabet = new Alphabet(4);
    }

    public static void testDe(){
        
        Alphabet alphabet = new Alphabet(4);
        De de = new De();

        de.Add(alphabet.DicoLettre["B"]);
        bool is_contient = de.Contient2Fois(alphabet.DicoLettre["A"]);
        Console.WriteLine("le de contient il 2 fois la lettre A ? : {0}",is_contient);

        de.Add(alphabet.DicoLettre["A"]);
        is_contient = de.Contient2Fois(alphabet.DicoLettre["A"]);
        Console.WriteLine("le de contient il 2 fois la lettre A ? : {0}",is_contient);

        de.Add(alphabet.DicoLettre["E"]);
        is_contient = de.Contient2Fois(alphabet.DicoLettre["A"]);
        Console.WriteLine("le de contient il 2 fois la lettre A ? : {0}",is_contient);

        de.Add(alphabet.DicoLettre["A"]);
        is_contient = de.Contient2Fois(alphabet.DicoLettre["A"]);
        Console.WriteLine("le de contient il 2 fois la lettre A ? : {0}",is_contient);

    }

    public static void Main(){
        // Console.WriteLine("Hello, World!");
        // int taille_plateau = 5;
        // Alphabet alphabet= new Alphabet(taille_plateau);
        // // alphabet.readLettreFile();
        // // alphabet.RepartitionFrequenceLettre();

        // // Pour le Dé
        // Random  random = new Random();
        // De de = new De(alphabet,random) ;
        // // de.GenererDe();
        // Console.WriteLine(de.ToString());

        // autre test 

        // int[] entiers = new int[4];
        // entiers[0] = 1;
        // entiers[1] = 2;

        // Console.WriteLine("taille {0}",entiers.Length);
        // Console.WriteLine("count {0}",entiers.Count());

        // // Prog.testPartie();
        Partie partie = new Partie(4,"FR");
        partie.generer();

        // test de dé
        // testDe();

        // test Alphabet
        // testCreationAlphabet();
    
    }   



}

