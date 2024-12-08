using System;

using System.Runtime.InteropServices.Marshalling;

namespace boogle;

public class Jeu
{

    private Alphabet alphabet;
    private Random random;
    private De[] des ;


    //liste contenant les joueurs de la partie
    private List<Joueur> lJoueur;

    private Parametre parametre;

    private Plateau plateau;

    public Jeu(){
        this.parametre = new Parametre();
        this.random = new Random();
        this.lJoueur = new List<Joueur>();
    
        
    }

    

    public void MessageDemarage(){
        
        
        bool continuer = true;
        while(continuer){
            Console.WriteLine("Que voulez vous faire?\nTapez:");
            Console.WriteLine("1 Jouer a Boogle");
            Console.WriteLine("2 Configurer le jeu");
            Console.WriteLine("3 Quitter le jeu");
            string? sreponse = Console.ReadLine();
            try{
                int reponse = Convert.ToInt32(sreponse);
                if(reponse == 1){
                    continuer = false;
                    this.Jouer();
                }
                else if(reponse == 2)
                {
                    continuer = false;
                    this.parametre.MsgParametrage();
                    this.Jouer();
                }
                else if (reponse == 3)
                {
                    this.Quitter();
                }
            }
            catch(Exception e){
                Console.WriteLine("vVous n'avez pas saisi une des 3 valeurs");
            }
        }
        
    }


    private void Quitter(){
        System.Environment.Exit(1);
    }

    private void Jouer(){
        this.MSgCreerJoueur();
        // il faut initialiser les dés
        this.initialisation();
        // this.LancerPartie();
    }

    public void MSgCreerJoueur(){
        int nb_joueur = 1;
        Boolean continuer = true;
        // liste qui garde en memeoie durant la saisie touts les pseudos deja enregistrés.
        List<string> lpseudo = new List<string>();
        Console.WriteLine("SAISIE DES JOUEURS. Tapez <ENTREE> sans saisir pseudo pour arreter l'ajout de joueur à la partie.\nLe pseudo doit avoir au mois 2 caractères.");
        
        while (continuer){
            Console.WriteLine("Saisissez le pseudo du joueur {0}",nb_joueur);
            string? sreponse = Console.ReadLine();
            if(sreponse.Length == 0){
                continuer = false;
                if(nb_joueur == 0){
                    Console.WriteLine("ATTENTION pas de joueur saisi !");
                    //on quitte le jeu
                }
            }
            else if(sreponse.Length == 1)
            {
                Console.WriteLine("pseudo trop court. Veuillez recommencer");
            }
            else{
                sreponse = sreponse.Trim();
                if(lpseudo.Contains(sreponse)) 
                {
                    Console.WriteLine("Le pseudo a déjà été saisi. Choisissez un autre pseudo");
                }
                else if(sreponse.Length == 0)
                {
                    Console.WriteLine("Pas pseudo saisi. Veuillez en choisir un");
                }
                else
                {
                    Joueur joueur = new Joueur(sreponse);
                    this.lJoueur.Add(joueur);
                    nb_joueur +=1;
                    lpseudo.Add(sreponse);
                }
                
            }
            
        }
        
    }


    public void LancerPartie(){

    }

    public void initialisation()
    {       
        // instanciation des Des
        this.des= new De[(int)Math.Pow(this.parametre.taillePlateau,2)];
        //creation de l'alphabet
        this.alphabet = new Alphabet(this.parametre.taillePlateau);
        // generation des 6 faces pour chque dé
        this.des = De.genererDe(this.alphabet,this.random);
        //creation du plateau
        this.plateau = new Plateau(this.parametre.taillePlateau,this.des,this.random);
       
    }

    

       
}
   
