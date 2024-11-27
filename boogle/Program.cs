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
        int[] entiers = new int[4];
        entiers[0] = 1;
        entiers[1] = 2;

        Console.WriteLine("taille {0}",entiers.Length);
        Console.WriteLine("count {0}",entiers.Count());

        // Prog.testPartie();
    }   



}

