using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Data;
namespace boogle;

// µIL FAUT VERIFIER QUE TOUTE LES LETTRES AIENT AU MOINS UNE VALEUR = 1

public class Alphabet
{
    private Dictionary<string,Lettre> dicoLettre ;
    public Dictionary<string,Lettre> DicoLettre{
        get { return dicoLettre;}
    }

    private int taillePlateau;
    public int getTaillePlateau(){
        return this.taillePlateau;
    }
    //nombre de lettres que l'on a au total dans le jeu 
    private int nombreLettreJeu ;
    public int NombreLettreJeu
    {
        get{return this.nombreLettreJeu;}   
    }


    public Alphabet(int taille_plateau){
        this.dicoLettre = new Dictionary<string,Lettre>();
        this.taillePlateau = taille_plateau;
        this.nombreLettreJeu = (int)(Math.Pow(taille_plateau,2)*6);
        this.readLettreFile();
        this.RepartitionFrequenceLettre();  
    }

    /// <summary>
    /// Methode readLettreFile
    /// on lit le ficher Lettre qui se trouve dans le meme repertoire que la fichier contenant la classe.
    /// on place toutes les lettres dans un dictionnaire 
    /// </summary>
    private void readLettreFile(){
        // on lit les lignes du fihier Lettres.txt qui se trouve au meme niveau que la classe Alphabet
        String line;
        try
        {
            ///Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("Lettres.txt");
            ///Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                
                //write the line to console window
                // Console.WriteLine('-'+line+'-');
                string[] arr = line.Split(';');
                // Console.WriteLine("la nouvelle lettre est :{0}-{1}-{2}",arr[0],arr[1],arr[2]);
                Lettre l = new Lettre(arr[0],Int32.Parse(arr[1]),Int32.Parse(arr[2]));
                // on ajoute dans le dictionnnaire
                this.dicoLettre.Add(arr[0],l) ;
                // Console.WriteLine(l.toString());
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
           
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
    }//readlettrefile

    /// <summary>
    /// Method repartitionFrequenceLettre
    /// methode qui permet de calculer le nombre de fois qu'une lettre apparait.
    /// Pour cela on a besoin de la taille du plateau et de la frequence d'apparation de la lettre ramené en pourcentage --> ratio
    /// </summary>
    private void RepartitionFrequenceLettre(){
               
        // on compte le nombre total de fois qu'apparait une lettre
        int sigma_frequence = 0;
        foreach(KeyValuePair<string,Lettre> pair in this.dicoLettre) {
            sigma_frequence +=pair.Value.Frequence;
        }
        
        //le pourcentage d'apparition (il s'agit d'un ration)
        double ratio = Math.Pow(this.taillePlateau,2)*6 / sigma_frequence;
        
        
        foreach(var lettre in this.dicoLettre.Values){
            
            lettre.NbApparition= Decimal.ToInt32(Convert.ToDecimal(Math.Round(lettre.Frequence * ratio )));
            // Console.WriteLine("nombre d'apparition:{0}",Math.Round(lettre.Frequence * pct)) ;
            // lettre.NbDisparition = lettre.NbApparition;
            // Console.WriteLine("lettre {0} , frequence {1}, nb apparaition:{2}, nbdisparition: {3}",lettre.Symbole,lettre.Frequence,lettre.NbApparition,lettre.NbDisparition);
        }

        // on trie l'image du tableau issu du dictionnaire selon le champ nbApparition
        // que l'on place dans une variable nommée tabLettre. Ce tableau est trié par ordre decroissant sur le champ nbApparition de chaque lettre
        Lettre[] tabLettre = this.dicoLettre.Values.OrderByDescending(item => item.NbApparition).ToArray();
        int index = 0;
        // on verifie que l'on aie le nombre de lettre total attentu (taille_plateau² x 6) egale a la somme de l'apparition pour chaque lettre 
        //il s'agit d'une condition TRES Forte car on peut se retrouver avec des dés ayant que 5 faces remplies.
        while ( this.nombreLettreJeu != this.NbTotalApparition()){
            if(this.nombreLettreJeu < this.NbTotalApparition()){
                //on a généré trop de lettre . On supprime les plus representées pour ça on fait:
                   
                Lettre lettre = tabLettre[index];  
                lettre.NbApparition -=1;
                // lettre.NbDisparition -=1;    
                // Console.WriteLine("-->lettre {0} apparation:{1}", lettre.Symbole, lettre.NbApparition);
                index +=1;
            }
            else if (this.nombreLettreJeu > this.NbTotalApparition())
            {
                // on n'a pas genere assez de lettres pour remplir les faces des Dés  et donc du plateau
                Lettre lettre = tabLettre[index];  
                lettre.NbApparition +=1;
                // lettre.NbDisparition +=1;    
                // Console.WriteLine("Ajout d'une lettre manquante-->lettre {0} apparation:{1}", lettre.Symbole, lettre.NbApparition);
                index +=1;
            }
        }//fin while
        
    }// fin methode

    /// <summary>
    /// NbTotalApparition on calcule le nombre total de Lettre dans le jeu
    /// </summary>
    /// <returns>int nom de lettres</returns>
    public int NbTotalApparition() { 
        int sigma_frequence = 0;    
        foreach(var lettre in this.dicoLettre.Values){
            sigma_frequence += lettre.NbApparition;
        }
        return sigma_frequence;
    }

    

    /// <summary>
    /// Renvoie le nombre de lettre: en france  on aura 26
    /// </summary>
    /// <returns></returns>
    public int NombreLettre(){
        return this.dicoLettre.Count;
    }

    /// <summary>
    /// methode qui renvoie les lettres dont on n'a pas la meme valeur entre lettreApparition et lettreDisparition
    /// </summary>
    /// <returns></returns>
    // public string NombrelettreDisparue(){
    //     string s = "";
    //     foreach(Lettre lettre in this.dicoLettre.Values){
    //         if(lettre.NbApparition != lettre.NbDisparition){
    //             s += lettre.Symbole + " - apparition: " + Convert.ToString(lettre.NbApparition) + " - disparition: " + Convert.ToString(lettre.NbDisparition)+"\n";
    //         }
    //     }
    //     return s;
    // }


    public string toString(){
        string s = "";
        foreach(Lettre lettre in this.dicoLettre.Values){
            s += lettre.toString() +"\n";
        }
        return s;
    }
}