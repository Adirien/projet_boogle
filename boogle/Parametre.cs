using System;

namespace boogle;
/// <summary>
/// classe qui genere les parametres du jeux:
/// - taille du plateau
/// - langue du dictionnaire 
/// - chemin vers les fichiers : lettres.txt et les dictionnaires
/// - duree d'un tour pour un joueur(en secondes)
/// - nombre de tours pour chquae joueur
/// 
/// La saisie se fait en mode console.
/// la verification de la saisie se fait egalement dans la methode invoquée
/// </summary>
public class Parametre
{


        public int taillePlateau= 4;
        public int TaillePlateau {
                get{return taillePlateau;}
        }
        
        private string langue = "FR";
        public string Langue{
                get{return langue;}
        }

        private int dureeTour= 60;
        public int DureeTour{
                get{return dureeTour;}
        }

        private int nbTour = 2;
        public int NbTour{
                get{return nbTour;}
        }

        // peut etre ajouter le chemin vers les fichiers
        public Parametre()
        {
        

        }

        public void ChangerTaillePLateau()
        {
                bool continuer = true;
                while(continuer)
                {
                        try{
                                Console.WriteLine("Quelle taille de plateau (4 dés au min par lignes) voulez vous ?");
                                string staillePlateau = Console.ReadLine();
                                int t = Convert.ToInt32(staillePlateau);
                                if (t>=4){
                                        this.taillePlateau = t;
                                        continuer = false;
                                }
                                else
                                {
                                        Console.WriteLine("la taille du pateau doit etre supeireure ou egale à 4");
                                }
                                
                        }
                        catch(Exception e){
                                Console.WriteLine("Erreur .Veuillez recommencer.");
                        }
                }
                
        }

        public void ChangerLangue(){
                Console.WriteLine("La langue actuelle est {0}.");
                Console.WriteLine("Taper:\n1 Pour le français\n2 Pourl'anglais");
                bool continuer = true;
                while(continuer){
                        try{
                                string choixLangue = Console.ReadLine();
                                if (choixLangue == "1"){
                                        this.langue = "FR";
                                        continuer = false;
                                }
                                else if(choixLangue == "2"){
                                        this.langue = "EN";
                                        continuer = false;
                                }
                                else
                                {
                                        Console.WriteLine("Vous n'avez pas fait votre choix entre 1 et 2. Recomencez.");
                                }
                        }
                        catch(Exception e){
                                Console.WriteLine("Une erreur est s'est produite. Recommencez");
                        }
                }
        }// fin methode


        public void ChangerDuree(){
                Console.WriteLine("Quelle est la durée en seconde de chaque tour? ");
                bool continuer = true;
                while(continuer)
                {
                        try{
                                string sduree = Console.ReadLine();
                                int duree = Convert.ToInt32(sduree);
                                this.dureeTour = duree;
                                if (duree<= 0){
                                        Console.WriteLine("Mauvaise saisie. la duree est positive");
                                }
                                else{
                                       continuer = false; 
                                }
                        }
                        catch(Exception e){
                             Console.WriteLine("Une erreur s'estr produite. Recommencez");
                        }
                }
        }// fin methode

        public void ChangerNbTour(){
                Console.WriteLine("Combien de tour par personne voulez vous?");
                bool continuer = true;
                while(continuer){
                        try
                        {
                                string sNbtour = Console.ReadLine();
                                this.nbTour = Convert.ToInt32(sNbtour);
                                continuer = false;
                        }
                        catch(Exception e){
                                Console.Write("Une erreur s'est produite. Recommencez");
                        }
                }
        }

        public void MsgParametrage(){
                Console.WriteLine(this.ToString());
                Console.WriteLine("Tapez ENTREE pour valider le parametre actuel, sinon saisissez une valeur.");
                /*
                        Console.Write("Press <Enter> to exit... ");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {}
                        https://learn.microsoft.com/fr-fr/dotnet/api/system.console.readkey?view=net-9.0

                */
                this.ChangerTaillePLateau();
                this.ChangerLangue();
                this.ChangerDuree();
                this.ChangerNbTour();
        }


        public override string ToString()
        {
        string s = "Parametres du jeu:\n";
        s += String.Format("Taille du plateau: {0}\n",this.taillePlateau);
        s += String.Format("Langue du Jeu: {0}\n",this.langue);
        s += String.Format("Durée d'un tour: {0}\n",this.dureeTour);
        s += String.Format("Nombre de tour pour chaque joueur: {0}",this.nbTour);
        return s;
        }
}
