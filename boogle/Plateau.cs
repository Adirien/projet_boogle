using System;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace boogle;

public class Plateau
{
        private De[] tabDe;
        private int taille ;
       
       private Random random;

       private Lettre[,] matrice;

        public Plateau( int taille,De[] tabDe,Random random){
                this.tabDe = tabDe;
                this.taille = taille;
                this.random=random;
                this.matrice  = this.DefinirPlateau();            
        }

        public Lettre[,] DefinirPlateau()
        {
                Lettre[,] matrice=new Lettre[this.taille,this.taille];
                List<int> rangutilise = new List<int>();
                for (int i=0;i<this.taille;i++)
                {
                        for (int j=0;j<this.taille;j++)
                        {
                                int rang=random.Next(this.tabDe.Length);
                                while (rangutilise.Contains(rang))
                                {
                                        rang=random.Next(this.tabDe.Length);

                                }
                                rangutilise.Add(rang);
                                De tire=tabDe[rang];
                                Console.WriteLine("#########   {0} ",tire.toString());
                                int index=random.Next(6);
                                // Console.WriteLine("i:{0}, j:{1},index:{2}",i,j,index);
                                matrice[i,j]= tire.ListLettre[index] ;
                        }
                }
                return matrice;
        }



       

        public  bool Contain(string mot,int ligne=-1,int colonne=-1,int rang=0,List<int[]>dejautilise=null)
        {
                if(dejautilise==null)
                {
                        dejautilise= new List<int[]>();

                }
                int taille=mot.Length;
                if(rang==0)
                {
                        List<int[]> positiondepart = TrouverDepart(mot[0]); //trouver toutes les possbilites de depart pour faire le mot grace a la methode
                        foreach(var pos in positiondepart )     // on va regarder les differentes possibilitées et si faux chemin on fait retour en arriere
                        {
                        dejautilise.Add(pos);
                                if(Contain(mot,pos[0],pos[1],rang+1,dejautilise))
                        {
                                return true;
                        }
                                dejautilise.RemoveAt(dejautilise.Count-1); // si faux chemin supprimer les coordonnées de la fausse piste
                        }
                        return false; // si aucun chemin de depart mène au mot retourner faux
                }
                if (rang==taille) //cas final qui renvoie true quand toutes les lettres se suivent en respectant les règles
                {
                        return true;
                }
                List<int[]> adjacents = CoordonneesAdjacentes(ligne, colonne, mot[rang], dejautilise); //liste avec toutes les possibilites de lettres pour si on prend un mauvais chemin on testera les autres
                foreach(var adja in adjacents)
                {
                        dejautilise.Add(adja);
                        if(Contain(mot,adja[0],adja[1],rang+1,dejautilise))  // on continue de verifier si les autres lettres du mot suivent
                        {
                                return true;
                        }
                        dejautilise.RemoveAt(dejautilise.Count-1); // si la piste ne mene nul part supprimer les coordonées de la fausse piste

                }
                return false; // si aucun chemin reussit

        }//fin Contain


        public List<int[]> TrouverDepart(char caractere)
        {
                List<int[]> positions = new List<int[]>(); // la liste permet de garder toutes les possibilites de chemin en stock au cas où on part sur une fausse piste
                int nbligne = this.matrice.GetLength(0);
                int nbcolonne = this.matrice.GetLength(1);
                for (int i=0;i<nbligne;i++)
                {
                        for(int j=0;j<nbcolonne;j++)
                        {
                                char lettre=this.matrice[i,j].Symbole[0]; //recuperer la lettre a la position de la matrice
                                if(lettre==caractere)
                                {
                                        positions.Add(new int[]{i,j}); // on ajoute les coordonees si la lettre rechercher correspond a la lettre du plateau
                                }
                        }

                }
                return positions; 
        }


        public List<int[]>CoordonneesAdjacentes(int ligne, int colonne, char caractere, List<int[]>dejautilise=null)
        {
                if(dejautilise==null)
                {
                        dejautilise=new List<int[]>();
                }
                List<int[]>possibilites=new List<int[]>(); // liste dans lasquelle on va ranger toutes les coordonnes des lettres possible
                int[] abscisse = { -1, -1, -1, 0, 0, 1, 1, 1 };  //2 tableaux qui vont permettrent de regarder les cases adjacentes a celle que lon souhaite
                int[] ordonnee= { -1, 0, 1, -1, 1, -1, 0, 1 };
                int nbligne = this.matrice.GetLength(0);
                int nbcolonne = this.matrice.GetLength(1);
                for (int i=0;i<8;i++)               // 8 car cest le nombre de case maximum adjactentes a une case
                {
                        int nouvelleligne=ligne+abscisse[i];
                        int nouvellecolonne=colonne+ordonnee[i];
                        if(nouvelleligne>=0 && nouvelleligne<nbligne&&nouvellecolonne>=0 && nouvellecolonne<nbcolonne) //restriction pour ne pas sortir de la matrice
                        {
                                char lettre=this.matrice[nouvelleligne,nouvellecolonne].Symbole[0];
                                if(lettre == caractere && !dejautilise.Exists(c => c[0] == nouvelleligne && c[1] == nouvellecolonne)) // verifier que la lettre est la meme et quelle na pas deja ete utilise
                                {
                                possibilites.Add(new int[] { nouvelleligne, nouvellecolonne });   // ajout de la coordonnee si elle verifie les attentes

                                }
                        }
                }
                return possibilites;
        
        }
        public string toString()
        {
                string s ="";
                for (int i=0;i<this.taille;i++)
                {
                        for (int j=0;j<this.taille;j++)
                        {
                                s+=this.matrice[i,j].Symbole+" ";
                        }
                        s+="\n";
                }

                return s;
        }





}
