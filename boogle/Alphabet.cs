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
                Console.WriteLine("la nouvelle lettre est :{0}-{1}-{2}",arr[0],arr[1],arr[2]);
                Lettre l = new Lettre(arr[0],Int32.Parse(arr[1]),Int32.Parse(arr[2]));
                // on ajoute dans le dictionnnaire
                this.dicoLettre.Add(arr[0],l) ;
                // Console.WriteLine(l.toString());
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            // Console.ReadLine();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    /// <summary>
    /// Method repartitionFrequenceLettre
    /// methode qui permet de calculer le nombre de fois qu'une lettre apparait.
    /// Pour cela on a besoin de la taille du plateau et de la frequence d'apparation de la lettre en pourcentage
    /// </summary>
    private void RepartitionFrequenceLettre(){
        // @Note  Methide qui devra etre  private
        
        // on compte le nombre total de fois qu'apparait une lettre
        int sigma_frequence = 0;
        foreach(KeyValuePair<string,Lettre> pair in this.dicoLettre) {
            sigma_frequence +=pair.Value.Frequence;
        }
        
        double pct = Math.Pow(this.taillePlateau,2)*6 / sigma_frequence;
        // Console.WriteLine("sigma_frequence:{0},PCT:{1}, nbTotalLettreDé:{2}",sigma_frequence,pct,this.nombreLettreJeu );
        //if (pct <= 1){
            //l'addtion de toutes les frequences des lettres est superieure 
            // a tailleplateau² *6
            foreach(var lettre in this.dicoLettre.Values){
                
                lettre.NbApparition= Decimal.ToInt32(Convert.ToDecimal(Math.Round(lettre.Frequence * pct )));
                // Console.WriteLine("nombre d'apparition:{0}",Math.Round(lettre.Frequence * pct)) ;
                lettre.NbDisparition = lettre.NbApparition;
                Console.WriteLine("lettre {0} , frequence {1}, nb apparaition:{2}, nbdisparition: {3}",lettre.Symbole,lettre.Frequence,lettre.NbApparition,lettre.NbDisparition);
            }
            // on trie l'image du tableau issu du dictionnaire selon le champ nbApparition
            // que l'on place dans une variable nommée tabLettre. Ce tableau est trié par ordre decroissant sur le champ nbApparition de chaque lettre
            Lettre[] tabLettre = this.dicoLettre.Values.OrderByDescending(item => item.NbApparition).ToArray();
            int index = 0;
            if(this.nombreLettreJeu < this.NbTotalApparition()){
                //on a généré trop de lettre . On supprime les plus representées pour ça on fait:
                while(this.nombreLettreJeu < this.NbTotalApparition())          {
                    Lettre lettre = tabLettre[index];  
                    lettre.NbApparition -=1;
                    lettre.NbDisparition -=1;    
                    Console.WriteLine("-->lettre {0} apparation:{1}", lettre.Symbole, lettre.NbApparition);
                    index +=1;
                }
            }
            else if (this.nombreLettreJeu > this.NbTotalApparition()){
                // on n'a pas genere assez de lettres pour remplir les faces des Dés  et donc du plateau
                Lettre lettre = tabLettre[index];  
                lettre.NbApparition +=1;
                lettre.NbDisparition +=1;    
                Console.WriteLine("-->lettre {0} apparation:{1}", lettre.Symbole, lettre.NbApparition);
                index +=1;
            }
    }// fin methode

    /// <summary>
    /// NbTotalApparition on calcule le nombre total de Lettre dans le jeu
    /// 
    /// </summary>
    /// <returns>int nom de lettres</returns>
    public int NbTotalApparition() { 
        int sigma_frequence = 0;    
        foreach(var lettre in this.dicoLettre.Values){
            sigma_frequence += lettre.NbApparition;
        }
        return sigma_frequence;
    }

// ajouter peut etre une methode qui verifie que toutes lettres on une valeur d'apparaiton >=1
//sinon on a des problemes !

    public void ReInitialiserNbDisparition() {
        foreach(Lettre lettre in this.dicoLettre.Values) {
            lettre.NbDisparition = lettre.NbApparition;
        }

    }// fin methode ReInitialiserNbDisparition

    /// <summary>
    /// On enleve pour le symbole representant une lettre 
    /// une unité au champ nbDisparition
    /// Tant que cette valeur est >0 on peut en enlever on revoit alors True
    /// Si nbDispariton = 0 alors on ne peut pas en enlever et on renvoie False
    /// </summary>
    /// <param name="symbole"></param>
    /// <returns></returns>
    public Boolean EnleverLettre(string symbole){
        Lettre lettre = this.dicoLettre[symbole];
        if (lettre.NbDisparition == 0) {
            return false;
        }
        lettre.NbDisparition -=1;

        return true;
    }// fin EnleverLettre 

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
    public string NombrelettreDisparue(){
        string s = "";
        foreach(Lettre lettre in this.dicoLettre.Values){
            if(lettre.NbApparition != lettre.NbDisparition){
                s += lettre.Symbole + " - apparition: " + Convert.ToString(lettre.NbApparition) + " - disparition: " + Convert.ToString(lettre.NbDisparition)+"\n";
            }
        }
        return s;
    }


    public override string ToString(){
        string s = "";
        foreach(Lettre lettre in this.dicoLettre.Values){
            s += lettre.ToString() +"\n";
        }
        return s;
    }
}