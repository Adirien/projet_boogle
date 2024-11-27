using System;
using System.Linq;
using System.Runtime.Serialization;

namespace boogle;

public class De
{
    Alphabet alphabet ;
    Random random;
    Lettre[] tabLettre;
    // Lettre lettreVisible;

    // public Lettre face{ 
    //     get {return lettreVisible;}
    // } 

    public static De generation(Alphabet alphabet, Random random){
        Console.WriteLine("Generation De");
        Lettre[] tabLettre = new Lettre[6];
        string[] tabSymbole = alphabet.DicoLettre.Keys.ToArray();//utilisatin de system.linq
        int index_tab = 0;
        while (index_tab <6){
            int idx = random.Next(0,alphabet.NombreLettre());
            
            if( alphabet.EnleverLettre(tabSymbole[idx])){
                tabLettre[index_tab] = alphabet.DicoLettre[tabSymbole[idx]];
                index_tab +=1;
            }
        }
        De de = new De();
        de.tabLettre = tabLettre;
        return de;
    }

    public De(Alphabet alphabet,Random random){
        this.alphabet = alphabet;
           
        this.random = random;
        this.tabLettre = new Lettre[6];
        this.GenererDe();
    }

    public De(){

    }

    private void GenererDe(){
        for (int i = 0; i < 6;i++){
            
            int idx = this.random.Next(0,alphabet.NombreLettre());
            string[] tabSymbole = this.alphabet.DicoLettre.Keys.ToArray();//utilisatin de system.linq
            
            if( this.alphabet.EnleverLettre(tabSymbole[idx])){
                this.tabLettre[i] = this.alphabet.DicoLettre[tabSymbole[idx]];
            }
           
        }
        // this.lettreVisible = this.tabLettre[this.random.Next(0,6)];
         Console.WriteLine("dans De: " +this.alphabet.NombrelettreDisparue());
    }//fin genererDe

    public override string  ToString(){
        string de_str = "Dé:";
        foreach (Lettre face in this.tabLettre)
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
    public Lettre lettreFace(){
        return this.tabLettre[this.random.Next(0,6)];
    }

    //on ajoute au dé une lettre
    public void AddLettre(Lettre lettre){

    }

    // TODO
    // On peut ajouter des regles sur les Des comme par exemple pas plus de 2 fois la meme lettre sur un Dé

    // a completer
    // public override bool Equals(object obj)
    // {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //
        
        // if (obj == null || GetType() != obj.GetType())
        // {
        //     return false;
        // }
        
        // TODO: write your implementation of Equals() here
    //     throw new System.NotImplementedException();
    //     return base.Equals (obj);
    // }
    
    // // override object.GetHashCode
    // public override int GetHashCode()
    // {
    //     // TODO: write your implementation of GetHashCode() here
    //     throw new System.NotImplementedException();
    //     return base.GetHashCode();
    // }
}
