using System;
using System.Runtime.InteropServices.Marshalling;

namespace boogle;

public class Partie
{
    public int taillePlateau { get; set;}
    public string langue { get; set;}

    private Alphabet alphabet;
    private Random random;
    private De[] des ;

    public Partie(int taille_plateau,string langue){
        this.taillePlateau = taille_plateau;
        this.langue = langue;
        this.des= new De[(int)Math.Pow(this.taillePlateau,2)];
        this.alphabet = new Alphabet(taille_plateau);
        this.random = new Random();
    }

    public void generer(){
        Console.WriteLine("----------------------------------------------------------");
        for (int idx = 0 ; idx< (int) Math.Pow(this.taillePlateau,2) ; idx++) {
            this.des[idx]   = new De() ;
        }

       
    }
   
}