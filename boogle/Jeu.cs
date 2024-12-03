using System;
using System.IO.Pipes;
using System.Runtime.InteropServices.Marshalling;

namespace boogle;

public class Jeu
{
    
    private Alphabet alphabet;
    private Random random;
    private De[] des ;

    private Parametre parametre;

    public Jeu(){
        this.parametre = new Parametre();
        this.random = new Random();
    
        
    }

    private void finirInstanciation(){
        this.des= new De[(int)Math.Pow(this.parametre.taillePlateau,2)];
        this.alphabet = new Alphabet(this.parametre.taillePlateau);
        // manque le dictionnaire
       
    }

    public void MessageDemarage(){
        
        
        bool continuer = true;
        while(continuer){
            Console.WriteLine("Que voulez vous faire?\nTapez:");
            Console.WriteLine("1 Jouer a Boogle");
            Console.WriteLine("2 Configurer le jeu");
            Console.WriteLine("3 Quitter le jeu");
            string sreponse = Console.ReadLine();
            try{
                int reponse = Convert.ToInt32(sreponse);
                if(reponse == 1){
                    this.Jouer();
                }
                else if(reponse == 2){
                    this.parametre.MsgParametrage();
                }
            }
            catch(Exception e){

            }
            finally
            {
                
            }
        }
        
    }

    private void Jouer(){
        this.MSgCreerJoueur();
        this.LancerPartie
    }

    public void MSgCreerJoueur(){

    }


    public void LancerPartie(){

    }

    public void initialisation()
    {
        this.genererDes();
        Plateau plateau = new Plateau(this.parametre.taillePlateau,this.des,this.random);
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
   
