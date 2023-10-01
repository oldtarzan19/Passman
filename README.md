# Általános információk

---

A programkönytárban van egy resources mappa, abba kell elhelyezni a két db csv-t. (user, vault)
A resources mappa a Program.cs fájl mellett található.
A program parancsai a következően működnek a dotnet run után:
--add - Bejelentkezési adatok megadása után el tudunk menteni új jelszavakat.
--list - Bejelentkezési adatok megadása után kilistázza az összes tárolt jelszót amit egy adott felhasználó elmentett.
--register - Új felashználó regisztrálása a programba.

A workdir módosításást megvalósítottam, de mivel a tesztels során bugosnak bizonyult ezért kikommenteztem, így nem működik és nem zavar be a program működésébe. (Inkább működjön a program csak az alap workdirből mint, hogy valami rosszat mentsen a config.jsonba és ne működjön tovább)
Ott két db parancs volt:
--workdir - Ezzel lehett volna módosítani a workdirt.
-- delete - Ezzel lehetett volna alap helyzetbe állítani a workdirt.
A programkódban kikommentezett sorok ezekre utalnak.
---