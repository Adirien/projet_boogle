using System;

namespace boogle;

/// <summary>
/// Classe qui simule un sblier
/// 
/// </summary>
public class Sablier
{

    private DateTime startDateTime;
    private TimeSpan timeSpan;
    private DateTime endDateTime;
    private DateTime currentTime;

    public Sablier(int secondes)
    {
        timeSpan = new TimeSpan(0, 0,secondes);
    }

    public void Start()
    {
        startDateTime = DateTime.Now;
        endDateTime = startDateTime.Add(timeSpan);
    }

    /// <summary>
    /// On s'informe si le temps s'ecole encore ou pas.
    /// 
    /// </summary>
    /// <returns>
    /// True --> il reste du temps au chronometre
    /// False --> le temps est terminé
    /// </returns>
    public bool TempsSEcoule()
    {
        currentTime = DateTime.Now;
        return  currentTime<= endDateTime;    
    }

    public override string ToString()
    {
        TimeSpan interval = this.endDateTime - this.currentTime;
        return String.Format("{0}",interval.ToString());            
    }
}
