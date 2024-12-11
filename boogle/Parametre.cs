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
                                Console.WriteLine("Quelle taille de plateau (4 dés au minimum par lignes) voulez vous ?");
                                string? staillePlateau = Console.ReadLine();
                                if (staillePlateau.Length == 0){
                                        continuer = false;
                                }
                                else
                                {
                                        int t = Convert.ToInt32(staillePlateau);
                                        if (t>=4){
                                                this.taillePlateau = t;
                                                continuer = false;
                                        }
                                        else
                                        {
                                                Console.WriteLine("la taille du plateau doit etre superieure ou egale à 4. Veuillez recommencer.");
                                        }
                                }
                                
                                
                        }
                        catch(Exception e){
                                Console.WriteLine("Erreur .Veuillez recommencer.");
                        }
                        
                }
                
        }

        public void ChangerLangue(){
                Console.WriteLine("La langue actuelle est {0}.",this.langue);
                Console.WriteLine("Taper:\n1 Pour le français\n2 Pour l'anglais");
                bool continuer = true;
                while(continuer){
                        try{
                                string? choixLangue = Console.ReadLine();
                                if (choixLangue.Length == 0)
                                {
                                        continuer = false;
                                }
                                else if (choixLangue == "1"){
                                        this.langue = "FR";
                                        continuer = false;
                                }
                                else if(choixLangue == "2"){
                                        this.langue = "EN";
                                        continuer = false;
                                }
                                else
                                {
                                        Console.WriteLine("Vous n'avez pas fait votre choix entre 1 et 2. Recommencez.");
                                }
                        }
                        catch(Exception e){
                                Console.WriteLine("Une erreur est s'est produite. Recommencez");
                        }
                }
        }// fin methode


        public void ChangerDuree(){
                Console.WriteLine("Quelle est la durée en seconde de chaque tour? (actuellement-->{0}s)",this.dureeTour);
                bool continuer = true;
                while(continuer)
                {
                        try{
                                string? sduree = Console.ReadLine();
                                if(sduree.Length == 0)
                                {
                                        continuer = false;
                                }
                                else
                                {
                                        int duree = Convert.ToInt32(sduree);
                                        this.dureeTour = duree;
                                        if (duree<= 0){
                                                Console.WriteLine("Mauvaise saisie. la duree est positive");
                                        }
                                        else{
                                        continuer = false; 
                                        }
                                }
                                
                        }
                        catch(Exception e){
                             Console.WriteLine("Une erreur s'estr produite. Recommencez");
                        }
                }
        }// fin methode

        public void ChangerNbTour(){
                Console.WriteLine("Combien de tour par personne voulez vous? (Actuellement {0} tour(s))",this.nbTour);
                bool continuer = true;
                while(continuer){
                        try
                        {
                                string? sNbtour = Console.ReadLine();
                                if(sNbtour.Length == 0) {
                                        continuer = false;      
                                }
                                else{
                                        //this.nbTour = Convert.ToInt32(sNbtour);
                                        int nb_tour = Convert.ToInt32(sNbtour);
                                        if (nb_tour == 0)
                                        {
                                                Console.WriteLine("Vous avez saisi 0 pour le nombre de tour. Ce n'est pas possible.Recommencez.");
                                        }
                                        else
                                        {
                                                this.nbTour = nb_tour;
                                                continuer = false;
                                        }
                                        
                                }
                                
                        }
                        catch(Exception e){
                                Console.Write("Une erreur s'est produite. Recommencez");
                        }
                }
        }

        public void MsgParametrage(){
                Console.WriteLine(this.toString());
                Console.WriteLine("Pour chaque parametre, tapez <ENTREE> pour valider le parametre actuel, sinon saisissez une valeur.");
               
                this.ChangerTaillePLateau();
                this.ChangerLangue();
                this.ChangerDuree();
                this.ChangerNbTour();
                
        }


        public string toString()
        {
        string s = "Parametres du jeu:\n";
        s += String.Format("Taille du plateau: {0}\n",this.taillePlateau);
        s += String.Format("Langue du Jeu: {0}\n",this.langue);
        s += String.Format("Durée d'un tour: {0}\n",this.dureeTour);
        s += String.Format("Nombre de tour pour chaque joueur: {0}",this.nbTour);
        return s;
        }
}
