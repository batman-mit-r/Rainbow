using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Patientenanwendung.Data
{
    public class AnfrageService
    {
        public List<Anfrage> anfrageListe = new List<Anfrage>();
        public List<AnfrageBearbeitet> anfrageListeBearbeitet = new List<AnfrageBearbeitet>();

        public void AddAnfrage(Anfrage anfrage)
        {
            anfrageListe.Add(anfrage);
            Sort_for_Prio();
            LogAnfrage(anfrage);
        }
        private void LogAnfrage(Anfrage anfrage)
        {
            if(anfrage.AnfrageArt == AnfrageArt.Schmerzen)
            {
                Log.Warning("Anfrageart: " + anfrage.AnfrageArt +
                "; Bettnummer: " + anfrage.Bett.Bettnummer + 
                "; Schmerzlevel: " + anfrage.Schmerzlevel);
            }
            if (anfrage.AnfrageArt == AnfrageArt.Nahrungsmittel || anfrage.AnfrageArt == AnfrageArt.Sonstiges)
            {
                Log.Warning("Anfrageart: " + anfrage.AnfrageArt +
                "; Bettnummer: " + anfrage.Bett.Bettnummer +
                "; Zusatz: " + anfrage.Zusatz);
            }
            else
            {
                Log.Warning("Anfrageart: " + anfrage.AnfrageArt +
                "; Bettnummer: " + anfrage.Bett.Bettnummer);
            }
        }

        private void LogBearbeiteteAnfrage(AnfrageBearbeitet anfrageBearbeitet)
        {
            if (anfrageBearbeitet.Basierende_Anfrage.AnfrageArt == AnfrageArt.Schmerzen)
            {
                Log.Warning("Bearbeitet von: " + anfrageBearbeitet.Responsible_Nurse.Nurse_Name +
                "Anfrageart: " + anfrageBearbeitet.Basierende_Anfrage.AnfrageArt +
                "; Bettnummer: " + anfrageBearbeitet.Basierende_Anfrage.Bett.Bettnummer +
                "; Schmerzlevel: " + anfrageBearbeitet.Basierende_Anfrage.Schmerzlevel +
                "; Anfrage gestellt um: " + anfrageBearbeitet.Basierende_Anfrage.DateTime);
            }
            if (anfrageBearbeitet.Basierende_Anfrage.AnfrageArt == AnfrageArt.Nahrungsmittel || anfrageBearbeitet.Basierende_Anfrage.AnfrageArt == AnfrageArt.Sonstiges)
            {
                Log.Warning("Bearbeitet von: " + anfrageBearbeitet.Responsible_Nurse.Nurse_Name +
                "Anfrageart: " + anfrageBearbeitet.Basierende_Anfrage.AnfrageArt +
                "; Bettnummer: " + anfrageBearbeitet.Basierende_Anfrage.Bett.Bettnummer +
                "; Zusatz: " + anfrageBearbeitet.Basierende_Anfrage.Zusatz +
                "; Anfrage gestellt um: " + anfrageBearbeitet.Basierende_Anfrage.DateTime);
            }
            else
            {
                Log.Warning("Bearbeitet von: " + anfrageBearbeitet.Responsible_Nurse.Nurse_Name +
                "Anfrageart: " + anfrageBearbeitet.Basierende_Anfrage.AnfrageArt +
                "; Bettnummer: " + anfrageBearbeitet.Basierende_Anfrage.Bett.Bettnummer +
                "; Anfrage gestellt um: " + anfrageBearbeitet.Basierende_Anfrage.DateTime);
            }
        }

        public void DeleteAnfrage(Anfrage anfrage)
        {
            anfrageListe.Remove(anfrage);
        }

        public void AddBearbeiteteAnfrage(AnfrageBearbeitet anfrageBearbeitet)
        {
            if(anfrageListeBearbeitet.Count <= 10)
            {
                anfrageListeBearbeitet.Add(anfrageBearbeitet);
            }
            else
            {
                anfrageListeBearbeitet.RemoveAt(0);
                anfrageListeBearbeitet.Add(anfrageBearbeitet);
            }
            LogBearbeiteteAnfrage(anfrageBearbeitet);
        }

        private void Sort_for_Prio()
        {
            List<Anfrage> anfrageListeSchmerzen5 = new List<Anfrage>();
            List<Anfrage> anfrageListeSchmerzen4 = new List<Anfrage>();
            List<Anfrage> anfrageListeSchmerzen3 = new List<Anfrage>();
            List<Anfrage> anfrageListeSchmerzen2 = new List<Anfrage>();
            List<Anfrage> anfrageListeSchmerzen1 = new List<Anfrage>();

            List<Anfrage> anfrageHygiene = new List<Anfrage>();
            List<Anfrage> anfrageMedikamente = new List<Anfrage>();
            List<Anfrage> anfrageNahrungsmittel = new List<Anfrage>();
            List<Anfrage> anfrageSonstiges = new List<Anfrage>();

            foreach (Anfrage x in anfrageListe)
            {
                if(x.AnfrageArt == AnfrageArt.Schmerzen)
                {
                    if (x.Schmerzlevel == 5)
                    {
                        anfrageListeSchmerzen5.Add(x);
                    }
                    else if (x.Schmerzlevel == 4)
                    {
                        anfrageListeSchmerzen4.Add(x);
                    }
                    else if (x.Schmerzlevel == 3)
                    {
                        anfrageListeSchmerzen3.Add(x);
                    }
                    else if (x.Schmerzlevel == 2)
                    {
                        anfrageListeSchmerzen2.Add(x);
                    }
                    else if (x.Schmerzlevel == 1)
                    {
                        anfrageListeSchmerzen1.Add(x);
                    }
                }
                else if(x.AnfrageArt == AnfrageArt.Hygiene)
                {
                    anfrageHygiene.Add(x);
                }
                else if (x.AnfrageArt == AnfrageArt.Medikamente)
                {
                    anfrageMedikamente.Add(x);
                }
                else if (x.AnfrageArt == AnfrageArt.Nahrungsmittel)
                {
                    anfrageNahrungsmittel.Add(x);
                }
                else if (x.AnfrageArt == AnfrageArt.Sonstiges)
                {
                    anfrageSonstiges.Add(x);
                }

            }

            anfrageListe = new List<Anfrage>(anfrageListeSchmerzen5.Count +
                                                anfrageListeSchmerzen4.Count +
                                                anfrageListeSchmerzen3.Count +
                                                anfrageListeSchmerzen2.Count +
                                                anfrageListeSchmerzen1.Count +
                                                anfrageHygiene.Count +
                                                anfrageMedikamente.Count + 
                                                anfrageNahrungsmittel.Count + 
                                                anfrageSonstiges.Count);
            anfrageListe.AddRange(anfrageListeSchmerzen5);
            anfrageListe.AddRange(anfrageListeSchmerzen4);
            anfrageListe.AddRange(anfrageListeSchmerzen3);
            anfrageListe.AddRange(anfrageListeSchmerzen2);
            anfrageListe.AddRange(anfrageListeSchmerzen1);
            anfrageListe.AddRange(anfrageHygiene);
            anfrageListe.AddRange(anfrageMedikamente);
            anfrageListe.AddRange(anfrageNahrungsmittel);
            anfrageListe.AddRange(anfrageSonstiges);

        }
    }
}
