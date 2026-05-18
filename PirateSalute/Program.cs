// ============================================================================
// Ahoy, matey! Welcome aboard the PirateSalute, a wee program that greets
// every scallywag who dares to type their name into the console. Arrr!
// ============================================================================

// Hoist the colors and ask the swabbie for their name.
Console.Write("What be yer name, sailor? ");
string? name = Console.ReadLine();

// Blimey! Give the brave soul a proper pirate salute.
Salute(name);

// Avast! Now we parley with the new recruit and see what skills they bring aboard.
AskWhatYeCanDo();

// Yarr! This here be the salute function — small, sharp, and to the point.
static void Salute(string? name)
{
    // Shiver me timbers! If no name be given, we call 'em "stranger".
    string greeting = string.IsNullOrWhiteSpace(name) ? "stranger" : name.Trim();
    Console.WriteLine($"Ahoy, {greeting}, lets get to work mate!");
}

// Arrr! Roll out the recruitment manifest and let the swabbie pick their poison.
static void AskWhatYeCanDo()
{
    // Hoist the question flag high so every bilge rat can read it.
    Console.WriteLine();
    Console.WriteLine("What can ye do?");

    // These be the five noble trades aboard this here vessel — pick wisely, matey!
    Console.WriteLine("  1. Keep the Rum flowin' so the barrels never run dry, savvy?");
    Console.WriteLine("  2. Sniff out buried doubloons 'n glitterin' treasures across the seven seas");
    Console.WriteLine("  3. Cook up a hearty feast every night so the crew don't mutiny on empty bellies");
    Console.WriteLine("  4. Swab the deck clean when the sun sinks below the waves");
    Console.WriteLine("  5. Steer this here ship to every cursed adventure waitin' on the horizon");

    // Prompt the scallywag fer their choice — one digit be all we need.
    Console.Write("Yer pick (1-5), matey: ");
    string? choice = Console.ReadLine()?.Trim();

    // Hoist the matchin' reply from the pirate's locker.
    string response = choice switch
    {
        "1" => "Arrrrr, a Rum-keeper! I can use a lad like that — but mind ye, ye'll be helpin' empty the bottles too. Hehe!",
        "2" => "Shiver me timbers! A treasure-sniffer ye be? Then mark me words, half o' what ye dig up belongs to the Cap'n, savvy?",
        "3" => "Yo-ho-ho! A cook, eh? If yer stew tastes like bilge water, ye'll be walkin' the plank by sundown, matey!",
        "4" => "Aye, a deck-swabber! 'Tis honest work for an honest scallywag — just don't slip on me peg leg, ye barnacle!",
        "5" => "Blimey! A navigator! Steer us true 'n I'll share me grog — steer us wrong 'n the kraken gets a snack!",
        _   => "Arrr, ye landlubber! That be no proper answer — pick a number 'tween 1 'n 5 or walk the plank, ye scurvy dog!"
    };

    // Bellow the response across the deck fer all to hear.
    Console.WriteLine(response);
}

