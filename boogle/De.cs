using System;
using System.Linq;
using System.Runtime.Serialization;

namespace boogle;

public class De
{
    //Alphabet alphabet ;
   // Random random;
    //Lettre[] tabLettre;
    List<Lettre> listLettre;
    
    // Lettre lettreVisible;

    // public Lettre face{ 
    //     get {return lettreVisible;}
    // } 

    // public static De generation(Alphabet alphabet, Random random){
    //     Console.WriteLine("Generation De");
    //     Lettre[] tabLettre = new Lettre[6];
    //     string[] tabSymbole = alphabet.DicoLettre.Keys.ToArray();//utilisatin de system.linq
    //     int index_tab = 0;
    //     while (index_tab <6){
    //         int idx = random.Next(0,alphabet.NombreLettre());
            
    //         if( alphabet.EnleverLettre(tabSymbole[idx])){
    //             tabLettre[index_tab] = alphabet.DicoLettre[tabSymbole[idx]];
    //             index_tab +=1;
    //         }
    //     }
    //     De de = new De();
    //     de.tabLettre = tabLettre;
    //     return de;
    // }

    public static  De[] genererDe(Alphabet alphabet, Random random){
        De[] des = new De[(int) Math.Pow(alphabet.getTaillePlateau(),2)];
        //initialisation de chaque dé
        for (int i = 0 ; i < (int) Math.Pow(alphabet.getTaillePlateau(),2);i++){
            De de = new De();
            des[i]= de;
        }
        foreach(Lettre lettre in alphabet.DicoLettre.Values){
            Console.WriteLine("############  lettre en cours {0}",lettre.Symbole);
            // on boucle sur le nombre de disparition possible de la lettre
            for(int nb =0; nb< lettre.NbApparition;nb++){
                Console.WriteLine("valeur du nombre d'appartion: {0}",nb);
                //on choisit le dé dans lequel on ajoute la lettre
                bool arreter = false;
                while (! arreter){
                    int index_de = random.Next(des.Length);
                    Console.WriteLine("choix dé n° {0}",index_de);
                    Console.WriteLine("valeur contiens2fois: {0}",des[index_de].Contient2Fois(lettre));
                    arreter = des[index_de].Add(lettre);
                    
                }              


            }
            
        }

        return des;
    }


    public De(){
        this.listLettre = new List<Lettre>();
    }

    /// <summary>
    /// permet de savoir si la liste en interne a ateind la capacite max de 6
    /// </summary>
    /// <returns>
    /// true: si listLettre a 6 Lettres
    /// false: listLettre a moins de 6 lettres
    /// </returns>
    public bool EstPlein(){
        if(this.listLettre.Count == 6){
            return true;
        }
        return false;
    }

    /// <summary>
    /// tant que la list n'a pas 6 lettres , on peut ajouter dans la liste
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// true:on a bien ajouté l'element dans la liste
    /// false: capacite max atteinte ou bien erreur
    /// </returns>
    public bool Add(Lettre lettre){
        if(lettre.Symbole == "Z"){
            Console.WriteLine("Lettre Z, dé plein? -->{0}",this.EstPlein());
            if(!this.EstPlein()){
                Console.WriteLine("Nomde face: {0}",this.NombreLettre());
            this.listLettre.Add(lettre);
            return true;
            }
            ;
        }

        else if(!this.EstPlein() && !this.Contient2Fois(lettre)){
            this.listLettre.Add(lettre);
            return true;
        }
        return false;
    }

    /// <summary>
    /// on cherche a savoir si la lettre est deja presnte .
    /// On accepte sur un meme dé qu'une lettre apparaisse  au max 2 fois.
    /// </summary>
    /// <param name="lettre"></param>
    /// <returns>
    /// false: indique que la lettre est presente 0 ou 1 seule fois
    /// true: la liste contient deja 2 fois la lettre
    /// </returns>
    public bool Contient2Fois(Lettre lettre){

        int idx1 = this.listLettre.IndexOf(lettre);
        int idx2 = this.listLettre.LastIndexOf(lettre);
        if (idx1 != idx2){
            return true;
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>le nombre de face du fé à avoir une lettre</returns>
    public int NombreLettre(){
        return this.listLettre.Count;
    }

    public override string  ToString(){
        string de_str = "Dé:";
        foreach (Lettre face in this.listLettre)
        {
                // Console.WriteLine(face.toString());
            de_str = de_str + '|'+face.Symbole ;
        }
        return de_str;
    }

    /// <summary>
    /// Methode qui renvoie la Lettre qui est visible sur le de considere
    /// </summary>
    /// <returns></returns>
   /* public Lettre lettreFace(){
        return this.tabLettre[this.random.Next(0,6)];
    }*/

    
}
