// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using boogle;

using System;

class Prog {

/*
    public static void testJeu(){
        Console.WriteLine("dans testPartie");
        Jeu partie = new Jeu(4,"FR");
        
        
    }
*/
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


    public static void testerParametre(){
        Parametre parametre = new Parametre();
        Console.WriteLine(parametre.ToString());
        parametre.ChangerTaillePLateau();
        Console.WriteLine(parametre.ToString());

    }


    public static void testJeu(){
        Jeu jeu = new Jeu();
        jeu.MessageDemarage();
    }


    public static void testSablier()
    {
        Sablier sablier = new Sablier(5);
        sablier.Start();
        while(sablier.TempsSEcoule()){
            Console.WriteLine(sablier.ToString());
            string s = Console.ReadLine();
            Console.WriteLine(s);
        }
    }
    
    public static void DebugDicoLangue(){
        string langue = "FR";
        DicoLangueV2 dicoLangueV2= new DicoLangueV2(langue);
        // il faut mettre le mot en majuscule
        string mot = "ZZZZ";
        bool result = dicoLangueV2.RechDichoRecursif(mot);       
        Console.WriteLine("{0} appartient au dico : {1}",mot,result);
        mot = "SOIN";
        result = dicoLangueV2.RechDichoRecursif(mot);
        Console.WriteLine("{0} appartient au dico : {1}",mot,result);
        Console.WriteLine(dicoLangueV2.toString());
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

        // Partie partie = new Partie(4,"FR");
        // partie.generer();

        // // test Jeu
        // Jeu jeu = new Jeu(4,"FR");
        // jeu.initialisation();

        // testerParametre();
        //testJeu();

        //testSablier();


        // test de dé
        // testDe();

        // test Alphabet
        // testCreationAlphabet();


        DebugDicoLangue();
    
    }   



}

