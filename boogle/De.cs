using System;
using System.Linq;
using System.Runtime.Serialization;

namespace boogle;

public class De
{
    Alphabet alphabet ;
    Random random;
    Lettre[] tabLettre;
    Lettre lettreVisible;

    public Lettre face{ 
        get {return lettreVisible;}
    } 

    public De(Alphabet alphabet,Random random){
        this.alphabet = alphabet;
        this.random = random;
        this.tabLettre = new Lettre[6];

    }

    public void GenererDe(){
        for (int i = 0; i < 6;i++){

            int idx = this.random.Next(0,alphabet.NombreLettre());
            string[] tabSymbole = this.alphabet.DicoLettre.Keys.ToArray();//utilisatin de system.linq
            
            if( this.alphabet.EnleverLettre(tabSymbole[idx])){
                this.tabLettre[i] = this.alphabet.DicoLettre[tabSymbole[idx]];
            }
        }
        this.lettreVisible = this.tabLettre[this.random.Next(0,6)];
        
    }//fin genererDe

    public override string  ToString(){
        string de_str = "Dé:";
        foreach (Lettre face in this.tabLettre)
        {
            de_str = de_str + '|'+face.Symbole ;
        }
        return de_str;
    }


    // TODO
    // On peut ajouter des regles sur les Des comme par exemple pas plus de 2 fois la meme lettre sur un Dé

    // a completer
    public override bool Equals(object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //
        
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        // TODO: write your implementation of Equals() here
        throw new System.NotImplementedException();
        return base.Equals (obj);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }
}
