#include <iostream>
#include <string>
#include <vector>
#include <cctype>

using namespace std;

// Usuwa spacje i inne białe znaki z początku oraz końca tekstu.
string UsunSpacje(string tekst)
{
    int poczatek = 0;
    while (poczatek < (int)tekst.length() && isspace((unsigned char)tekst[poczatek]))
    {
        poczatek++;
    }

    int koniec = (int)tekst.length() - 1;
    while (koniec >= poczatek && isspace((unsigned char)tekst[koniec]))
    {
        koniec--;
    }

    if (poczatek > koniec)
    {
        return "";
    }

    string wynik = "";
    for (int i = poczatek; i <= koniec; i++)
    {
        wynik = wynik + tekst[i];
    }

    return wynik;
}

// Zamienia wszystkie litery na małe, żeby porównywać imiona bez względu na wielkość liter.
string MaleLitery(string tekst)
{
    string wynik = tekst;

    for (int i = 0; i < (int)wynik.length(); i++)
    {
        wynik[i] = (char)tolower((unsigned char)wynik[i]);
    }

    return wynik;
}

// Sprawdza, czy tekst składa się tylko z cyfr.
bool CzySameCyfry(string tekst)
{
    if (tekst == "")
    {
        return false;
    }

    for (int i = 0; i < (int)tekst.length(); i++)
    {
        if (!isdigit((unsigned char)tekst[i]))
        {
            return false;
        }
    }

    return true;
}

// Wczytuje liczbę całkowitą z podanego zakresu. Przy błędzie pyta jeszcze raz.
int WczytajLiczbe(string pytanie, int minimum, int maksimum)
{
    while (true)
    {
        cout << pytanie;

        string tekst;
        getline(cin, tekst);
        tekst = UsunSpacje(tekst);

        if (CzySameCyfry(tekst) && tekst.length() <= 3)
        {
            int liczba = 0;

            for (int i = 0; i < (int)tekst.length(); i++)
            {
                liczba = liczba * 10 + (tekst[i] - '0');
            }

            if (liczba >= minimum && liczba <= maksimum)
            {
                return liczba;
            }
        }

        cout << "Blad. Podaj liczbe calkowita od " << minimum << " do " << maksimum << "." << endl;
    }
}

// Wczytuje imię. Imię po usunięciu spacji nie może być puste.
string WczytajImie()
{
    while (true)
    {
        cout << "Podaj imie: ";

        string imie;
        getline(cin, imie);
        imie = UsunSpacje(imie);

        if (imie != "")
        {
            return imie;
        }

        cout << "Blad. Imie nie moze byc puste." << endl;
    }
}

class Zawodnik
{
private:
    string imie;
    int punkty;

public:
    Zawodnik(string noweImie, int nowePunkty)
    {
        imie = noweImie;
        punkty = nowePunkty;
    }

    string PobierzImie()
    {
        return imie;
    }

    int PobierzPunkty()
    {
        return punkty;
    }
};

class Ranking
{
private:
    vector<Zawodnik> zawodnicy;

public:
    void DodajZawodnika(string imie, int punkty)
    {
        Zawodnik nowyZawodnik(imie, punkty);
        zawodnicy.push_back(nowyZawodnik);
    }

    int PobierzLiczbeZawodnikow()
    {
        return (int)zawodnicy.size();
    }

    Zawodnik PobierzZawodnika(int indeks)
    {
        return zawodnicy[indeks];
    }

    // Sortowanie bąbelkowe: najpierw więcej punktów, przy remisie imię alfabetycznie.
    void Sortuj()
    {
        for (int i = 0; i < (int)zawodnicy.size() - 1; i++)
        {
            for (int j = 0; j < (int)zawodnicy.size() - 1 - i; j++)
            {
                bool trzebaZamienic = false;

                if (zawodnicy[j].PobierzPunkty() < zawodnicy[j + 1].PobierzPunkty())
                {
                    trzebaZamienic = true;
                }
                else if (zawodnicy[j].PobierzPunkty() == zawodnicy[j + 1].PobierzPunkty())
                {
                    string imiePierwsze = MaleLitery(zawodnicy[j].PobierzImie());
                    string imieDrugie = MaleLitery(zawodnicy[j + 1].PobierzImie());

                    if (imiePierwsze > imieDrugie)
                    {
                        trzebaZamienic = true;
                    }
                }

                if (trzebaZamienic)
                {
                    Zawodnik pomocniczy = zawodnicy[j];
                    zawodnicy[j] = zawodnicy[j + 1];
                    zawodnicy[j + 1] = pomocniczy;
                }
            }
        }
    }

    /**
     * Nazwa metody: Srednia
     * Opis: Oblicza średnią arytmetyczną punktów wszystkich zawodników.
     * Parametry: brak
     * Zwracana wartość: double - średnia liczba punktów
     * Autor: TEST_01
     */
    double Srednia()
    {
        if (zawodnicy.size() == 0)
        {
            return 0.0;
        }

        int suma = 0;

        for (int i = 0; i < (int)zawodnicy.size(); i++)
        {
            suma = suma + zawodnicy[i].PobierzPunkty();
        }

        return (double)suma / (double)zawodnicy.size();
    }

    int PoliczPowyzejSredniej()
    {
        double srednia = Srednia();
        int licznik = 0;

        for (int i = 0; i < (int)zawodnicy.size(); i++)
        {
            if (zawodnicy[i].PobierzPunkty() > srednia)
            {
                licznik++;
            }
        }

        return licznik;
    }
};

// Wypisuje średnią z przecinkiem i dwoma miejscami po przecinku.
void WypiszSrednia(double srednia)
{
    int czescCalkowita = (int)srednia;
    int setne = (int)((srednia - czescCalkowita) * 100.0 + 0.5);

    if (setne == 100)
    {
        czescCalkowita++;
        setne = 0;
    }

    cout << czescCalkowita << ",";

    if (setne < 10)
    {
        cout << "0";
    }

    cout << setne;
}

int main()
{
    cout << "=== CLUB+ - ranking zawodnikow (TEST_01) ===" << endl;
    cout << endl;

    int liczbaZawodnikow = WczytajLiczbe("Podaj liczbe zawodnikow (3-10): ", 3, 10);

    Ranking ranking;

    for (int i = 0; i < liczbaZawodnikow; i++)
    {
        cout << endl;
        cout << "Zawodnik " << (i + 1) << ":" << endl;

        string imie = WczytajImie();
        int punkty = WczytajLiczbe("Podaj liczbe punktow (0-100): ", 0, 100);

        ranking.DodajZawodnika(imie, punkty);
    }

    ranking.Sortuj();

    cout << endl;
    cout << "Ranking zawodnikow:" << endl;

    for (int i = 0; i < ranking.PobierzLiczbeZawodnikow(); i++)
    {
        Zawodnik zawodnik = ranking.PobierzZawodnika(i);

        cout << (i + 1) << ". " << zawodnik.PobierzImie() << " - "
             << zawodnik.PobierzPunkty() << " pkt" << endl;
    }

    cout << endl;
    cout << "Srednia punktow: ";
    WypiszSrednia(ranking.Srednia());
    cout << endl;

    cout << "Wynik powyzej sredniej: " << ranking.PoliczPowyzejSredniej()
         << " zawodnikow" << endl;

    return 0;
}
