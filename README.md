# ElinsBank-Individuellt-projekt

INNEHÅLL/STRUKTUR
Detta är en bankautomat och det finns fem användare. I Main så har alla konton skapats för användarna sedan körs en metod LogIn som skriver ut ett välkomstmeddelande samt 
ber användaren att ange användarnamn och pinkod. I metoden kontrolleras att användarnamn finns och att pinkoden stämmer överens med användaren. Användaren får tre försök att
skriva rätt pinkod och sedan stängs programmet ner. Om användaren lyckas logga in så går programmetvidare till metoden Menu. Det finns fyra menyalternativ och varje alternativ
(förutom att logga ut) har en egen metod. När varje funktion har körts för alternativ 1-3 så ska användaren klicka på enter för att komma tillbaka till huvudmenyn. 

Menyalternativ 1, metod CheckAccounts. Här kan användaren se konton och saldo. Inget mer kan göras.

Menyalternativ 2, metod AccountsTransfer. Här kan användaren föra över pengar mellan konton. Användaren anger vilket konto pengarna ska dras ifrån, vilket konto det ska föras 
över till, samt summan som ska föras över. Koden kontrollerar att det finns mer än ett konto, att summan att föra över finns på kontot och att pengar inte förs över till samma 
konto. Efter att överföringen är klar skrivs nytt saldo ut för berörda konton. 

Menyalternativ 3, metod WithdrawalAccount. Här kan användaren ”ta ut” pengar från ett konto. Användaren anger vilket konto det ska dras ifrån och hur mycket. Koden kontrollerar 
att summan finns på kontot. Sedan ska användaren ange pinkod för att bekräfta uttaget. Användaren har tre försök på sig att skriva rätt pinkod annars går det tillbaka till 
huvudmenyn. Om det är korrekt pinkod så tas pengarna ut och nytt saldo skrivs ut för kontot.

Menyalternativ 4, logga ut. Användaren loggas ut men programmet stängs inte ner utan går tillbaka till inloggningen.


REKLEKTION/RESONEMANT UPPBYGGNAD AV PROGRAMMET
I början gjorde jag en 2D jagged array för varje användare med konton och saldo, alltså fem stycken. Detta var väldigt onödigt och gjorde koden rätt komplicerad. Koden funkade 
men jag kände att skriva resten av koden kunde bli onödigt klurigt och komplicerat så jag bestämde mig för att börja om. I stället gjorde jag en 2D array som inkluderade alla 
användare med tillhörande konton och saldo. Första siffran (array[första siffra, andra siffra]) blev då användar-ID genom att gå igenom arrayen och se vilket index det låg på 
och använde sen detta som användar-ID framöver. Om andra siffran var noll var det användarnamnet, annars blev varje ojämnt tal kontonamn och varje jämnt tal saldot. Detta 
underlättade sedan när man skulle skriva ut konton och saldo. Nu har jag tre stycken arrayer. En array för användare, en för användarnas pinkod och en 2d array för användarnas 
konton. Det skulle nog vara smidigt att slå ihop detta till en enda 2d array. Första siffran skulle då också funkat som userID på samma sätt i den lösning jag har nu. Men 
eftersom mitt program fungerar så väljer jag att behålla den nuvarande lösningen.

För att skriva ut konton och saldo i varje metod så har jag valt en for loop som går igenom längden i arrayen för antal konton. Sedan i for-loopen har jag valt att lägga in en 
if-sats. Eftersom jag vet att alla kontonamn är ojämna tal så vill jag att de ska skrivas ut med Console.Write. Saldo för varje konto är jämna tal över 0 och de vill jag att de 
ska skrivas ut på samma rad som kontonamn så att det blir tydligt i konsolen. Här skulle man troligtvis kunna korta ner koden och göra den simplare men jag har tyvärr inte 
kommit på något bättre sätt än.

Menyn valde jag att göra till en switch-sats eftersom jag tycker det är mer passade än en if-sats. För varje menyalternativ har jag gjort en metod (förutom för att logga ut) 
för att inte ha så mycket kod i menymetoden och för att det blir tydligare att hålla koden för varje funktion separat.

Eftersom man ska kunna föra över och ta ut pengar från konton så måste varje saldo i string-arrayen konverteras till decimal. Jag har valt att använda decimal eftersom det är 
ett ekonomiskt sammanhang där man vill ha det precist. När man har konverterat saldot till en decimalvariabel så kan man addera/subtrahera summan. Sedan måste nya saldot 
konverteras till string igen för att för att uppdatera värdet i arrayen. Detta tror jag är smidigare än att ha saldot i en decimalvariabel hela tiden eftersom det är smidigt 
att ha en array att loopa igenom.

Först hade jag koden för inloggningen i Main men flyttade sedan ut det till en egen metod. Men jag började sedan fundera på om det var bättre att ha inloggningen i Main ändå 
eftersom koden endast skrivs på ett ställe och det blir kanske onödig kod med in och ut parametrar som ska deklareras i Main osv. Men även om det behöves lite extra kod så 
tyckte jag att det var tydligare att lägga inloggningen i en egen metod så att man också tydligare ser vad som händer i Main. 

I början skapade jag bara två konton till varje användare och hade en lösning för utskrift, överföring och uttag av pengar anpassat endast om man hade två konton. När jag sen 
la till fler konton för vissa användare så funkade inte denna lösning, men jag lyckades komma på en matematisk lösning som funkade oavsett antal konton. Framöver bör jag nog 
tänka redan från början att fixa en lösning som funkar oavsett antal, om det är möjligt. Det underlättar så att man inte behöver justera uppbyggnaden i resten av koden.
