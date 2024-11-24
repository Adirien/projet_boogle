// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using boogle;

Console.WriteLine("Hello, World!");
int taille_plateau = 5;
Alphabet alphabet= new Alphabet(taille_plateau);
// alphabet.readLettreFile();
alphabet.RepartitionFrequenceLettre();

// Pour le Dé
Random  random = new Random();
De de = new De(alphabet,random) ;
de.GenererDe();
Console.WriteLine(de.ToString());