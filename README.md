# Navigator

Aplikacja pozwalająca na tworzenie oraz przeglądanie planów budynków, z podziałem na piętra i pomieszczenia.
Do wygenerowania widoku w WebView skorzystałem z [biblioteki Leaflet](https://github.com/Leaflet/Leaflet), 
a parse'owanie stworzyłem w głównej mierze poprzez reverse-engineering strony [Floorplans](https://github.com/anthonyblackham/floorplans).

# Instalacja
Z zakładki Releases wybieramy interesującą nas wersję, a następnie pobieramy jej pliki dla jednej z platform:

## Windows

Po wypakowaniu paczki znajdziemy w niej pliki o strukturze:
```
.
└── SMCEBI_Navigator_wersja/
    ├── Add-AppDevPackage.resources
    ├── Dependencies
    ├── Add-AppDevPackage.ps1
    ├── Install.ps1
    ├── SMCEBI_Navigator_1.0.2.0_x64.cer
    └── SMCEBI_Navigator_1.0.2.0_x64.msix
```
Za pierwszym razem należy zainstalować certyfikat, aby Windows pozwolił nam na instalację aplikacji.
Możemy to zrobić ręcznie, czyli instalując certyfikat `.cer`, a następnie korzystając z pliku `.MSIX` zainstalować aplikację, 
ale możemy alternatywnie w tym celu uruchomić `Install.ps1` (możliwe że będzie trzeba podać uprawnienia administratora).

## Android

Po rozpakowaniu paczki instalujemy plik `.apk`, potwierdzamy ewentualną zgodę o instalacji programów spoza Google Play.
