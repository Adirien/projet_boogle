using System;
using System.Diagnostics.Contracts;

namespace boogle;

public class Tour
{
    public Joueur joueur { get; }

    private Plateau plateau;

    private Parametre parametre;

    private Dicolangue dico ;

    private Alphabet alphabet;

    public Tour(Plateau plateau,Joueur joueur,Parametre parametre,Dicolangue dico,Alphabet alphabet){
        this.plateau = plateau;
        this.joueur = joueur;
        this.parametre = parametre;
        this.dico = dico;
        this.alphabet = alphabet;
    }

    public void JouerTour(){
        
        Console.WriteLine("{0} joue à présent\n",this.joueur.Pseudo);
        Console.WriteLine(this.plateau.toString());
        Console.WriteLine("");

        Sablier sablier = new Sablier(this.parametre.DureeTour);
        sablier.Start();
        while(true)
        {
            Console.WriteLine("Saisissez un nouveau mot trouvé");
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
                    
                    //verifier que le mot existe sur plateau, que le mot n'ai pas deja utilisé par joueur et que le mot existe bien dans le dictioinnnaire
                    if (this.plateau.Contain(mot) && !this.joueur.Contains(mot) && this.dico.RechDichoRecursif(mot)){
                        
                        int score = 0;
                        // puis on calcule le nombre points du mots et on met a jour le score du joueur
                        foreach( char c in mot)
                        {
                            score = score + this.alphabet.DicoLettre[Convert.ToString(c)].getPoint();
                        }
                        this.joueur.Score = this.joueur.Score + score;
                        this.joueur.AddMot(mot);
                        Console.WriteLine("Le score de {0} est de {1} grace aux mots cités suivants:\n {2}",this.joueur.Pseudo,this.joueur.Score,this.joueur.AfficherListTourEncours());
                    }
                    // ajouter le mot a la liste du joueur,
                    
                    //verifier que mot existe dans dico
                    //calculer les points
                }
            }
            
        }
        Console.WriteLine("Le tour pour le joueur {0} est fini", this.joueur.Pseudo);
    }


}
