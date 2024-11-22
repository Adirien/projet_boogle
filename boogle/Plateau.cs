using System;
using System.Reflection.Metadata;

namespace boogle;

public class Plateau
{
        private De[] tDe;
        private int taille ;

        public Plateau(int taille){
                this.tDe = new De[taille*taille];
                this.taille = taille;
        }

        /*
                on genere ici le plateau
        */
        public void genererPlateau(){
                int nb_face = (int)Math.Sqrt(this.taille)*6;

        }

}
