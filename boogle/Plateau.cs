using System;
using System.Reflection.Metadata;

namespace boogle;

 //on ne peut pas avoir 2 fois le meme dé !!

public class Plateau
{
        private De[] tabDe;
        private int taille ;
        Alphabet alphabet;

        public Plateau(Alphabet alphabet , int taille){
                this.tabDe = new De[ taille*taille];
                this.taille = taille;
                this.alphabet = alphabet;       
        }

        /*
                on genere ici le plateau
        */
        public void genererPlateau(){
                alphabet.ReInitialiserNbDisparition();

        }

}
