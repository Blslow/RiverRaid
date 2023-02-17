# RiverRaid

Do stworzenia projektu nie zostały użyte żadne zewnętrzne assety.
Projekt to prototyp prostej gry typu endless runner stworzony na potrzeby rekrutacji na stanowisko Unity Developer.
Stworzenie projektu zajęło ok. 6 godzin.
Gracz steruje samolotem za pomocą inputu góra/dół i strzela pociskami używając spacji.
Celem gracza jest zniszczenie jak największej ilości nadlatujących samolotów w jak najkrótszym czasie.
Gracz jest nagradzany za niszczenie nadlatujących samolotów punktami.
Gracz musi unikać nadlatujących samolotów.


Z wszystkich postawionych wymagań gra nie spełnia dwóch:

-po ponownym uruchomieniu aplikacji gra nie wyświetla najlepszego wyniku

-gra nie jest wolna od błędów - w trakcie rozgrywki niektóre nadlatujące samoloty są niszczone za wcześnie

Pierwszy błąd może być związany z użyciem Time.timeScale do zatrzymywania czasu - gra zaczyna się z timeScale ustawionym na 0 przez co nie wykonuje się funkcja Start. Możliwe rozwiązanie to zrezygnowanie z używania timeScale i np. rozdzielenie sceny na menu i grę.

Rozwiązanie pierwszego błędu powinno rozwiązać też drugi, gdyż pojawia się on dopiero od drugiej rozgrywki. (scena byłaby resetowana więc nie ma problemu)
