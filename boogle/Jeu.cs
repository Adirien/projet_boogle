using System;

//using System.Runtime.InteropServices.Marshalling;

namespace boogle;

public class Jeu
{

    private Alphabet alphabet;
    private Random random;
    private De[] des ;

    private Dicolangue dico;


    //liste contenant les joueurs de la partie
    private List<Joueur> lJoueur;

    private Parametre parametre;

    //private Plateau plateau;

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
            // try{
                int reponse = Convert.ToInt32(sreponse);
                if(reponse == 1){
                    continuer = false;
                    this.Jouer();
                    this.RelancerPartie();
                }
                else if(reponse == 2)
                {
                    continuer = false;
                    this.parametre.MsgParametrage();
                    this.Jouer();
                    this.RelancerPartie();
                }
                else if (reponse == 3)
                {
                    this.Quitter();
                }
            // }
            // catch(Exception e){
            //     Console.WriteLine("Vous n'avez pas saisi une des 3 valeurs");
            // }
        }
        
    }


    private void Quitter(){
        System.Environment.Exit(1);
    }

    private void Jouer(){
        this.MSgCreerJoueur();
        // il faut initialiser les parametres
        this.initialisation();
        // on lance la partie
        this.LancerPartie();
        this.AfficherResulatPartie();
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

    /// <summary>
    /// Onlance une partie. 
    /// Celle-ci est composée par n tours. Dans chque tous , tous les joueurs jouent une seule fois.
    /// </summary>
    public void LancerPartie(){

        for(int num_tour = 1;  num_tour <= this.parametre.NbTour; num_tour ++){
            foreach(Joueur joueur in this.lJoueur){
                joueur.NumeroTour = num_tour;
                //creation du plateau
                Plateau plateau = new Plateau(this.parametre.taillePlateau,this.des,this.random);  
                Tour tour = new Tour(plateau,joueur,this.parametre,this.dico,this.alphabet);
                tour.JouerTour();
            }
        }

    }

    public void initialisation()
    {       
        // instanciation des Des
        this.des= new De[(int)Math.Pow(this.parametre.taillePlateau,2)];
        //creation de l'alphabet
        this.alphabet = new Alphabet(this.parametre.taillePlateau);

        // generation des 6 faces pour chaque dé
        this.des = De.genererDe(this.alphabet,this.random);
        
        //creation du dictionnnaire
        this.dico = new Dicolangue(this.parametre.Langue);
       
    }

    /// <summary>
    /// on affiche dans la console le resultat de la partie avec le score pour chque joueur
    /// ainsi que les mots trouvés par ce dernier à chaque tour.
    /// </summary>
    private void AfficherResulatPartie()
    {
        Console.WriteLine("\nVoici les résultats:");
        foreach(Joueur joueur in this.lJoueur)
        {
            Console.WriteLine(joueur.toString());
            Console.WriteLine("______________________________________");
        }
    }

    private bool RelancerPartie(){
        Console.WriteLine("La partie est terminée. Voulez rejouer ?\nTapez:");
        Console.WriteLine("1 - Pour rejouer (avec les memes joueurs)");
        Console.WriteLine("2 - Pour quitter le jeu");
        while(true)
        {
            try
            {
                string reponse = Console.ReadLine();
                if (reponse == "1"){
                    return true;
                }
                else if (reponse == "2")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Mauvaise saisie. Recommencez SVP");
                }
            }
            catch (Exception ex){
                Console.WriteLine("Une erreur s'est produite");
            }
        }
        
    }// fin relancerpartie

       
}
   
