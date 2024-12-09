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
           
            string nouveau_mot = Console.ReadLine();
            if (!sablier.TempsSEcoule())
            {
                // la saisie du mot se fait apres le temps autorisé.
                //on ne prend pas en compte le mot
                break;
            }
            else
            {
                // A FAIRE ici:
                // ajouter le mot a la liste du joueur,
                //verifier que le mot existe sur plateau
                //verifier que mot existe dans dico
                //calculer les points
            }
        }
        Console.WriteLine("Le tour pour le {0} est fini", this.joueur.Pseudo);
    }


}
