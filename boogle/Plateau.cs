using System;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;

namespace boogle;

 //on ne peut pas avoir 2 fois le meme dé !!

public class Plateau
{
        private De[] tabDe;
        private int taille ;
       
       private Random random;

        public Plateau( int taille,De[] tabDe,Random random){
                this.tabDe = new De[ taille*taille];
                this.taille = taille;
                this.random=random;
                       
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
                                int index=random.Next(6);
                                matrice[i,j]= tire.ListLettre[index] ;
                        }
                }
                return matrice;
        }

       

       
        

}
