using System;

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
        while(sablier.TempsSEcoule())
        {
           
            string nouveau_mot = Console.ReadLine();
        }
        Console.WriteLine("Le tour pour le {0} est fini", this.joueur.Pseudo);
    }


}
