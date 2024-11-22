using System;

namespace boogle;

public class Lettre
{
    private Symbole symbole;//le caractere que l'on voit            
    private int point; // nombre de points que cette lettre apporte dans le mot trouvé
    private int frequence;//fréquence d'apparition de la lettre dans l'alphabet

    public Lettre(Symbole symbole,int point,int frequence){
        this.symbole=symbole;
        this.point=point;

    }
}
