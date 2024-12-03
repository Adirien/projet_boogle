using System;
using System.Runtime.InteropServices.Marshalling;

namespace boogle;

public class Jeu
{
    public int taillePlateau { get; set;}
    public string langue { get; set;}

    private Alphabet alphabet;
    private Random random;
    private De[] des ;

    public Jeu(int taille_plateau,string langue){
        this.taillePlateau = taille_plateau;
        this.langue = langue;
        this.des= new De[(int)Math.Pow(this.taillePlateau,2)];
        this.alphabet = new Alphabet(taille_plateau);
        this.random = new Random();
    }



    public void initialisation()
    {
        this.genererDes();
        Plateau plateau = new Plateau(this.taillePlateau,this.des,this.random);
        Console.WriteLine(plateau.ToString());


    }

    /// <summary>
    /// Methode qui genere les des
    /// </summary>
    public void genererDes(){
        Console.WriteLine("----------------------------------------------------------");
        this.des = De.genererDe(this.alphabet,this.random);
        // foreach(De de in this.des){
        //     if(de == null){
        //         Console.WriteLine("dé null");
        //     }
        //     else if(de.NombreLettre()>0){
        //         Console.WriteLine(de.ToString());
        //     }
        //     else
        //     {
        //         Console.WriteLine("dé vide");
        //     }
            
     }

       
}
   
