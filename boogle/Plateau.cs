using System;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace boogle;

 //on ne peut pas avoir 2 fois le meme dé !!

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
                foreach(De de in this.tabDe){
                        if(de == null){
                                Console.WriteLine("dé null");
                        }
                        else if(de.NombreLettre()>0){
                                Console.WriteLine(de.ToString());
                        }
                        else
                        {
                                Console.WriteLine("dé vide");
                        }
                }       



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
                                Console.WriteLine("#########    ",tire.ToString());
                                int index=random.Next(6);
                                Console.WriteLine("i:{0}, j:{1},index:{2}",i,j,index);
                                matrice[i,j]= tire.ListLettre[index] ;
                        }
                }
                return matrice;
        }

    public override string ToString()
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
