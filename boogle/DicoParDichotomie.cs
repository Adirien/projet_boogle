using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace boogle;

public class DicoParDichotomie
{
    private string langue;
    private List<string> dicolangue;

    public DicoParDichotomie(string langue){
        this.langue = langue;
        dicolangue = new List<string>();
    }

    public void ConstruireDico(){
        string? nomFichier;

        //en fonction de la langue choisie on va ouvrir le fichier correspondant
        if (this.langue == "FR")
        {
            // nomFichier = "D:\\users\\bernard\\workspace_c#\\projet_boogle\\boogle\\MotsPossiblesFR.txt";
            nomFichier = "MotsPossiblesFR.txt";
        }
        else 
        {
            nomFichier = "MotsPossiblesEn.txt";
        }  
        StreamReader sr = new StreamReader(nomFichier);   
        string line = sr.ReadLine();
        int  nbligne = 0;
        
        string[] arr  = line.Split(' ');
        //close the file
        sr.Close();

        this.dicolangue.Add(arr[0]);
        Console.WriteLine(arr[0]);
        for(int i = 1; i < arr.Length;i++ )
        {   
            Console.WriteLine(arr[i]);
            int idx = chercherIndex(arr[i],0,this.dicolangue.Count);
            this.dicolangue.Insert(idx,arr[i]);
            nbligne +=1;

            if(nbligne > 20){
                break;
            }
        }
            // Console.WriteLine("###################################### \n");
            // foreach(string mot in this.dicolangue){
            //     Console.WriteLine(mot);
            // }


            // line = sr.ReadLine();
        // }
        
        Console.WriteLine("nom de ligne " + nbligne);
    }// fin ConstruireDico

    /// <summary>
    /// On cherche la position de l'index  où l'on va placer placer le mot "mot" dans la liste 
    /// </summary>
    /// <param name="mot"> le mot que l'on place</param>
    /// <param name="min">index min de la liste a partir duquel on cherche la position du mot a inserer  </param>
    /// <param name="max">index max de la liste jusqu'auquel on cherche la position du mot a inserer</param>
    /// <returns></returns>
    private int chercherIndex(string mot,int min, int max)
    {
        //on cherche index milieu de la liste  -> (0+1)/2 = 0 division entiere 
        //  prend la valeur entiere juste endessous de la valeur "reell" de la division
        int milieu = (min+max)/2;
        
        if (max == min+1)
        {
            int minCompare =    mot.CompareTo(this.dicolangue.ElementAt(min));
            if(max >= this.dicolangue.Count){
                max = this.dicolangue.Count-1;
            }
            //l'index max peut etre en dehors de la liste
            int maxCompare = mot.CompareTo(this.dicolangue.ElementAt(max));
            if (minCompare <0){
                return min;
            }
            else if(maxCompare>0)
            {
                return max+1;

            }
            else{
                return max;
            }
            
        }
        else{
            int valCompare  = mot.CompareTo(this.dicolangue.ElementAt(milieu));
            if (valCompare <=0){
                return chercherIndex(mot,min,milieu);
            }
            else{
                return chercherIndex(mot,milieu,max);
            }
        }
    }//fin chercherindex

    public int NombreMot(){
        return this.dicolangue.Count;
    }

    public bool RechDicoRecursif(string mot,int min, int max){
       
        int milieu = (min+max)/2;

        
        if(max == min+1){
            if(max >= this.dicolangue.Count){
                max = this.dicolangue.Count-1;
            }
            int minCompare = mot.CompareTo(this.dicolangue.ElementAt(min));
            int maxCompare = mot.CompareTo(this.dicolangue.ElementAt(max));
            if(minCompare == 0 || maxCompare == 0){
                return true;
            }
            else{
                return false;
            }
        }
        int milieuCompare = mot.CompareTo(this.dicolangue.ElementAt(milieu));
        if (milieuCompare <0)
        {
            return this.RechDicoRecursif(mot,min,milieu);
        }
        else if(milieuCompare>0) {
            return this.RechDicoRecursif(mot, milieu,max);
        }   
        return true;

       
    }


}
