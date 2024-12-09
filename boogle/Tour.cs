using System;
using System.Diagnostics.Contracts;

namespace boogle;

public class Tour
{
    public Joueur joueur { get; }

    private Plateau plateau;

    private Parametre parametre;

    public Tour(Plateau plateau,Joueur joueur,Parametre parametre){
        this.plateau = plateau;
        this.joueur = joueur;
        this.parametre = parametre;
    }

    public void JouerTour(){
        Console.WriteLine("{0} joue à présent\n",this.joueur.Pseudo);
        Console.WriteLine(this.plateau.ToString());
        Console.WriteLine("");

        Sablier sablier = new Sablier(this.parametre.DureeTour);
        sablier.Start();
        while(true)
        {
           
            string? mot = Console.ReadLine();
            if (mot.Length>0){
                mot = mot.ToUpper();
                if (!sablier.TempsSEcoule())
                {
                    // la saisie du mot se fait apres le temps autorisé.
                    //on ne prend pas en compte le mot
                    break;
                }
                else
                {
                    // A FAIRE ici:
                    //verifier que le mot existe sur plateau
                    if (this.plateau.Contain(mot) && this.joueur.Contains(mot)){
                        // Il faut le dictionnaire pour verifier qu'il existe 
                        // puis on clcule le nombre points du mots et on met a jour le score du joueur
                    }
                    // ajouter le mot a la liste du joueur,
                    
                    //verifier que mot existe dans dico
                    //calculer les points
                }
            }
            
        }
        Console.WriteLine("Le tour pour le {0} est fini", this.joueur.Pseudo);
    }


}
