// ============================================================================
// Ahoy, matey! Welcome aboard the CountingApp, a fine little vessel that be
// sailin' through the numbers 1 through 10 and shoutin' 'em out to the crew.
// Hoist the colors and prepare for a numerical voyage! Arrr!
// ============================================================================

// Shiver me timbers! We be settin' the lower bound of our countin' journey.
// This here be the first number to be hollered across the deck.
const int start = 1;

// Yarr! And this be the final number 'fore we drop anchor and call it a day.
const int end = 10;

// Yarr! A chest o' piratey exclamations to season each number with.
string[] pirateWords = { "arrrr!", "Ahoy!", "Matey!", "yarr!" };
var random = new Random();

// Avast! Here we loop through every number from start to end, inclusive-like,
// and bellow each one out to the high seas (a.k.a. the console window).
for (int i = start; i <= end; i++)
{
    // Blimey! Pick a random piratey shout to follow the number.
    string shout = pirateWords[random.Next(pirateWords.Length)];
    Console.WriteLine($"{i}, {shout}");
}

// Land ho! We've counted to ten — time to make our grand entrance.
Console.WriteLine("Enteriiiing!");

// All hands accounted for! The countin' be done, and we sail off into port.
